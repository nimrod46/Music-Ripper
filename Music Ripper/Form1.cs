using Mp3Lib;
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
        Settings settings;
        public Form1()
        {
            InitializeComponent();
            RefreshDrivers();
            settings = new Settings(SourceMusicPath, DestinationMusicPath);
        }


        private void RefreshDrivers()
        {
            RefreshBox(SourceMusicDrivers);
            RefreshBox(DestinationMusicDrives);
        }

        private void RefreshBox(ListControl list)
        {
            List<DriveInf> drivers = new List<DriveInf>();
            foreach (DriveInfo driver in DriveInfo.GetDrives())
            {
                string perfix = "";
                bool isRelevent = false;
                switch (driver.DriveType)
                {
                    case DriveType.Unknown:
                        break;
                    case DriveType.NoRootDirectory:
                        break;
                    case DriveType.Removable:
                        perfix = "USB: ";
                        isRelevent = true;
                        break;
                    case DriveType.Fixed:
                        isRelevent = true;
                        break;
                    case DriveType.Network:
                        break;
                    case DriveType.CDRom:
                        perfix = "CD: ";
                        isRelevent = true;
                        break;
                    case DriveType.Ram:
                        break;
                    default:
                        break;
                }
                if (isRelevent)
                {
                    drivers.Add(new DriveInf(driver.RootDirectory.ToString(), perfix));
                }
            }
            list.DataSource = drivers;
        }

        private bool TryGetSelectedPathFromDriver(string drive, out string path)
        {
            path = "";
            foreach (DriveInfo driver in DriveInfo.GetDrives())
            {
                if (driver.RootDirectory.ToString() == drive)
                {
                    using (FolderBrowserDialog musicFolder = new FolderBrowserDialog())
                    {
                        musicFolder.SelectedPath = driver.RootDirectory.ToString();
                        DialogResult result = musicFolder.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            path = musicFolder.SelectedPath;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshDrivers();
        }

        private void SourceMusicDrivers_DoubleClick(object sender, EventArgs e)
        {
            if (TryGetSelectedPathFromDriver(((DriveInf)SourceMusicDrivers.SelectedItem).RootDir, out string path))
            {
                settings.SourceMusicDriversPath = path;
                SourceMusicDrivers.Text = path;
                Console.WriteLine(path);
            }
        }

        private void DestinationMusicDrives_DoubleClick(object sender, EventArgs e)
        {
            if (TryGetSelectedPathFromDriver(((DriveInf)DestinationMusicDrives.SelectedItem).RootDir, out string path))
            {
                settings.DestinationMusicDriversPath = path;
                DestinationMusicDrives.Text = path;
                Console.WriteLine(path);
            }
        }

        private void LoadMusic_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(settings.SourceMusicDriversPath)) { return; }

            string[] musicFiles = Directory.GetFiles(settings.SourceMusicDriversPath, "*.mp3");
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
    }
}
