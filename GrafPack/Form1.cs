using System;
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

            this.BackColor = Color.White;
            this.Height = 500;
            this.Width = 815;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;


        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            ExitPopUpForm exitPopUpForm = new ExitPopUpForm();
            exitPopUpForm.Show();
        }
    }
}
