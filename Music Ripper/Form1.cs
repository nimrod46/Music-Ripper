using Mp3Lib;
using Shell32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Music_Ripper
{


    public partial class Form1 : Form
    {
        private Settings settings;
        private XmlManager<Settings> xmlManager;
        private Shell shell;
        private PortableDevice device;
        public Form1()
        {
          
            InitializeComponent();
            shell = new Shell();
            xmlManager = new XmlManager<Settings>();
            if (File.Exists("Settings"))
            {
                LoadSettings();
                UpdateTextBoxs();
            }
            else
            {
                settings = new Settings();
            }
        }

        private void UpdateTextBoxs()
        {
            SourceMusicPath.Text = GetPathAsText(settings.SourceMusicDriversPath);
            DestinationMusicPath.Text = GetPathAsText(settings.DestinationMusicDriversPath);
        }

        private void SaveSettings()
        {
            XmlManager<Settings> xmlManager = new XmlManager<Settings>();
            xmlManager.Save("Settings", settings);
        }

        private void LoadSettings()
        {
            if (!File.Exists("Settings")) { return; }
            XmlManager<Settings> xmlManager = new XmlManager<Settings>();
            settings = xmlManager.Load("Settings");
        }

        private bool TryGetSelectedPath(bool canBeNoneFileSystem ,out string path)
        {
            path = "";
            Folder folder = shell.BrowseForFolder((int) Handle, "Select folder", 0);
            if (folder != null)
            {
                path = (folder as Folder3).Self.Path;
                if (!(folder as Folder3).Self.IsFileSystem && path.Contains("SID-")){
                    int startBadIndex = path.IndexOf("SID-") - 1;
                    int endBadIndex = path.IndexOf("\\", startBadIndex + 1);
                    path = path.Remove(startBadIndex, endBadIndex - startBadIndex);
                }
                if (!(folder as Folder3).Self.IsFileSystem && !canBeNoneFileSystem)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        private void UpdateMusicPath(Action<string> setting, bool canBeNoneFileStem)
        {
            if (TryGetSelectedPath(canBeNoneFileStem, out string path))
            {
                setting(path);
                UpdateTextBoxs();
            }
        }

        private void SetMusicTag()
        {
            FolderItem sourceFolder = (shell.NameSpace(settings.SourceMusicDriversPath) as Folder3).Self;
            if (!sourceFolder.IsFileSystem)
            {
                //TODO: Add dialog
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
                mp3File.TagHandler.Album = "ALBUM1";
                mp3File.TagHandler.Artist = "ARTIST1";
                mp3File.TagHandler.Disc = "DISC";
                mp3File.TagHandler.Title = "Title";
                mp3File.TagHandler.Track = "Track";
                mp3File.TagHandler.Song = "Song";
                mp3File.Update();
            }
        }

        private void MoveMusic()
        {
            
            Folder srcFolder = shell.NameSpace(settings.SourceMusicDriversPath);
            Folder dstFolder =  shell.NameSpace(settings.DestinationMusicDriversPath);
            foreach (FolderItem currFolderItem in srcFolder.Items())
            {
                if (currFolderItem.Type == "MP3 File")
                {
                    dstFolder.CopyHere(currFolderItem, 0);
                }
            }
        }

        private string GetPathAsText(string path)
        {
            Folder folder = shell.NameSpace(path);
            if(folder == null)
            {
                return "";
            }
            FolderItem folderItem = (folder as Folder3).Self;
            if (folderItem.IsFileSystem)
            {
                return folderItem.Path;
            }
            else
            {
                return folderItem.Name;
            }
        }

        private void LoadMusic_Click(object sender, EventArgs e)
        {
            SetMusicTag();
            MoveMusic();
        }


        private void SelectMusicSourceButton_Click(object sender, EventArgs e)
        {
            UpdateMusicPath(p => settings.SourceMusicDriversPath = p, false);
        }

        private void SelectDestinatonMusicButton_Click(object sender, EventArgs e)
        {
            UpdateMusicPath(p => settings.DestinationMusicDriversPath = p, true);
        }

        private struct DriveInf
        {
            public string RootDir { get; set; }
            public string Perfix { get; set; }

            public DriveInf(string rootDir, string perfix) : this()
            {
                RootDir = rootDir;
                Perfix = perfix;
            }

            public override string ToString()
            {
                return Perfix + RootDir;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            LoadSettings();   
        }
    }
}
