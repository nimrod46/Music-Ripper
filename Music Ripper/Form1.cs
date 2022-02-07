using Microsoft.Win32.SafeHandles;
using Shell32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace Music_Ripper
{
    public partial class Form1 : Form
    { 
        private Shell shell;
        public SettingsTab settingsTab;
        private ProgramTab programTab;
        public Form1()
        {
            InitializeComponent();
            shell = new Shell();
            settingsTab = new SettingsTab(this);
            programTab = new ProgramTab(this);
            Console.WriteLine("init");
            Console.WriteLine(shell);
            Console.WriteLine(settingsTab);
            Console.WriteLine(programTab);
        }

        private void LoadMusic_Click(object sender, EventArgs e)
        {
            if (programTab.TryGetPathWithMp3Files(settingsTab.Settings.SourceMusicDriversPath.GetPath(), out string sourcePath)){
                programTab.SetMusicTag(sourcePath);
                programTab.MoveMusic(sourcePath, settingsTab.Settings.DestinationMusicDriversPath.GetPath());
            }
        }

        private void SelectMusicSourceButton_Click(object sender, EventArgs e)
        {
            settingsTab.UpdateSourceMusicPath();
        }

        private void SelectDestinatonMusicButton_Click(object sender, EventArgs e)
        {
            settingsTab.UpdateDestinationMusicPath();
        }      

        private void Save_Click(object sender, EventArgs e)
        {
            settingsTab.SaveSettings();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            settingsTab.LoadSettings();   
        }

        private void ChangeFileTag_Click(object sender, EventArgs e)
        {
            if (programTab.TryGetPathWithMp3Files(settingsTab.Settings.SourceMusicDriversPath.GetPath(), out string sourcePath))
            {
                programTab.SetMusicTag(sourcePath);
            }
        }

        private void MoveFiles_Click(object sender, EventArgs e)
        {
            if (programTab.TryGetPathWithMp3Files(settingsTab.Settings.SourceMusicDriversPath.GetPath(), out string sourcePath))
            {
                programTab.MoveMusic(sourcePath, settingsTab.Settings.DestinationMusicDriversPath.GetPath());
            }
        }
    }
}
