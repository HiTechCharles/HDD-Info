using System;
using System.Windows.Forms;

namespace HDD_Info
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show splash screen
            SplashScreen splash = new SplashScreen();
            splash.Show();
            Application.DoEvents(); // Force splash to render

            // Create main form but make it invisible initially
            Form1 mainForm = new Form1
            {
                Opacity = 0,
                ShowInTaskbar = false
            };

            // Subscribe to loading complete event
            mainForm.LoadingComplete += (s, e) =>
            {

               // Close splash screen and make main form visible

               splash.Close();
                splash.Dispose();
                
                mainForm.Opacity = 1;
                mainForm.ShowInTaskbar = true;
                mainForm.Activate();
            };

            // Show the main form (this triggers OnLoad)
            // It's invisible so user won't see it until LoadingComplete fires
            mainForm.Show();
            Application.DoEvents(); // Process the Load event

            // Run the application
            Application.Run(mainForm);
        }
    }
}