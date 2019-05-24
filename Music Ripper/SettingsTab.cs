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

            if (File.Exists("Settings.xml"))
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
                Settings.SourceMusicDriversPath = PathToDynamicPath(p);
                UpdateSourceTextBox();
            });
        }

        public void UpdateDestinationMusicPath()
        {
            UpdateMusicPath(p =>
            {
                Settings.DestinationMusicDriversPath = PathToDynamicPath(p);
                UpdateDestinationMusicPath();
            });
        }

        private DynamicPath PathToDynamicPath(string path)
        {
            Folder3 folder = (Folder3)shell.NameSpace(path);
            List<string> subFolders = new List<string>();
            if (folder != null && !folder.Self.IsFileSystem)
            {
                if (!path.Contains("usb"))
                {
                    MessageBox.Show("מיקום לא תקין נבחר", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    Console.WriteLine("Invalid path selected: " + path);
                    return new DynamicPath();
                }
                while (folder.Self.Path.Count(c => c == '\\') != 4)
                {
                    subFolders.Add(folder.Title);
                    folder = (Folder3) folder.ParentFolder;
                }
                if(subFolders.Count == 0)
                {
                    MessageBox.Show("יש לבחור תיקייה בתוך המכשיר", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    Console.WriteLine("Please select a folder within the device");
                    return new DynamicPath();
                }
            }
            subFolders.Reverse();
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
            }
        }

        private void UpdateDestinationTextBoxs()
        {
            form.SourceMusicPath.Text = GetPathAsText(Settings.SourceMusicDriversPath.GetPath());
            form.DestinationMusicPath.Text = GetPathAsText(Settings.DestinationMusicDriversPath.GetPath());
        }

        private void UpdateSourceTextBox()
        {
            form.SourceMusicPath.Text = GetPathAsText(Settings.SourceMusicDriversPath.GetPath());
        }

        public void SaveSettings()
        {
            XmlManager<Settings> xmlManager = new XmlManager<Settings>();
            xmlManager.Save("Settings.xml", Settings);
        }

        public void LoadSettings()
        {
            if (!File.Exists("Settings.xml")) { return; }
            XmlManager<Settings> xmlManager = new XmlManager<Settings>();
            Settings = xmlManager.Load("Settings.xml");
            UpdateSourceTextBox();
            UpdateDestinationTextBoxs();
        }

        private bool TryGetSelectedPath(out string path)
        {
            path = "";
            Folder folder = shell.BrowseForFolder(0, "בחר תיקיית מוזיקה", 0);
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
