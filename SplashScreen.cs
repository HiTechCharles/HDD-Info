using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace HDD_Info
{
    public partial class SplashScreen : Form
    {
        #region Fields
        private Bitmap _imageBitmap;

        private const string APP_VERSION = "8.16";
        private const string APP_NAME = "HDD Info";
        private const int TEXT_RESERVED_HEIGHT = 120;
        private const int TEXT_SPACING = 5;
        private const int TEXT_BOTTOM_MARGIN = 110;
        #endregion

        public SplashScreen()
        {
            InitializeComponent();
            LoadEmbeddedImage();

            // Add resize event handler to trigger repaint
            this.Resize += (s, e) => this.Invalidate();
        }

        private void LoadEmbeddedImage()
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();

                // Try different possible resource names (spaces can be tricky in resource names)
                string[] possibleNames = new[]
                {
                    "HDD_Info.computer info.jpg",
                    "HDD_Info.computer_info.jpg",
                    "HDD_Info.Resources.computer info.jpg",
                    "HDD_Info.Resources.computer_info.jpg"
                };

                Stream resourceStream = null;
                foreach (string resourceName in possibleNames)
                {
                    resourceStream = assembly.GetManifestResourceStream(resourceName);
                    if (resourceStream != null)
                    {
                        break;
                    }
                }

                if (resourceStream != null)
                {
                    _imageBitmap = new Bitmap(resourceStream);
                    resourceStream.Dispose();
                }
            }
            catch (Exception ex)
            {
                // Image loading failed, will continue without image
                System.Diagnostics.Debug.WriteLine($"Failed to load embedded image: {ex.Message}");
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading...";
            this.TopMost = true;
            this.ResumeLayout(false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Set high-quality rendering
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            try
            {
                // Draw image if loaded
                if (_imageBitmap != null)
                {
                    DrawScaledImage(e.Graphics);
                }

                // Draw text at the bottom
                DrawSplashText(e.Graphics);
            }
            catch (Exception ex)
            {
                // Fallback if rendering fails
                DrawFallbackText(e.Graphics);
                System.Diagnostics.Debug.WriteLine($"Splash screen rendering error: {ex.Message}");
            }
        }

        private void DrawScaledImage(Graphics graphics)
        {
            // Reserve space for text at the bottom
            int availableHeight = this.ClientSize.Height - TEXT_RESERVED_HEIGHT;
            int availableWidth = this.ClientSize.Width;

            // Calculate scaling to fit the image within available space
            float scaleX = (float)availableWidth / _imageBitmap.Width;
            float scaleY = (float)availableHeight / _imageBitmap.Height;
            float scale = Math.Min(scaleX, scaleY); // Maintain aspect ratio

            int scaledWidth = (int)(_imageBitmap.Width * scale);
            int scaledHeight = (int)(_imageBitmap.Height * scale);

            // Center the scaled image
            int x = (this.ClientSize.Width - scaledWidth) / 2;
            int y = (availableHeight - scaledHeight) / 2;

            Rectangle destRect = new Rectangle(x, y, scaledWidth, scaledHeight);
            graphics.DrawImage(_imageBitmap, destRect, 0, 0, _imageBitmap.Width, _imageBitmap.Height, GraphicsUnit.Pixel);
        }

        private void DrawSplashText(Graphics graphics)
        {
            using (Font titleFont = new Font("Tahoma", 24, FontStyle.Bold))
            using (Font subFont = new Font("Tahoma", 12, FontStyle.Bold))
            {
                string titleText = $"{APP_NAME} V{APP_VERSION}";
                string subText = "Gathering disk and system statistics...";

                SizeF titleSize = graphics.MeasureString(titleText, titleFont);
                SizeF subSize = graphics.MeasureString(subText, subFont);

                float titleX = (this.ClientSize.Width - titleSize.Width) / 2;
                float titleY = this.ClientSize.Height - TEXT_BOTTOM_MARGIN;
                float subX = (this.ClientSize.Width - subSize.Width) / 2;
                float subY = titleY + titleSize.Height + TEXT_SPACING;

                graphics.DrawString(titleText, titleFont, Brushes.Yellow, titleX, titleY);
                graphics.DrawString(subText, subFont, Brushes.LightBlue, subX, subY);
            }
        }

        private void DrawFallbackText(Graphics graphics)
        {
            string text = $"Loading {APP_NAME}...";
            using (Font font = new Font("Segoe UI", 16))
            {
                SizeF textSize = graphics.MeasureString(text, font);
                float x = (this.ClientSize.Width - textSize.Width) / 2;
                float y = (this.ClientSize.Height - textSize.Height) / 2;
                graphics.DrawString(text, font, Brushes.White, x, y);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _imageBitmap?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}