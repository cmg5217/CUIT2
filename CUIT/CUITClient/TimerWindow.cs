using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CUITAdmin
{
    public partial class TimerWindow : Form
    {

        int ticks = 0;
        int minutes = 0;
        int hours = 0;
        String timedisplay;

        public TimerWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ticks = 0;
            minutes = 0;
            hours = 0;
            timedisplay = "";
            // LoginScreen.Show();
            LoginScreen frm = new LoginScreen();
            frm.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            ticks++;
            if (ticks == 60)
            {
                minutes++;
                ticks = 0;
            }
            
            if (minutes == 60)
            {
                hours++;
                ticks = 0;
            }
            timedisplay = "Time:"+ " " + hours + ":" + minutes + ":" + ticks;

            lblTime.Text = timedisplay;
            
        }
    }
}
