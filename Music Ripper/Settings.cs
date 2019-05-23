using Shell32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Music_Ripper
{
    public struct DynamicPath
    {
        public string RootDrivePath { get; set; }
        public string[] SubFolders { get; set; }

        public string GetPath()
        {
            Shell shell = new Shell();
            string path = RootDrivePath;
            Folder3 folder = (Folder3)shell.NameSpace(path);
            if (string.IsNullOrWhiteSpace(path))
            {
                return "";
            }

            if (folder == null)
            {
                Console.WriteLine("No device found at: " + path);
                return "";
            }
            if (SubFolders != null && SubFolders.Length != 0)
            {
                folder = (Folder3)shell.NameSpace(path);
                List<FolderItem> items = folder.Items().Cast<FolderItem>().ToList();
                if(items.Count == 0)
                {
                    Console.WriteLine("Make sure the device is set to \"transfer file mode\"");
                    return "";
                }
                string subFolder = SubFolders[0];
                FolderItem folderItem = items.FirstOrDefault(f => f.Name == subFolder);
                if (folderItem == null)
                {
                    folder = (Folder3)items[0].GetFolder;
                }
               
                foreach (string item in SubFolders)
                {
                    items = folder.Items().Cast<FolderItem>().ToList();
                    folderItem = items.First(f => f.Name == item);
                    folder = (Folder3)folderItem.GetFolder;
                }
            }
            
            return SettingsTab.RemoveBadStringFromPath(folder);
        }

        public class Settings
        {
            private DynamicPath sourceMusicDriversPath;
            private DynamicPath destinationMusicDriversPath;
            public Settings()
            {
            }

            public DynamicPath SourceMusicDriversPath
            {
                get => sourceMusicDriversPath;
                set
                {
                    sourceMusicDriversPath = value;
                }
            }

            public DynamicPath DestinationMusicDriversPath
            {
                get => destinationMusicDriversPath;
                set
                {
                    destinationMusicDriversPath = value;
                }
            }

        }
    }
}
