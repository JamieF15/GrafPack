﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace GrafPack
{
    public partial class ShapeCreationForm : Form
    {
        bool colourChosen = false;

        public static Color chosenColour; 

        public ShapeCreationForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SquareButton_Click(object sender, EventArgs e)
        {
            if (colourChosen == true)
            {
                MainForm.CreateSquare = true;
                colourChosen = false;
                this.Close();
            }
            else
            {
                MessageBox.Show("Choose a colour for the shape");
            }
        }

        private void ChooseColourButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            { 
                colourChosen = true;
                chosenColour = colorDialog1.Color;                
            }
        }

        private void CircleButton_Click(object sender, EventArgs e)
        {
            if (colourChosen == true)
            {
                MainForm.CreateCircle = true;
                colourChosen = false;
                this.Close();
            }
            else
            {
                MessageBox.Show("Choose a colour for the shape");
            }
        }

        private void TriangleButton_Click(object sender, EventArgs e)
        {
            if (colourChosen == true)
            {
                MainForm.CreateTriangle = true;
                colourChosen = false;
                this.Close();
            }
            else
            {
                MessageBox.Show("Choose a colour for the shape");
                
            }
        }
    }
}
