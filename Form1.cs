using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Speech.Synthesis;
using System.Management;
using Microsoft.VisualBasic.Devices;

namespace HDD_Info
{
    public partial class Form1 : Form
    {
        #region Fields
        // Performance counters reused (avoid recreating every tick)
        private PerformanceCounter _cpuCounter;
        private PerformanceCounter _freeRamCounter;
        private PerformanceCounter _uptimeCounter;

        // Reuse the speech synthesizer (dispose on close)
        private SpeechSynthesizer _tts;

        // Cache total memory (doesn't change at runtime)
        private double _totalMemoryGB;

        // Constants
        private const int TTS_VOLUME = 100;
        private const int TTS_RATE = 3;
        private const double BYTES_TO_GB = 1024.0 * 1024.0 * 1024.0;
        private const int COUNTER_PRIME_DELAY_MS = 100;

        // Event to signal when loading is complete
        public event EventHandler LoadingComplete;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                // Initialize and prime performance counters
                _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                _freeRamCounter = new PerformanceCounter("Memory", "Available MBytes");
                _uptimeCounter = new PerformanceCounter("System", "System Up Time");

                // Prime the counters once (first NextValue() often returns 0)
                _cpuCounter.NextValue();
                _freeRamCounter.NextValue();
                _uptimeCounter.NextValue();

                // Small delay for accurate first reading
                System.Threading.Thread.Sleep(COUNTER_PRIME_DELAY_MS);

                // Cache total memory once (round up to nearest GB)
                _totalMemoryGB = Math.Ceiling(new ComputerInfo().TotalPhysicalMemory / BYTES_TO_GB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to initialize performance counters: {ex.Message}",
                    "Initialization Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            // Initialize TTS engine
            _tts = new SpeechSynthesizer
            {
                Volume = TTS_VOLUME,
                Rate = TTS_RATE
            };

            // Populate drives
            RefreshDriveList();

            // Trigger initial timer ticks to populate data
            UpdateTimer_Tick(null, EventArgs.Empty);
            DriveTimer_Tick(null, EventArgs.Empty);

            // Signal that loading is complete
            LoadingComplete?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Dispose managed resources
            _cpuCounter?.Dispose();
            _freeRamCounter?.Dispose();
            _uptimeCounter?.Dispose();
            _tts?.Dispose();
        }

