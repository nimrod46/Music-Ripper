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
                MessageBox.Show("לא היה ניתן למצוא את הנתיב שצוין", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                Console.WriteLine("No device found at: " + path);
                return "";
            }

            if (SubFolders != null && SubFolders.Length != 0)
            {
                folder = (Folder3)shell.NameSpace(path);
                List<FolderItem> items = folder.Items().Cast<FolderItem>().ToList();
                if(items.Count == 0)
                {
                    MessageBox.Show("יש לוודא שהמכשיר מוגדר למצב העברת קבצים", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
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
                    folderItem = items.FirstOrDefault(f => f.Name == item);
                    if(folderItem == null)
                    {
                        MessageBox.Show(string.Format("לא נמצאה תיקייה: {0}", item), "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        Console.WriteLine(@"Folder ""{0}"" was't not found", item);
                        return "";
                    }
                    folder = (Folder3)folderItem.GetFolder;
                }
            }
            
            return SettingsTab.RemoveBadStringFromPath(folder);
        }

        public class Settings
        {
            public DynamicPath SourceMusicDriversPath { get; set; }
            public DynamicPath DestinationMusicDriversPath { get; set; }

            public Settings()
            {
            }
        }
    }
}
