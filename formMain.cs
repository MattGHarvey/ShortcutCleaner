using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ShortcutCleaner
{
    public partial class formMain : Form
    {
        [DllImport("Shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        public const int SHCNE_ASSOCCHANGED = 0x8000000;
        public const int SHCNF_IDLIST = 0;
        public string commonPath;
        public string specialPath;

        public formMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            commonPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
            specialPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileSystemWatcher1.Path = commonPath;
            fileSystemWatcher2.Path = specialPath;
            this.ShowInTaskbar = false;
            loadClean(commonPath);
            loadClean(specialPath);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void clean(string cleanPath)
        {
            string checkEx = @".lnk";

            string extension = Path.GetExtension(cleanPath);
            if (extension == checkEx)
            {
                Thread.Sleep(2000);
                File.Delete(cleanPath);
            }

            SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_IDLIST, IntPtr.Zero, IntPtr.Zero);
        }

        private void loadClean(string cleanPath)
        {
            string checkEx = @".lnk";

            foreach (string fileName in Directory.GetFiles(cleanPath))
            {
                string extension = Path.GetExtension(fileName);
                if (extension == checkEx)
                {
                    File.Delete(fileName);
                }
            }
        }

        private void bClean_Click(object sender, EventArgs e)
        {
            clean(commonPath);
            clean(specialPath);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void cleanNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.clean(specialPath);
            this.clean(commonPath);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
            this.ShowInTaskbar = true;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void lnkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/MattGHarvey/ShortcutCleaner");
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            //Cleanup so that the icon will be removed when the application is closed
            notifyIcon1.Visible = false;
        }

        private void lnkGitHub_Resize(object sender, EventArgs e)
        {
        }

        private void formMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                this.Hide();
            }
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            clean(e.FullPath);
        }

        private void fileSystemWatcher2_Created(object sender, FileSystemEventArgs e)
        {
            clean(e.FullPath);
        }
    }
}