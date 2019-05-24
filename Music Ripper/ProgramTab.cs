using Shell32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Music_Ripper
{
    internal class ProgramTab
    {
        private Shell shell;

        private Form1 form;

        public ProgramTab(Form1 form)
        {
            this.form = form;
            shell = new Shell();
        }

        public bool TryGetPathWithMp3Files(string rootPath, out string path)
        {
            path = "";
            if (string.IsNullOrWhiteSpace(rootPath))
            {
                MessageBox.Show("נתיב ריק", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                return false;
            }
            Folder pathFolder = shell.NameSpace(rootPath);
            List<FolderItem> directories = pathFolder.Items().Cast<FolderItem>().Where(item => item.IsFolder).Cast<FolderItem>().OrderByDescending(item => item.ModifyDate).ToList();

            int i = 0;
            while (!pathFolder.Items().Cast<FolderItem>().Any(item => item.Type == "MP3 File"))
            {
                if (i >= directories.Count)
                {
                    //TODO: Add dialog that mp3 files were not found.
                    MessageBox.Show("לא נמצאו קבצי MP3", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    Console.WriteLine("no mp3 files were found");
                    return false;
                }
                pathFolder = (Folder)directories[i].GetFolder;
                i++;
            }
            path = ((Folder3)pathFolder).Self.Path;
            return true;
        }

        public void SetMusicTag(string sourcePath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath))
            {
                Console.WriteLine("Cannot change tag, path was not found");
                return;
            }
            Folder folder = shell.NameSpace(sourcePath);
            if(folder == null)
            {
                //TODO: Add dialog
                Console.WriteLine("Cannot change tag, path was not found");
                return;
            }


            FolderItem[] musicFiles = folder.Items().Cast<FolderItem>().Where(item => item.Type == "MP3 File").ToArray();

            foreach (FolderItem musicFilePath in musicFiles)
            {
                Folder3 tempFolder = (Folder3)shell.NameSpace(Path.GetTempPath());
                tempFolder.NewFolder("Music ripper");
                tempFolder = (Folder3)shell.NameSpace(Path.Combine(Path.GetTempPath(), "Music ripper"));
                tempFolder.MoveHere(musicFilePath);
                WaitForAFileTransfer(tempFolder, musicFilePath.Name);
                FolderItem tempMpFile = tempFolder.Items().Cast<FolderItem>().First(item => item.Name == musicFilePath.Name);
                using (TagLib.File file = TagLib.File.Create(tempMpFile.Path))
                {
                    file.Tag.Album = form.MusicTagName.Text;
                    file.Tag.AlbumArtists = new string[] { form.MusicTagName.Text };
                    file.Tag.Performers = new string[] { form.MusicTagName.Text };
                    file.Save();
                }
                folder.MoveHere(tempMpFile.Path);
                WaitForAFileTransfer(folder, tempMpFile.Name);
            }
        }

        public void MoveMusic(string sourcePath, string destinationPath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath) || string.IsNullOrWhiteSpace(destinationPath))
            {
                Console.WriteLine("Invalid paths");
                return;
            }
            Folder srcFolder = shell.NameSpace(sourcePath);
            Folder dstFolder = shell.NameSpace(destinationPath);
           
            if (srcFolder == null || dstFolder == null)
            {
                Console.WriteLine("Invalid paths");
                return;
            }
            if (!string.IsNullOrWhiteSpace(form.MusicTagName.Text))
            {
                dstFolder.NewFolder(form.MusicTagName.Text);
                dstFolder = shell.NameSpace(Path.Combine(destinationPath, form.MusicTagName.Text));
            }
            foreach (FolderItem currFolderItem in srcFolder.Items())
            {
                if (currFolderItem.Type == "MP3 File")
                {
                    dstFolder.CopyHere(currFolderItem, 0);
                }
            }
        }

        private void WaitForAFileTransfer(Folder folder, string file)
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                while (!folder.Items().Cast<FolderItem>().Any(item => item.Name == file))
                {
                    Console.WriteLine("Waiting for file transfer...");
                }
            }));
            thread.Start();
            thread.Join();
        }
    }
}