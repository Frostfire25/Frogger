using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frogger
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        //Use timer class
        Timer tmr;
        
        private void Splash_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();
            //set time interval 3 sec
            tmr.Interval = 3000;

            //starts the timer
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }

        public void Splash_Load(object sender, EventArgs e)
        {

        }

        void tmr_Tick(object sender, EventArgs e)
        {
            //after 3 sec stop the timer
            tmr.Stop();
            //display Form1
            Form1 Frm1 = new Form1();
            Frm1.Show();
            //hide Splash form
            this.Hide();
        }

    }
}
