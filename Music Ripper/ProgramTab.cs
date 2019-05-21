using Mp3Lib;
using Shell32;
using System.IO;

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
            Folder folder = shell.NameSpace(form.settingsTab.Settings.SourceMusicDriversPath));
            if(folder == null)
            {
                //TODO: Add dialog
                return;
            }

            FolderItem sourceFolder = ((folder) as Folder3).Self;
            if (!sourceFolder.IsFileSystem)
            {
                //TODO: Move filse to temp to change Tag and return them.
                return;
            }

            if (!Directory.Exists(sourceFolder.Path))
            {
                //TODO: Add dialog
                return;
            }

            string[] musicFiles = Directory.GetFiles(sourceFolder.Path, "*.mp3");
            Mp3File mp3File;
            foreach (string musicFilePath in musicFiles)
            {
                mp3File = new Mp3File(musicFilePath);
                mp3File.TagHandler.Album = form.MusicTagName.Text;
                mp3File.TagHandler.Artist = form.MusicTagName.Text;
                mp3File.TagHandler.Disc = "";
                mp3File.TagHandler.Title = form.MusicTagName.Text;
                mp3File.TagHandler.Track = "";
                mp3File.TagHandler.Song = "";
                mp3File.Update();
            }
        }

        public void MoveMusic()
        {
            Folder srcFolder = shell.NameSpace(form.settingsTab.Settings.SourceMusicDriversPath);
            Folder dstFolder = shell.NameSpace(form.settingsTab.Settings.DestinationMusicDriversPath);
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