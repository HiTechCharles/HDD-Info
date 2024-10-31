using System;
using System.Windows.Forms;         // for windows forms, duh!
using System.Threading;             //used for thread.sleep
using System.Diagnostics;           //performance counter usage
using System.IO;                    //get hard drive statistics
using System.Speech.Synthesis;      //text to speech

namespace HDD_Info
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)  //show computer info,  and update it every second
        {
            #region Performance Counters
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");   //gets cpu usage %
            PerformanceCounter FreeRamCounter = new PerformanceCounter("Memory", "Available MBytes");  //available memory in mb
            PerformanceCounter UptimeCounter = new PerformanceCounter("System",
                "System Up Time");  //system uptime

            cpuCounter.NextValue();  //first performance counters values will be 0
            FreeRamCounter.NextValue();
            UptimeCounter.NextValue();
            //wait 0.5 seconds to give the computer time to get usable values
            Thread.Sleep(500);
            #endregion

            #region display computer info
            //store cpu percentage as integer,  display in CPUTB
            CPUTB.Text = (int)cpuCounter.NextValue() + "%";

            double  RAMConverted = FreeRamCounter.NextValue() / 1024;  //get mb ram free, convert to GB
            double  TotalMemory = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory/1024/1024/1024+1;

            //get the uptime in hours, minutes, etc instead of just seconds
            TimeSpan UpTimeSpan = TimeSpan.FromSeconds(UptimeCounter.NextValue());

            UpTimeTB.Text = string.Format("{0}Days {1}H {2}M {3}S",
                (int)UpTimeSpan.TotalDays, UpTimeSpan.Hours, UpTimeSpan.Minutes, UpTimeSpan.Seconds);

            MemoryTB.Text = RAMConverted.ToString("n2") + " GB of " + TotalMemory.ToString() + " GB";  //store free ant total ram
            ComputerNameTB.Text = Environment.MachineName;  //computer's name
            UserNameTB.Text = Environment.UserName;  //current user
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)   //get list of hard drives and add to combo box 
            {
                if (d.IsReady == true)   //if drive is available 
                {
                    DriveCB.Items.Add(d.Name.Substring(0, 2) + " " + d.VolumeLabel);  //adds drive letter and name
                }
            }
            DriveCB.SelectedIndex = 0;  //select first drive in list
        }

        private void DriveTimer_Tick(object sender, EventArgs e)  //every second, get latest drive stats
        {
            string DL= DriveCB.SelectedItem.ToString().Substring(0,1);  //get first char of selected drive  (the drive letter)
            float FreeSpace, TotalSpace, UsedSpace, UsedPercent;  //storage variables
            string FreeSpaceSuffix, TotalSpaceSuffix, UsedSpaceSuffix;   //Free, used, total either GB or TB
            DriveInfo D = new DriveInfo(DL);  //get stats for selected drive

            FreeSpace = D.AvailableFreeSpace / 1024 / 1024/1024;  //convert to gb, original value in bytes
            if (FreeSpace >= 1024)  //if free space GB > 1024 convert to TB
            {
                FreeSpace /= 1024;
                FreeSpaceSuffix = " TB";
            }
            else
                FreeSpaceSuffix = " GB";    //if space less than 1024gb

            TotalSpace = D.TotalSize / 1024 / 1024 / 1024;
            if (TotalSpace >= 1024)
            {
                TotalSpace /= 1024;
                TotalSpaceSuffix = " TB";
            }
            else
                TotalSpaceSuffix = " GB";

            UsedSpace = (D.TotalSize - D.AvailableFreeSpace) / 1024 / 1024 / 1024;
            if (UsedSpace >= 1024)
            {
                UsedSpace /=  1024;
                UsedSpaceSuffix = " TB";
            }
            else
                UsedSpaceSuffix = " GB";

            UsedPercent = 100 - (D.AvailableFreeSpace / (float)D.TotalSize) * 100;  //% full

            PercentUsedTB.Text = UsedPercent.ToString("n2");  //disk percent used
            FreeTB.Text = FreeSpace.ToString("n2") + FreeSpaceSuffix;  //free
            TotalTB.Text = TotalSpace.ToString("n2") + TotalSpaceSuffix;  //total
            UsedTB.Text = UsedSpace.ToString("n2") + UsedSpaceSuffix;  //used
        }

        private void EXitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();  //close program
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriveCB.Items.Clear();  //clear combobox
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)   //get list of hard drives and add to combo box 
            {
                if (d.IsReady == true)   //if drive is available 
                {
                    DriveCB.Items.Add(d.Name.Substring(0, 2) + " " + d.VolumeLabel);  //adds drive letter and name
                }
            }
            DriveCB.SelectedIndex = 0;  //select first drive in list
        }

        private void SpeakCurrentDriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer Chuck = new SpeechSynthesizer(); //start speech synth
            string selected = this.DriveCB.GetItemText(this.DriveCB.SelectedItem);
            Chuck.SpeakAsync("Drive selected: " + selected);
            Chuck.SpeakAsync("Free Space:  " + FreeTB.Text);
            Chuck.SpeakAsync("Percent used:  " + PercentUsedTB.Text);
            Chuck.SpeakAsync("Used Space:  " + UsedTB.Text);
            Chuck.SpeakAsync("Drive Capacity:  " + TotalTB.Text);
       }

        private void SpeakPCInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer Chuck = new SpeechSynthesizer(); //start speech synth
            //speak a series of textboxes
            Chuck.SpeakAsync("CPU Load:  " + CPUTB.Text);
            Chuck.SpeakAsync("Memory:  " + MemoryTB.Text);
            Chuck.SpeakAsync("Computer Name:  " + ComputerNameTB.Text);
            Chuck.SpeakAsync("Current User:  " + UserNameTB.Text);
            Chuck.SpeakAsync("Up Time:  " + UpTimeTB.Text);
        }
    }
}