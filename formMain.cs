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
            timer1.Interval = 600000;
            timer1.Start();
            this.ShowInTaskbar = false;



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

                   // File.Delete(fileName);





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
    }
}
