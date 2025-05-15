namespace HDD_Info
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
            this.components = new System.ComponentModel.Container();
            this.DriveLBL = new System.Windows.Forms.Label();
            this.FreeLBL = new System.Windows.Forms.Label();
            this.UsedLBL = new System.Windows.Forms.Label();
            this.TotalLBL = new System.Windows.Forms.Label();
            this.PercentUsedLBL = new System.Windows.Forms.Label();
            this.DriveCB = new System.Windows.Forms.ComboBox();
            this.FreeTB = new System.Windows.Forms.TextBox();
            this.PercentUsedTB = new System.Windows.Forms.TextBox();
            this.UsedTB = new System.Windows.Forms.TextBox();
            this.TotalTB = new System.Windows.Forms.TextBox();
            this.UserNameTB = new System.Windows.Forms.TextBox();
            this.ComputerNameTB = new System.Windows.Forms.TextBox();
            this.CPUTB = new System.Windows.Forms.TextBox();
            this.ComputerNameLBL = new System.Windows.Forms.Label();
            this.UpTimeLBL = new System.Windows.Forms.Label();
            this.UserNameLBL = new System.Windows.Forms.Label();
            this.CPULBL = new System.Windows.Forms.Label();
            this.MemoryTB = new System.Windows.Forms.TextBox();
            this.MemoryLBL = new System.Windows.Forms.Label();
            this.InfoTimer = new System.Windows.Forms.Timer(this.components);
            this.DriveTimer = new System.Windows.Forms.Timer(this.components);
            this.OptionsMenu = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speakPCInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speakCurrentDriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpTimeTB = new System.Windows.Forms.TextBox();
            this.OptionsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // DriveLBL
            // 
            this.DriveLBL.AutoSize = true;
            this.DriveLBL.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.DriveLBL.Location = new System.Drawing.Point(51, 69);
            this.DriveLBL.Name = "DriveLBL";
            this.DriveLBL.Size = new System.Drawing.Size(155, 55);
            this.DriveLBL.TabIndex = 0;
            this.DriveLBL.Text = "&Drive:";
            this.DriveLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FreeLBL
            // 
            this.FreeLBL.AutoSize = true;
            this.FreeLBL.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FreeLBL.Location = new System.Drawing.Point(60, 139);
            this.FreeLBL.Name = "FreeLBL";
            this.FreeLBL.Size = new System.Drawing.Size(141, 55);
            this.FreeLBL.TabIndex = 2;
            this.FreeLBL.Text = "&Free:";
            this.FreeLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UsedLBL
            // 
            this.UsedLBL.AutoSize = true;
            this.UsedLBL.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.UsedLBL.Location = new System.Drawing.Point(51, 308);
            this.UsedLBL.Name = "UsedLBL";
            this.UsedLBL.Size = new System.Drawing.Size(155, 55);
            this.UsedLBL.TabIndex = 6;
            this.UsedLBL.Text = "&Used:";
            this.UsedLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TotalLBL
            // 
            this.TotalLBL.AutoSize = true;
            this.TotalLBL.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TotalLBL.Location = new System.Drawing.Point(52, 379);
            this.TotalLBL.Name = "TotalLBL";
            this.TotalLBL.Size = new System.Drawing.Size(149, 55);
            this.TotalLBL.TabIndex = 8;
            this.TotalLBL.Text = "&Total:";
            // 
            // PercentUsedLBL
            // 
            this.PercentUsedLBL.AutoSize = true;
            this.PercentUsedLBL.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.PercentUsedLBL.Location = new System.Drawing.Point(23, 224);
            this.PercentUsedLBL.Name = "PercentUsedLBL";
            this.PercentUsedLBL.Size = new System.Drawing.Size(213, 55);
            this.PercentUsedLBL.TabIndex = 4;
            this.PercentUsedLBL.Text = "% Us&ed:";
            this.PercentUsedLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DriveCB
            // 
            this.DriveCB.AccessibleDescription = "";
            this.DriveCB.AccessibleName = "Choose a drive to see its statistics";
            this.DriveCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DriveCB.FormattingEnabled = true;
            this.DriveCB.Location = new System.Drawing.Point(183, 57);
            this.DriveCB.Name = "DriveCB";
            this.DriveCB.Size = new System.Drawing.Size(241, 63);
            this.DriveCB.TabIndex = 1;
            // 
            // FreeTB
            // 
            this.FreeTB.AccessibleName = "Free Space";
            this.FreeTB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.FreeTB.Location = new System.Drawing.Point(183, 136);
            this.FreeTB.Name = "FreeTB";
            this.FreeTB.ReadOnly = true;
            this.FreeTB.Size = new System.Drawing.Size(241, 62);
            this.FreeTB.TabIndex = 3;
            // 
            // PercentUsedTB
            // 
            this.PercentUsedTB.AccessibleName = "Percent used";
            this.PercentUsedTB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PercentUsedTB.Location = new System.Drawing.Point(183, 217);
            this.PercentUsedTB.Name = "PercentUsedTB";
            this.PercentUsedTB.ReadOnly = true;
            this.PercentUsedTB.Size = new System.Drawing.Size(241, 62);
            this.PercentUsedTB.TabIndex = 5;
            // 
            // UsedTB
            // 
            this.UsedTB.AccessibleName = "Used Space";
            this.UsedTB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.UsedTB.Location = new System.Drawing.Point(183, 298);
            this.UsedTB.Name = "UsedTB";
            this.UsedTB.ReadOnly = true;
            this.UsedTB.Size = new System.Drawing.Size(241, 62);
            this.UsedTB.TabIndex = 7;
            // 
            // TotalTB
            // 
            this.TotalTB.AccessibleName = "Total Space";
            this.TotalTB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TotalTB.Location = new System.Drawing.Point(183, 379);
            this.TotalTB.Name = "TotalTB";
            this.TotalTB.ReadOnly = true;
            this.TotalTB.Size = new System.Drawing.Size(241, 62);
            this.TotalTB.TabIndex = 9;
            // 
            // UserNameTB
            // 
            this.UserNameTB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.UserNameTB.Location = new System.Drawing.Point(790, 305);
            this.UserNameTB.Name = "UserNameTB";
            this.UserNameTB.ReadOnly = true;
            this.UserNameTB.Size = new System.Drawing.Size(347, 62);
            this.UserNameTB.TabIndex = 17;
            // 
            // ComputerNameTB
            // 
            this.ComputerNameTB.AccessibleName = "Computer Name";
            this.ComputerNameTB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ComputerNameTB.Location = new System.Drawing.Point(790, 224);
            this.ComputerNameTB.Name = "ComputerNameTB";
            this.ComputerNameTB.ReadOnly = true;
            this.ComputerNameTB.Size = new System.Drawing.Size(347, 62);
            this.ComputerNameTB.TabIndex = 15;
            // 
            // CPUTB
            // 
            this.CPUTB.AccessibleDescription = "CPU load";
            this.CPUTB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CPUTB.Location = new System.Drawing.Point(790, 62);
            this.CPUTB.Name = "CPUTB";
            this.CPUTB.ReadOnly = true;
            this.CPUTB.Size = new System.Drawing.Size(347, 62);
            this.CPUTB.TabIndex = 11;
            // 
            // ComputerNameLBL
            // 
            this.ComputerNameLBL.AutoSize = true;
            this.ComputerNameLBL.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ComputerNameLBL.Location = new System.Drawing.Point(485, 227);
            this.ComputerNameLBL.Name = "ComputerNameLBL";
            this.ComputerNameLBL.Size = new System.Drawing.Size(405, 55);
            this.ComputerNameLBL.TabIndex = 14;
            this.ComputerNameLBL.Text = "Computer &Name:";
            this.ComputerNameLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UpTimeLBL
            // 
            this.UpTimeLBL.AccessibleName = "Up Time";
            this.UpTimeLBL.AutoSize = true;
            this.UpTimeLBL.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.UpTimeLBL.Location = new System.Drawing.Point(606, 393);
            this.UpTimeLBL.Name = "UpTimeLBL";
            this.UpTimeLBL.Size = new System.Drawing.Size(226, 55);
            this.UpTimeLBL.TabIndex = 18;
            this.UpTimeLBL.Text = "U&p Time:";
            // 
            // UserNameLBL
            // 
            this.UserNameLBL.AccessibleName = "Current User";
            this.UserNameLBL.AutoSize = true;
            this.UserNameLBL.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.UserNameLBL.Location = new System.Drawing.Point(539, 312);
            this.UserNameLBL.Name = "UserNameLBL";
            this.UserNameLBL.Size = new System.Drawing.Size(326, 55);
            this.UserNameLBL.TabIndex = 16;
            this.UserNameLBL.Text = "Current U&ser:";
            this.UserNameLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CPULBL
            // 
            this.CPULBL.AutoSize = true;
            this.CPULBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.CPULBL.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CPULBL.Location = new System.Drawing.Point(578, 69);
            this.CPULBL.Name = "CPULBL";
            this.CPULBL.Size = new System.Drawing.Size(269, 55);
            this.CPULBL.TabIndex = 10;
            this.CPULBL.Text = "&CPU &Load:";
            this.CPULBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MemoryTB
            // 
            this.MemoryTB.AccessibleName = "Free and Total memory";
            this.MemoryTB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.MemoryTB.Location = new System.Drawing.Point(790, 143);
            this.MemoryTB.Name = "MemoryTB";
            this.MemoryTB.ReadOnly = true;
            this.MemoryTB.Size = new System.Drawing.Size(347, 62);
            this.MemoryTB.TabIndex = 13;
            // 
            // MemoryLBL
            // 
            this.MemoryLBL.AutoSize = true;
            this.MemoryLBL.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MemoryLBL.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MemoryLBL.Location = new System.Drawing.Point(614, 150);
            this.MemoryLBL.Name = "MemoryLBL";
            this.MemoryLBL.Size = new System.Drawing.Size(218, 55);
            this.MemoryLBL.TabIndex = 12;
            this.MemoryLBL.Text = "&Memory:";
            this.MemoryLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InfoTimer
            // 
            this.InfoTimer.Enabled = true;
            this.InfoTimer.Interval = 1000;
            this.InfoTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // DriveTimer
            // 
            this.DriveTimer.Enabled = true;
            this.DriveTimer.Interval = 1000;
            this.DriveTimer.Tick += new System.EventHandler(this.DriveTimer_Tick);
            // 
            // OptionsMenu
            // 
            this.OptionsMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.OptionsMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.OptionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.OptionsMenu.Location = new System.Drawing.Point(0, 0);
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.Size = new System.Drawing.Size(1149, 45);
            this.OptionsMenu.TabIndex = 20;
            this.OptionsMenu.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.speakPCInfoToolStripMenuItem,
            this.speakCurrentDriToolStripMenuItem,
            this.eXitToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(127, 41);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(467, 46);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // speakPCInfoToolStripMenuItem
            // 
            this.speakPCInfoToolStripMenuItem.Name = "speakPCInfoToolStripMenuItem";
            this.speakPCInfoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.speakPCInfoToolStripMenuItem.Size = new System.Drawing.Size(467, 46);
            this.speakPCInfoToolStripMenuItem.Text = "Speak Computer &Info";
            this.speakPCInfoToolStripMenuItem.Click += new System.EventHandler(this.SpeakPCInfoToolStripMenuItem_Click);
            // 
            // speakCurrentDriToolStripMenuItem
            // 
            this.speakCurrentDriToolStripMenuItem.Name = "speakCurrentDriToolStripMenuItem";
            this.speakCurrentDriToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.speakCurrentDriToolStripMenuItem.Size = new System.Drawing.Size(467, 46);
            this.speakCurrentDriToolStripMenuItem.Text = "Speak Selected &Drive";
            this.speakCurrentDriToolStripMenuItem.Click += new System.EventHandler(this.SpeakCurrentDriToolStripMenuItem_Click);
            // 
            // eXitToolStripMenuItem
            // 
            this.eXitToolStripMenuItem.Name = "eXitToolStripMenuItem";
            this.eXitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.eXitToolStripMenuItem.Size = new System.Drawing.Size(467, 46);
            this.eXitToolStripMenuItem.Text = "E&xit";
            this.eXitToolStripMenuItem.Click += new System.EventHandler(this.EXitToolStripMenuItem_Click);
            // 
            // UpTimeTB
            // 
            this.UpTimeTB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.UpTimeTB.Location = new System.Drawing.Point(790, 386);
            this.UpTimeTB.Name = "UpTimeTB";
            this.UpTimeTB.ReadOnly = true;
            this.UpTimeTB.Size = new System.Drawing.Size(347, 62);
            this.UpTimeTB.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(29F, 55F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1149, 444);
            this.Controls.Add(this.MemoryTB);
            this.Controls.Add(this.MemoryLBL);
            this.Controls.Add(this.UpTimeTB);
            this.Controls.Add(this.UserNameTB);
            this.Controls.Add(this.ComputerNameTB);
            this.Controls.Add(this.CPUTB);
            this.Controls.Add(this.ComputerNameLBL);
            this.Controls.Add(this.UpTimeLBL);
            this.Controls.Add(this.UserNameLBL);
            this.Controls.Add(this.CPULBL);
            this.Controls.Add(this.TotalTB);
            this.Controls.Add(this.UsedTB);
            this.Controls.Add(this.PercentUsedTB);
            this.Controls.Add(this.FreeTB);
            this.Controls.Add(this.DriveCB);
            this.Controls.Add(this.PercentUsedLBL);
            this.Controls.Add(this.TotalLBL);
            this.Controls.Add(this.UsedLBL);
            this.Controls.Add(this.FreeLBL);
            this.Controls.Add(this.DriveLBL);
            this.Controls.Add(this.OptionsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.OptionsMenu;
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "Form1";
            this.Tag = "HDD Info by HiTechCharles";
            this.Text = "Hard Drive Info";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.OptionsMenu.ResumeLayout(false);
            this.OptionsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DriveLBL;
        private System.Windows.Forms.Label FreeLBL;
        private System.Windows.Forms.Label UsedLBL;
        private System.Windows.Forms.Label TotalLBL;
        private System.Windows.Forms.Label PercentUsedLBL;
        private System.Windows.Forms.ComboBox DriveCB;
        private System.Windows.Forms.TextBox FreeTB;
        private System.Windows.Forms.TextBox PercentUsedTB;
        private System.Windows.Forms.TextBox UsedTB;
        private System.Windows.Forms.TextBox TotalTB;
        private System.Windows.Forms.TextBox UserNameTB;
        private System.Windows.Forms.TextBox ComputerNameTB;
        private System.Windows.Forms.TextBox CPUTB;
        private System.Windows.Forms.Label ComputerNameLBL;
        private System.Windows.Forms.Label UpTimeLBL;
        private System.Windows.Forms.Label UserNameLBL;
        private System.Windows.Forms.Label CPULBL;
        private System.Windows.Forms.TextBox MemoryTB;
        private System.Windows.Forms.Label MemoryLBL;
        private System.Windows.Forms.Timer InfoTimer;
        private System.Windows.Forms.Timer DriveTimer;
        private System.Windows.Forms.MenuStrip OptionsMenu;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speakCurrentDriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speakPCInfoToolStripMenuItem;
        private System.Windows.Forms.TextBox UpTimeTB;
    }
}

