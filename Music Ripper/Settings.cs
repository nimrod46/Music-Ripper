using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Music_Ripper
{
    class Settings
    {
        private string sourceMusicDriversPath;
        private string destinationMusicDriversPath;
        private TextBox sourceMusicTextPath;
        private TextBox destinationMusicTextPath;
        public Settings(TextBox sourceMusicTextPath, TextBox destinationMusicTextPath)
        {
            this.sourceMusicTextPath = sourceMusicTextPath;
            this.destinationMusicTextPath = destinationMusicTextPath;
        }

        public string SourceMusicDriversPath
        {
            get => sourceMusicDriversPath;
            set
            {
                sourceMusicDriversPath = value;
                sourceMusicTextPath.Text = value;
            }
        }
        public string DestinationMusicDriversPath
        {
            get => destinationMusicDriversPath;
            set
            {
                destinationMusicDriversPath = value;
                destinationMusicTextPath.Text = value;
            }
        }
    }
}
