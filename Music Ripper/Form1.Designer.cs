namespace Music_Ripper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LoadMusic = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LoadSettings = new System.Windows.Forms.Button();
            this.SaveSettings = new System.Windows.Forms.Button();
            this.SelectDestinatonMusicButton = new System.Windows.Forms.Button();
            this.SelectMusicSourceButton = new System.Windows.Forms.Button();
            this.DestinationMusicPath = new System.Windows.Forms.TextBox();
            this.SourceMusicPath = new System.Windows.Forms.TextBox();
            this.ChangeFileTag = new System.Windows.Forms.Button();
            this.MoveFiles = new System.Windows.Forms.Button();
            this.MusicTagName = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.MusicTagName);
            this.tabPage1.Controls.Add(this.MoveFiles);
            this.tabPage1.Controls.Add(this.ChangeFileTag);
            this.tabPage1.Controls.Add(this.LoadMusic);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LoadMusic
            // 
            this.LoadMusic.Location = new System.Drawing.Point(6, 22);
            this.LoadMusic.Name = "LoadMusic";
            this.LoadMusic.Size = new System.Drawing.Size(75, 23);
            this.LoadMusic.TabIndex = 0;
            this.LoadMusic.Text = "טען מוזיקה";
            this.LoadMusic.UseVisualStyleBackColor = true;
            this.LoadMusic.Click += new System.EventHandler(this.LoadMusic_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LoadSettings);
            this.tabPage2.Controls.Add(this.SaveSettings);
            this.tabPage2.Controls.Add(this.SelectDestinatonMusicButton);
            this.tabPage2.Controls.Add(this.SelectMusicSourceButton);
            this.tabPage2.Controls.Add(this.DestinationMusicPath);
            this.tabPage2.Controls.Add(this.SourceMusicPath);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LoadSettings
            // 
            this.LoadSettings.Location = new System.Drawing.Point(6, 87);
            this.LoadSettings.Name = "LoadSettings";
            this.LoadSettings.Size = new System.Drawing.Size(240, 23);
            this.LoadSettings.TabIndex = 10;
            this.LoadSettings.Text = "טען הגדרות";
            this.LoadSettings.UseVisualStyleBackColor = true;
            this.LoadSettings.Click += new System.EventHandler(this.Load_Click);
            // 
            // SaveSettings
            // 
            this.SaveSettings.Location = new System.Drawing.Point(6, 58);
            this.SaveSettings.Name = "SaveSettings";
            this.SaveSettings.Size = new System.Drawing.Size(240, 23);
            this.SaveSettings.TabIndex = 9;
            this.SaveSettings.Text = "שמור הגדרוח";
            this.SaveSettings.UseVisualStyleBackColor = true;
            this.SaveSettings.Click += new System.EventHandler(this.Save_Click);
            // 
            // SelectDestinatonMusicButton
            // 
            this.SelectDestinatonMusicButton.Location = new System.Drawing.Point(129, 3);
            this.SelectDestinatonMusicButton.Name = "SelectDestinatonMusicButton";
            this.SelectDestinatonMusicButton.Size = new System.Drawing.Size(117, 23);
            this.SelectDestinatonMusicButton.TabIndex = 8;
            this.SelectDestinatonMusicButton.Text = "בחירת יעד קבצים";
            this.SelectDestinatonMusicButton.UseVisualStyleBackColor = true;
            this.SelectDestinatonMusicButton.Click += new System.EventHandler(this.SelectDestinatonMusicButton_Click);
            // 
            // SelectMusicSourceButton
            // 
            this.SelectMusicSourceButton.Location = new System.Drawing.Point(6, 3);
            this.SelectMusicSourceButton.Name = "SelectMusicSourceButton";
            this.SelectMusicSourceButton.Size = new System.Drawing.Size(117, 23);
            this.SelectMusicSourceButton.TabIndex = 7;
            this.SelectMusicSourceButton.Text = "בחירת מקור קבצים";
            this.SelectMusicSourceButton.UseVisualStyleBackColor = true;
            this.SelectMusicSourceButton.Click += new System.EventHandler(this.SelectMusicSourceButton_Click);
            // 
            // DestinationMusicPath
            // 
            this.DestinationMusicPath.Location = new System.Drawing.Point(129, 32);
            this.DestinationMusicPath.Name = "DestinationMusicPath";
            this.DestinationMusicPath.ReadOnly = true;
            this.DestinationMusicPath.Size = new System.Drawing.Size(117, 20);
            this.DestinationMusicPath.TabIndex = 6;
            // 
            // SourceMusicPath
            // 
            this.SourceMusicPath.Location = new System.Drawing.Point(6, 32);
            this.SourceMusicPath.Name = "SourceMusicPath";
            this.SourceMusicPath.Size = new System.Drawing.Size(117, 20);
            this.SourceMusicPath.TabIndex = 5;
            // 
            // ChangeFileTag
            // 
            this.ChangeFileTag.Location = new System.Drawing.Point(106, 6);
            this.ChangeFileTag.Name = "ChangeFileTag";
            this.ChangeFileTag.Size = new System.Drawing.Size(75, 23);
            this.ChangeFileTag.TabIndex = 2;
            this.ChangeFileTag.Text = "שנה שם";
            this.ChangeFileTag.UseVisualStyleBackColor = true;
            this.ChangeFileTag.Click += new System.EventHandler(this.ChangeFileTag_Click);
            // 
            // MoveFiles
            // 
            this.MoveFiles.Location = new System.Drawing.Point(106, 35);
            this.MoveFiles.Name = "MoveFiles";
            this.MoveFiles.Size = new System.Drawing.Size(75, 35);
            this.MoveFiles.TabIndex = 3;
            this.MoveFiles.Text = "הזז קבצים למיקום יעד";
            this.MoveFiles.UseVisualStyleBackColor = true;
            this.MoveFiles.Click += new System.EventHandler(this.MoveFiles_Click);
            // 
            // MusicTagName
            // 
            this.MusicTagName.Location = new System.Drawing.Point(187, 6);
            this.MusicTagName.Name = "MusicTagName";
            this.MusicTagName.Size = new System.Drawing.Size(100, 20);
            this.MusicTagName.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(293, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox3.Size = new System.Drawing.Size(65, 20);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "שם אלבום:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button LoadMusic;
        private System.Windows.Forms.Button SelectDestinatonMusicButton;
        private System.Windows.Forms.Button SelectMusicSourceButton;
        private System.Windows.Forms.Button SaveSettings;
        private System.Windows.Forms.Button LoadSettings;
        public System.Windows.Forms.TextBox DestinationMusicPath;
        public System.Windows.Forms.TextBox SourceMusicPath;
        public System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button MoveFiles;
        private System.Windows.Forms.Button ChangeFileTag;
        public System.Windows.Forms.TextBox MusicTagName;
    }
}

