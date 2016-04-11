using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluginInstaller
{
    public partial class PluginInfo : Form
    {
        public PluginInfo()
        {
            InitializeComponent();
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.BackgroundImage = Properties.Resources.xolhgkpz;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.xolhgkpz;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            richTextBox1.LoadFile("C:\\ax.rtf");
            button2.BackgroundImage = Properties.Resources.nlpvyjxe;
            button1.BackgroundImage = Properties.Resources.nlpvyjxe;
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void PluginInfo_Load(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.LoadFile("./Temp/info.rtf");
            }
            catch { this.Close(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Program.Valid = true;
        }
    }
}
