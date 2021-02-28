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
        public static LinkedList<Shape> shapes = new LinkedList<Shape>();
        
        //these attributes determine which shape to make, which is decided in the create submenu
        public static bool CreateSquare { get; set; }
        public static bool createTriangle { get; set; }
        public static bool createCircle { get; set; }

        //each shape will be made based on the start point, whcih will be assigned when the mouse goes down
        Point startPoint;

        //and and the end point, which is assigned when the mouse is released.
        Point endPoint;

        Pen p;

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.White;
        }

        /// <summary>
        /// allows for painting on the canvas
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
        }

        /// <summary>
        /// click event for the exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            ExitPopUpForm exitPopUpForm = new ExitPopUpForm();
            exitPopUpForm.Show();
        }

        /// <summary>
        /// click event for the Create button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            ShapeCreationForm shapeCreationForm = new ShapeCreationForm();
            shapeCreationForm.Show();
        }

        /// <summary>
        /// mouse down event for the canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanvasPan_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && CreateSquare == true)
            {
                startPoint = new Point(e.X, e.Y);
            }
        }

        /// <summary>
        /// mouse up even for the canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanvasPan_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && CreateSquare == true)
            {
                endPoint = new Point(e.X, e.Y);

                CreateSquare = false;

                p = new Pen(ShapeCreationForm.chosenColour);

                CanvasPan.BackColor = p.Color;
            }
        }
    }
}
