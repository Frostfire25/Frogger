﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void start_game_Click(object sender, EventArgs e)
        {
            this.Hide();
            using(frogBox frogger = new frogBox())
            {
                frogger.ShowDialog();
            }
        }
    }
}
