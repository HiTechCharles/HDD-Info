using System;
using System.IO;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDD_Info
{
    public partial class FolderSize : Form
    {
        #region Fields
        private readonly SpeechSynthesizer _synth;
        private int _fileCount;
        private int _folderCount;
        private bool _isScanning;

        private const int TTS_VOLUME = 100;
        private const int TTS_RATE = 3;
        private const double BYTES_TO_GB = 1024.0 * 1024.0 * 1024.0;
        #endregion

        public FolderSize()
        {
            InitializeComponent();

            _synth = new SpeechSynthesizer
            {
                Rate = TTS_RATE,
                Volume = TTS_VOLUME
            };

            ScanProgressBar.Visible = false;
        }

        private void browseForFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectFolderFB.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = SelectFolderFB.SelectedPath;
                PathTB.Text = selectedPath;
            }
        }

        private async void FolderTimer_Tick(object sender, EventArgs e)
        {
            // Get the folder size and display it in the FolderSizeTB TextBox
            if (string.IsNullOrEmpty(PathTB.Text) || _isScanning)
            {
                return;
            }

            try
            {
                _isScanning = true;
                ScanProgressBar.Visible = true;
                ScanProgressBar.Style = ProgressBarStyle.Marquee;
                ScanProgressBar.MarqueeAnimationSpeed = 30;

                // Reset counters
                _fileCount = 0;
                _folderCount = 0;

                // Run folder scan on background thread
                long folderSize = await Task.Run(() => GetFolderSize(PathTB.Text));

                SizeTB.Text = StorageHelper.FormatStorageSize(folderSize / BYTES_TO_GB);

                // Display counts
                FileCountTB.Text = _fileCount.ToString("N0");
                FolderCountTB.Text = _folderCount.ToString("N0");

                // Calculate percentage of used space
                CalculatePercentageOfUsedSpace(PathTB.Text, folderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error calculating folder size: {ex.Message}",
                    "Folder Scan Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            finally
            {
                ScanProgressBar.Visible = false;
                _isScanning = false;
            }
        }

        private long GetFolderSize(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                return 0;
            }

            long totalSize = 0;

            try
            {
                // Add file sizes in current directory
                DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
                FileInfo[] files = dirInfo.GetFiles();
                _fileCount += files.Length;

                foreach (FileInfo file in files)
                {
                    totalSize += file.Length;
                }

                // Recursively add sizes from subdirectories
                DirectoryInfo[] subDirs = dirInfo.GetDirectories();
                _folderCount += subDirs.Length;

                foreach (DirectoryInfo subDir in subDirs)
                {
                    totalSize += GetFolderSize(subDir.FullName);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Skip directories we don't have access to
            }
            catch (DirectoryNotFoundException)
            {
                // Skip if directory was deleted during scan
            }
            catch (PathTooLongException)
            {
                // Skip paths that exceed system limits
            }

            return totalSize;
        }

        private void CalculatePercentageOfUsedSpace(string folderPath, long folderSize)
        {
            try
            {
                DriveInfo drive = new DriveInfo(Path.GetPathRoot(folderPath));

                if (drive.IsReady)
                {
                    long usedSpace = drive.TotalSize - drive.AvailableFreeSpace;

                    if (usedSpace > 0)
                    {
                        double percentage = (folderSize / (double)usedSpace) * 100.0;
                        PercentageTB.Text = $"{percentage:N2}%";
                    }
                    else
                    {
                        PercentageTB.Text = "0.00%";
                    }
                }
                else
                {
                    PercentageTB.Text = "N/A";
                }
            }
            catch (Exception)
            {
                PercentageTB.Text = "N/A";
            }
        }

        private void speakFolderInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PathTB.Text))
            {
                return;
            }

            _synth.SpeakAsyncCancelAll();

            string message = $"The Folder {PathTB.Text} has a size of {SizeTB.Text}, " +
                            $"contains {FileCountTB.Text} files and {FolderCountTB.Text} folders, " +
                            $"and represents {PercentageTB.Text} of the drive's used space.";

            // Format for speech
            message = message
                .Replace("GB", "gigabytes")
                .Replace("TB", "terabytes")
                .Replace("%", " percent");

            _synth.SpeakAsync(message);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _synth?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}