﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafPack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 500;
            this.Height = 500;
            this.BackColor = Color.White;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
        }
    }
}
