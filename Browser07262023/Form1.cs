using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser07262023
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a simple browser made by Gene On Yo Screen.", "About");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
            toolStripStatusLabel1.Text = "Loading...";
            //button1.Enabled = false;
            //textBox1.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //button1.Enabled = true;
            //textBox1.Enabled = true;
            toolStripStatusLabel1.Text = "Done";
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress > 0 && e.MaximumProgress > 0)
            {
                toolStripProgressBar1.Value = (int)(e.CurrentProgress * 100 / (int)e.MaximumProgress);
                if (toolStripProgressBar1.Value < 100)
                {
                    toolStripStatusLabel1.Text = "Loading...";
                }
                else
                {
                      toolStripStatusLabel1.Text = "Done";

                }
            }
        }
    }
}