        private void RefreshDriveList()
        {
            DriveCB.Items.Clear();

            try
            {
                DriveInfo[] allDrives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in allDrives)
                {
                    if (drive.IsReady)
                    {
                        // Store the full drive path in the entry, display a friendly label
                        string display = $"{drive.Name.TrimEnd('\\')} {drive.VolumeLabel}";
                        DriveCB.Items.Add(new DriveEntry(drive.Name, display));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error refreshing drive list: {ex.Message}",
                    "Drive Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            if (DriveCB.Items.Count > 0)
            {
                DriveCB.SelectedIndex = 0;
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // CPU usage
                float cpuVal = _cpuCounter?.NextValue() ?? 0f;
                CPUTB.Text = $"{(int)cpuVal}%";

                // Memory (use cached total memory)
                double freeMemoryGB = (_freeRamCounter?.NextValue() ?? 0f) / 1024.0;  // MB -> GB
                MemoryTB.Text = $"{freeMemoryGB:N2} GB of {_totalMemoryGB:N2} GB";

                // Uptime
                TimeSpan upTimeSpan = TimeSpan.FromSeconds(_uptimeCounter?.NextValue() ?? 0.0);
                UpTimeTB.Text = $"{(int)upTimeSpan.TotalDays} Days {upTimeSpan.Hours}H {upTimeSpan.Minutes}M {upTimeSpan.Seconds}S";

                ComputerNameTB.Text = Environment.MachineName;
                UserNameTB.Text = Environment.UserName;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error updating system info: {ex.Message}");
            }
        }

        private void DriveTimer_Tick(object sender, EventArgs e)
        {
            if (!(DriveCB.SelectedItem is DriveEntry entry))
            {
                return;
            }

            try
            {
                var drive = new DriveInfo(entry.Path);
                if (!drive.IsReady)
                {
                    SetDriveInfoUnavailable();
                    return;
                }

                double freeSpaceGB = drive.AvailableFreeSpace / BYTES_TO_GB;
                double totalSpaceGB = drive.TotalSize / BYTES_TO_GB;
                double usedSpaceGB = (drive.TotalSize - drive.AvailableFreeSpace) / BYTES_TO_GB;

                double usedPercent = (1.0 - ((double)drive.AvailableFreeSpace / drive.TotalSize)) * 100.0;
                usedPercent = Clamp(usedPercent, 0, 100);

                PercentUsedTB.Text = usedPercent.ToString("N2");
                FreeTB.Text = StorageHelper.FormatStorageSize(freeSpaceGB);
                TotalTB.Text = StorageHelper.FormatStorageSize(totalSpaceGB);
                UsedTB.Text = StorageHelper.FormatStorageSize(usedSpaceGB);
            }
            catch (IOException ex)
            {
                Debug.WriteLine($"Drive I/O error: {ex.Message}");
                SetDriveInfoUnavailable();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unexpected drive error: {ex.Message}");
                SetDriveInfoUnavailable();
            }
        }

        private void SetDriveInfoUnavailable()
        {
            PercentUsedTB.Text = FreeTB.Text = TotalTB.Text = UsedTB.Text = "N/A";
        }

        /// <summary>
        /// Replaces storage unit abbreviations with full words for text-to-speech.
        /// </summary>
        private string FormatTextForSpeech(string text)
        {
            return text
                .Replace("GB", "gigabytes")
                .Replace("TB", "terabytes")
                .Replace("%", " percent");
        }

        #region Options menu items
        private void EXitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshDriveList();
        }

        private void SpeakCurrentDriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DriveCB.SelectedItem == null)
            {
                return;
            }

            var selected = DriveCB.GetItemText(DriveCB.SelectedItem);
            var infoToSpeak = new[]
            {
                $"Drive Selected: {selected}",
                $"Free Space: {FreeTB.Text}",
                $"Percent Used: {PercentUsedTB.Text}",
                $"Used Space: {UsedTB.Text}",
                $"Total Space: {TotalTB.Text}"
            };

            _tts?.SpeakAsyncCancelAll();
            foreach (var line in infoToSpeak)
            {
                _tts?.SpeakAsync(FormatTextForSpeech(line) + ".");
            }
        }

        private void SpeakPCInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _tts?.SpeakAsyncCancelAll();

            var infoToSpeak = new[]
            {
                $"CPU Load: {CPUTB.Text}",
                $"Memory: {MemoryTB.Text}",
                $"Computer Name: {ComputerNameTB.Text}",
                $"Current User: {UserNameTB.Text}",
                $"Up Time: {UpTimeTB.Text}"
            };

            foreach (var line in infoToSpeak)
            {
                _tts?.SpeakAsync(FormatTextForSpeech(line) + ".");
            }
        }

        private void browseSelectedDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(DriveCB.SelectedItem is DriveEntry entry))
            {
                return;
            }

            try
            {
                var drive = new DriveInfo(entry.Path);
                if (drive.IsReady)
                {
                    Process.Start("explorer.exe", drive.Name);
                }
                else
                {
                    MessageBox.Show(
                        $"Drive {entry.Path} is not ready.",
                        "Drive Unavailable",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to open drive: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void checkFolderSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderSize folderSize = new FolderSize())
            {
                folderSize.ShowDialog();
            }
        }
        #endregion

        /// <summary>
        /// Helper class to associate drive path with display text in the ComboBox.
        /// </summary>
        private class DriveEntry
        {
            public string Path { get; }
            private readonly string _display;

            public DriveEntry(string path, string display)
            {
                Path = path;
                _display = display;
            }

            public override string ToString() => _display;
        }

        private static double Clamp(double value, double min, double max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        private void DriveCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Immediately trigger drive info update when selection changes
            DriveTimer_Tick(sender, e);
        }
    }
}