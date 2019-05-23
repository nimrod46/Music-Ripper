using Shell32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Music_Ripper.DynamicPath;

namespace Music_Ripper
{
    public class SettingsTab
    {
        private readonly XmlManager<Settings> xmlManager;
        private readonly Form1 form;

        public Settings Settings { get; private set; }

        private Shell shell;
        public SettingsTab(Form1 form)
        {
            this.form = form;
            xmlManager = new XmlManager<Settings>();
            shell = new Shell();

            if (File.Exists("Settings"))
            {
                LoadSettings();
            }
            else
            {
                Settings = new Settings();
            }

        }

        public void UpdateSourceMusicPath()
        {
            UpdateMusicPath(p =>
            {
                Folder path = shell.NameSpace(p);
                List<FolderItem> directories = path.Items().Cast<FolderItem>().Where(item => item.IsFolder).Cast<FolderItem>().ToList();
                
                int i = 0;
                while (!path.Items().Cast<FolderItem>().Any(item => item.Type == "MP3 File"))
                {
                    if (i >= directories.Count)
                    {
                        //TODO: Add dialog that mp3 files were not found.
                        Console.WriteLine("no mp3 files were found");
                        return;
                    }
                    path = (Folder) directories[i].GetFolder;
                    i++;
                }
                p = ((Folder3)path).Self.Path;
                Settings.SourceMusicDriversPath = PathToDynamicPath(p);
                
            });
        }

        public void UpdateDestinationMusicPath()
        {
            UpdateMusicPath(p => Settings.DestinationMusicDriversPath = PathToDynamicPath(p));
        }

        private DynamicPath PathToDynamicPath(string path)
        {
            Folder3 folder = (Folder3)shell.NameSpace(path);
            Console.WriteLine("PATH " + path);
            List<string> subFolders = new List<string>();
            if (folder != null && !folder.Self.IsFileSystem)
            {
                while (folder.Self.Path.Count(c => c == '\\') != 4)
                {
                    subFolders.Add(folder.Title);
                    folder = (Folder3) folder.ParentFolder;
                }
            }
            return new DynamicPath()
            {
                RootDrivePath = folder.Self.Path,
                SubFolders = subFolders.ToArray()
            };
        }

        private void UpdateMusicPath(Action<string> setSetting)
        {
            if (TryGetSelectedPath(out string path))
            {
                setSetting(path);
                UpdateTextBoxs();
            }
        }

        private void UpdateTextBoxs()
        {
            form.SourceMusicPath.Text = GetPathAsText(Settings.SourceMusicDriversPath.GetPath());
            form.DestinationMusicPath.Text = GetPathAsText(Settings.DestinationMusicDriversPath.GetPath());
        }

        public void SaveSettings()
        {
            XmlManager<Settings> xmlManager = new XmlManager<Settings>();
            xmlManager.Save("Settings", Settings);
        }

        public void LoadSettings()
        {
            if (!File.Exists("Settings")) { return; }
            XmlManager<Settings> xmlManager = new XmlManager<Settings>();
            Settings = xmlManager.Load("Settings");
            UpdateTextBoxs();
        }

        private bool TryGetSelectedPath(out string path)
        {
            path = "";
            Folder folder = shell.BrowseForFolder(0, "Select folder", 0);
            if (folder != null)
            {
                path = RemoveBadStringFromPath((Folder3) folder);
                return true;
            }
            return false;
        }

        private string GetPathAsText(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return "";
            }
            Folder folder = shell.NameSpace(path);
            if (folder == null)
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

        public static string RemoveBadStringFromPath(Folder3 folder)
        {
            string path = folder.Self.Path;
            if (!(folder as Folder3).Self.IsFileSystem && path.Contains("SID-"))
            {
                int startBadIndex = path.IndexOf("SID-") - 1;
                int endBadIndex = path.IndexOf("}", startBadIndex + 1) + 1;
                path = path.Remove(startBadIndex, endBadIndex - startBadIndex);
            }
            return path;
        }

    }
}
