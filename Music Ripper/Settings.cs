using Shell32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Music_Ripper
{
    public class Settings
    {
        private string sourceMusicDriversPath;
        private string destinationMusicDriversPath;
        public Settings()
        {
        }

        /*
        [XmlIgnore]
        public Folder SourceMusicDriversPath
        {
            get => shell.NameSpace(sourceMusicDriversPath);
            set
            {
                sourceMusicDriversPath = (value as Folder3).Self.Path;
                if ((value as Folder3).Self.IsFileSystem)
                {
                    sourceMusicTextPath.Text = (value as Folder3).Self.Path;
                }
                else
                {
                    sourceMusicTextPath.Text = (value as Folder3).Self.Name;
                }
            }
        }

        [XmlIgnore]
        public Folder DestinationMusicDriversPath
        {
            get => shell.NameSpace(destinationMusicDriversPath);
            set
            {
                destinationMusicDriversPath = (value as Folder3).Self.Path;
                if ((value as Folder3).Self.IsFileSystem)
                {
                    destinationMusicTextPath.Text = (value as Folder3).Self.Path;
                }
                else
                {
                    destinationMusicTextPath.Text = (value as Folder3).Self.Name;
                }
            }
        }
        */

        public string SourceMusicDriversPath
        {
            get => sourceMusicDriversPath;
            set
            {
                sourceMusicDriversPath = value;
            }
        }

        public string DestinationMusicDriversPath
        {
            get => destinationMusicDriversPath;
            set
            {
                destinationMusicDriversPath = value;
            }
        }

    }
}
