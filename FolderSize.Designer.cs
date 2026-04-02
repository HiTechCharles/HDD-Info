namespace HDD_Info
{
    partial class FolderSize
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PathLBL = new System.Windows.Forms.Label();
            this.PathTB = new System.Windows.Forms.TextBox();
            this.OptionsMST = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseForFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speakFolderInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectFolderFB = new System.Windows.Forms.FolderBrowserDialog();
            this.SizeLBL = new System.Windows.Forms.Label();
            this.SizeTB = new System.Windows.Forms.TextBox();
            this.FolderTimer = new System.Windows.Forms.Timer(this.components);
            this.FileCountLBL = new System.Windows.Forms.Label();
            this.FileCountTB = new System.Windows.Forms.TextBox();
            this.FolderCountLBL = new System.Windows.Forms.Label();
            this.FolderCountTB = new System.Windows.Forms.TextBox();
            this.PercentageLBL = new System.Windows.Forms.Label();
            this.PercentageTB = new System.Windows.Forms.TextBox();
            this.ScanProgressBar = new System.Windows.Forms.ProgressBar();
            this.OptionsMST.SuspendLayout();
            this.SuspendLayout();
            // 
            // PathLBL
            // 
            this.PathLBL.AutoSize = true;
            this.PathLBL.ForeColor = System.Drawing.Color.White;
            this.PathLBL.Location = new System.Drawing.Point(110, 93);
            this.PathLBL.Name = "PathLBL";
            this.PathLBL.Size = new System.Drawing.Size(77, 29);
            this.PathLBL.TabIndex = 1;
            this.PathLBL.Text = "&Path:";
            this.PathLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PathTB
            // 
            this.PathTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathTB.Location = new System.Drawing.Point(203, 61);
            this.PathTB.Multiline = true;
            this.PathTB.Name = "PathTB";
            this.PathTB.ReadOnly = true;
            this.PathTB.Size = new System.Drawing.Size(638, 79);
            this.PathTB.TabIndex = 2;
            // 
            // OptionsMST
            // 
            this.OptionsMST.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsMST.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionsMST.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.OptionsMST.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.OptionsMST.Location = new System.Drawing.Point(0, 0);
            this.OptionsMST.Name = "OptionsMST";
            this.OptionsMST.Size = new System.Drawing.Size(859, 37);
            this.OptionsMST.TabIndex = 0;
            this.OptionsMST.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseForFolderToolStripMenuItem,
            this.speakFolderInfoToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(117, 33);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // browseForFolderToolStripMenuItem
            // 
            this.browseForFolderToolStripMenuItem.Name = "browseForFolderToolStripMenuItem";
            this.browseForFolderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.browseForFolderToolStripMenuItem.Size = new System.Drawing.Size(389, 34);
            this.browseForFolderToolStripMenuItem.Text = "&Choose Folder...";
            this.browseForFolderToolStripMenuItem.Click += new System.EventHandler(this.browseForFolderToolStripMenuItem_Click);
            // 
            // speakFolderInfoToolStripMenuItem
            // 
            this.speakFolderInfoToolStripMenuItem.Name = "speakFolderInfoToolStripMenuItem";
            this.speakFolderInfoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.speakFolderInfoToolStripMenuItem.Size = new System.Drawing.Size(389, 34);
            this.speakFolderInfoToolStripMenuItem.Text = "&Speak Folder Info";
            this.speakFolderInfoToolStripMenuItem.Click += new System.EventHandler(this.speakFolderInfoToolStripMenuItem_Click);
            // 
            // SelectFolderFB
            // 
            this.SelectFolderFB.Description = "Choose a folder to Get Size on Disk";
            this.SelectFolderFB.ShowNewFolderButton = false;
            // 
            // SizeLBL
            // 
            this.SizeLBL.AutoSize = true;
            this.SizeLBL.ForeColor = System.Drawing.Color.White;
            this.SizeLBL.Location = new System.Drawing.Point(116, 168);
            this.SizeLBL.Name = "SizeLBL";
            this.SizeLBL.Size = new System.Drawing.Size(71, 29);
            this.SizeLBL.TabIndex = 3;
            this.SizeLBL.Text = "&Size:";
            this.SizeLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SizeTB
            // 
            this.SizeTB.Location = new System.Drawing.Point(203, 161);
            this.SizeTB.Name = "SizeTB";
            this.SizeTB.ReadOnly = true;
            this.SizeTB.Size = new System.Drawing.Size(165, 36);
            this.SizeTB.TabIndex = 4;
            // 
            // FolderTimer
            // 
            this.FolderTimer.Enabled = true;
            this.FolderTimer.Interval = 1000;
            this.FolderTimer.Tick += new System.EventHandler(this.FolderTimer_Tick);
            // 
            // FileCountLBL
            // 
            this.FileCountLBL.AutoSize = true;
            this.FileCountLBL.ForeColor = System.Drawing.Color.White;
            this.FileCountLBL.Location = new System.Drawing.Point(45, 217);
            this.FileCountLBL.Name = "FileCountLBL";
            this.FileCountLBL.Size = new System.Drawing.Size(142, 29);
            this.FileCountLBL.TabIndex = 5;
            this.FileCountLBL.Text = "File &Count:";
            this.FileCountLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FileCountTB
            // 
            this.FileCountTB.Location = new System.Drawing.Point(203, 214);
            this.FileCountTB.Name = "FileCountTB";
            this.FileCountTB.ReadOnly = true;
            this.FileCountTB.Size = new System.Drawing.Size(165, 36);
            this.FileCountTB.TabIndex = 6;
            // 
            // FolderCountLBL
            // 
            this.FolderCountLBL.AutoSize = true;
            this.FolderCountLBL.ForeColor = System.Drawing.Color.White;
            this.FolderCountLBL.Location = new System.Drawing.Point(474, 224);
            this.FolderCountLBL.Name = "FolderCountLBL";
            this.FolderCountLBL.Size = new System.Drawing.Size(175, 29);
            this.FolderCountLBL.TabIndex = 9;
            this.FolderCountLBL.Text = "Fol&der Count:";
            this.FolderCountLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FolderCountTB
            // 
            this.FolderCountTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderCountTB.Location = new System.Drawing.Point(674, 217);
            this.FolderCountTB.Name = "FolderCountTB";
            this.FolderCountTB.ReadOnly = true;
            this.FolderCountTB.Size = new System.Drawing.Size(165, 36);
            this.FolderCountTB.TabIndex = 10;
            // 
            // PercentageLBL
            // 
            this.PercentageLBL.AutoSize = true;
            this.PercentageLBL.ForeColor = System.Drawing.Color.White;
            this.PercentageLBL.Location = new System.Drawing.Point(492, 164);
            this.PercentageLBL.Name = "PercentageLBL";
            this.PercentageLBL.Size = new System.Drawing.Size(157, 29);
            this.PercentageLBL.TabIndex = 7;
            this.PercentageLBL.Text = "Pe&rcentage:";
            this.PercentageLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PercentageTB
            // 
            this.PercentageTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PercentageTB.Location = new System.Drawing.Point(674, 161);
            this.PercentageTB.Name = "PercentageTB";
            this.PercentageTB.ReadOnly = true;
            this.PercentageTB.Size = new System.Drawing.Size(167, 36);
            this.PercentageTB.TabIndex = 8;
            // 
            // ScanProgressBar
            // 
            this.ScanProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScanProgressBar.Location = new System.Drawing.Point(12, 277);
            this.ScanProgressBar.Name = "ScanProgressBar";
            this.ScanProgressBar.Size = new System.Drawing.Size(829, 30);
            this.ScanProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ScanProgressBar.TabIndex = 11;
            // 
            // FolderSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(859, 344);
            this.Controls.Add(this.ScanProgressBar);
            this.Controls.Add(this.PercentageTB);
            this.Controls.Add(this.PercentageLBL);
            this.Controls.Add(this.FolderCountTB);
            this.Controls.Add(this.FolderCountLBL);
            this.Controls.Add(this.FileCountTB);
            this.Controls.Add(this.FileCountLBL);
            this.Controls.Add(this.SizeTB);
            this.Controls.Add(this.SizeLBL);
            this.Controls.Add(this.PathTB);
            this.Controls.Add(this.PathLBL);
            this.Controls.Add(this.OptionsMST);
            this.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.MainMenuStrip = this.OptionsMST;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MinimumSize = new System.Drawing.Size(875, 391);
            this.Name = "FolderSize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Size of a Folder on Disk";
            this.OptionsMST.ResumeLayout(false);
            this.OptionsMST.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PathLBL;
        private System.Windows.Forms.TextBox PathTB;
        private System.Windows.Forms.MenuStrip OptionsMST;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseForFolderToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog SelectFolderFB;
        private System.Windows.Forms.Label SizeLBL;
        private System.Windows.Forms.TextBox SizeTB;
        private System.Windows.Forms.Timer FolderTimer;
        private System.Windows.Forms.ToolStripMenuItem speakFolderInfoToolStripMenuItem;
        private System.Windows.Forms.Label FileCountLBL;
        private System.Windows.Forms.TextBox FileCountTB;
        private System.Windows.Forms.Label FolderCountLBL;
        private System.Windows.Forms.TextBox FolderCountTB;
        private System.Windows.Forms.Label PercentageLBL;
        private System.Windows.Forms.TextBox PercentageTB;
        private System.Windows.Forms.ProgressBar ScanProgressBar;
    }
}