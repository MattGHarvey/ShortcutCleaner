using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace ShortcutCleaner
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            

        }

        private void formMain_Load(object sender, EventArgs e)
        {
            timer1.Interval = 7200000;
            timer1.Start();
            this.ShowInTaskbar = false;
            clean();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // TODO: Insert monitoring activities here.
            clean();

        }
        private void clean()
        {
            //  eventLog1.WriteEntry("Monitoring the System", EventLogEntryType.Information, eventId++);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string checkEx = @".lnk";

            foreach (string fileName in Directory.GetFiles(path))
            {
                string extension = Path.GetExtension(fileName);
                if (extension == checkEx)
                {

                    File.Delete(fileName);





                }

            }

            path = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
            foreach (string fileName in Directory.GetFiles(path))
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
            clean();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

      


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cleanNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.clean();

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
    }
}
