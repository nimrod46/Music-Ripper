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
            this.SelectMusicSourceButton = new System.Windows.Forms.Button();
            this.SelectDestinatonMusicButton = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Load = new System.Windows.Forms.Button();
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
            this.tabPage2.Controls.Add(this.Load);
            this.tabPage2.Controls.Add(this.Save);
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
            this.SourceMusicPath.ReadOnly = true;
            this.SourceMusicPath.Size = new System.Drawing.Size(117, 20);
            this.SourceMusicPath.TabIndex = 5;
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
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(6, 58);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(240, 23);
            this.Save.TabIndex = 9;
            this.Save.Text = "שמור הגדרוח";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(6, 87);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(240, 23);
            this.Load.TabIndex = 10;
            this.Load.Text = "טען הגדרות";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Load_Click);
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
        private System.Windows.Forms.Button SelectDestinatonMusicButton;
        private System.Windows.Forms.Button SelectMusicSourceButton;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Load;
    }
}

