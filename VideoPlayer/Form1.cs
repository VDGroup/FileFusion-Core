using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoPlayer
{
    public partial class Form1 : Form
    {
        public Form1(string Args)
        {
            InitializeComponent();
            VPlayer.URL = Args;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (VPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                Position.Maximum = Convert.ToInt32(VPlayer.currentMedia.duration);
                Position.Value = Convert.ToInt32(VPlayer.Ctlcontrols.currentPosition);

            }
        }

        private void Position_Scroll(object sender, EventArgs e)
        {
            VPlayer.Ctlcontrols.pause();
            this.VPlayer.Ctlcontrols.currentPosition = Position.Value;
        }

        private void VPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (VPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                State.Text = "Pause";
            }
            else
            {
                State.Text = "Play";
            }
        }

        private void State_Click(object sender, EventArgs e)
        {
            if (VPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                VPlayer.Ctlcontrols.pause();
            }
            else
            {
                VPlayer.Ctlcontrols.play();
            }
        }

        private void Position_MouseUp(object sender, MouseEventArgs e)
        {
            VPlayer.Ctlcontrols.play();
        }
    }
}
