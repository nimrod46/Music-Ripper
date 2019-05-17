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
            this.DestinationMusicPath = new System.Windows.Forms.TextBox();
            this.SourceMusicPath = new System.Windows.Forms.TextBox();
            this.Refresh = new System.Windows.Forms.Button();
            this.DestinationMusicDrives = new System.Windows.Forms.ListBox();
            this.SourceMusicDrivers = new System.Windows.Forms.ListBox();
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
            this.LoadMusic.Location = new System.Drawing.Point(6, 6);
            this.LoadMusic.Name = "LoadMusic";
            this.LoadMusic.Size = new System.Drawing.Size(75, 23);
            this.LoadMusic.TabIndex = 0;
            this.LoadMusic.Text = "טען מוזיקה";
            this.LoadMusic.UseVisualStyleBackColor = true;
            this.LoadMusic.Click += new System.EventHandler(this.LoadMusic_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DestinationMusicPath);
            this.tabPage2.Controls.Add(this.SourceMusicPath);
            this.tabPage2.Controls.Add(this.DestinationMusicDrives);
            this.tabPage2.Controls.Add(this.SourceMusicDrivers);
            this.tabPage2.Controls.Add(this.Refresh);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DestinationMusicPath
            // 
            this.DestinationMusicPath.Location = new System.Drawing.Point(129, 68);
            this.DestinationMusicPath.Name = "DestinationMusicPath";
            this.DestinationMusicPath.ReadOnly = true;
            this.DestinationMusicPath.Size = new System.Drawing.Size(117, 20);
            this.DestinationMusicPath.TabIndex = 6;
            // 
            // SourceMusicPath
            // 
            this.SourceMusicPath.Location = new System.Drawing.Point(6, 68);
            this.SourceMusicPath.Name = "SourceMusicPath";
            this.SourceMusicPath.ReadOnly = true;
            this.SourceMusicPath.Size = new System.Drawing.Size(117, 20);
            this.SourceMusicPath.TabIndex = 5;
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(253, 6);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(75, 23);
            this.Refresh.TabIndex = 1;
            this.Refresh.Text = "רענן";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // DestinationMusicDrives
            // 
            this.DestinationMusicDrives.FormattingEnabled = true;
            this.DestinationMusicDrives.Location = new System.Drawing.Point(127, 6);
            this.DestinationMusicDrives.Name = "DestinationMusicDrives";
            this.DestinationMusicDrives.Size = new System.Drawing.Size(120, 56);
            this.DestinationMusicDrives.TabIndex = 4;
            this.DestinationMusicDrives.DoubleClick += new System.EventHandler(this.DestinationMusicDrives_DoubleClick);
            // 
            // SourceMusicDrivers
            // 
            this.SourceMusicDrivers.FormattingEnabled = true;
            this.SourceMusicDrivers.Location = new System.Drawing.Point(3, 6);
            this.SourceMusicDrivers.Name = "SourceMusicDrivers";
            this.SourceMusicDrivers.Size = new System.Drawing.Size(120, 56);
            this.SourceMusicDrivers.TabIndex = 3;
            this.SourceMusicDrivers.DoubleClick += new System.EventHandler(this.SourceMusicDrivers_DoubleClick);
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox DestinationMusicPath;
        private System.Windows.Forms.TextBox SourceMusicPath;
        private System.Windows.Forms.Button LoadMusic;
        private System.Windows.Forms.ListBox DestinationMusicDrives;
        private System.Windows.Forms.ListBox SourceMusicDrivers;
        public System.Windows.Forms.Button Refresh;
    }
}

