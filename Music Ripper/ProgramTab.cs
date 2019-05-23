using Shell32;
using System;
using System.IO;
using System.Linq;
using System.Threading;

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

        public void SetMusicTag()
        {
            Folder folder = shell.NameSpace(form.settingsTab.Settings.SourceMusicDriversPath);
            if(folder == null)
            {
                //TODO: Add dialog
                return;
            }


            FolderItem[] musicFiles = folder.Items().Cast<FolderItem>().Where(item => item.Type == "MP3 File").ToArray();

            foreach (FolderItem musicFilePath in musicFiles)
            {
                Folder3 tempFolder = (Folder3)shell.NameSpace(Path.GetTempPath());
                tempFolder.NewFolder("Music ripper");
                tempFolder = (Folder3)shell.NameSpace(Path.Combine(Path.GetTempPath(), "Music ripper"));
                tempFolder.MoveHere(musicFilePath);
                FolderItem tempMpFile = tempFolder.Items().Cast<FolderItem>().First(item => item.Name == musicFilePath.Name);
                using (TagLib.File file = TagLib.File.Create(tempMpFile.Path))
                {
                    file.Tag.Album = form.MusicTagName.Text;
                    file.Tag.AlbumArtists = new string[] { form.MusicTagName.Text };
                    file.Tag.Performers = new string[] { form.MusicTagName.Text };
                    file.Save();
                }
                Thread thread = new Thread(new ThreadStart(() =>
                {
                    folder.MoveHere(tempMpFile.Path);
                    while (!folder.Items().Cast<FolderItem>().Any(item => item.Name == musicFilePath.Name))
                    {
                    }
                }));
                thread.Start();
                thread.Join();
                
            }
        }

        public void MoveMusic()
        {
            string sourcePath = form.settingsTab.Settings.SourceMusicDriversPath.GetPath();
            string destinationPath = form.settingsTab.Settings.DestinationMusicDriversPath.GetPath();
            Folder srcFolder = shell.NameSpace(sourcePath);
            Folder dstFolder = shell.NameSpace(destinationPath);
            if (!string.IsNullOrEmpty(form.MusicTagName.Text))
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
    }
}