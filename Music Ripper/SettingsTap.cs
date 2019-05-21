using Shell32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                UpdateTextBoxs();
            }
            else
            {
                Settings = new Settings();
            }

        }

        public void UpdateMusicPath(Action<string> setting, bool canBeNoneFileStem)
        {
            if (TryGetSelectedPath(canBeNoneFileStem, out string path))
            {
                setting(path);
                UpdateTextBoxs();
            }
        }

        private void UpdateTextBoxs()
        {
            form.SourceMusicPath.Text = GetPathAsText(Settings.SourceMusicDriversPath);
            form.DestinationMusicPath.Text = GetPathAsText(Settings.DestinationMusicDriversPath);
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
        }

        private bool TryGetSelectedPath(bool canBeNoneFileSystem, out string path)
        {
            path = "";
            Folder folder = shell.BrowseForFolder(0, "Select folder", 0);
            if (folder != null)
            {
                path = (folder as Folder3).Self.Path;
                if (!(folder as Folder3).Self.IsFileSystem && path.Contains("SID-"))
                {
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


        private string GetPathAsText(string path)
        {
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

    }
}
