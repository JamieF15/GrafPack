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
        public static bool CreateTriangle { get; set; }
        //https://math.stackexchange.com/questions/543961/determine-third-point-of-triangle-when-two-points-and-all-sides-are-known

        public static bool CreateCircle { get; set; }

        public static bool SelectShape { get; set; }

        //each shape will be made based on the start point, whcih will be assigned when the mouse goes down
        Point startPoint;
        //and and the end point, which is assigned when the mouse is released.
        Point endPoint;
        Pen p;


        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
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
            bool drawTemplate = true;

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
            using Graphics g = CanvasPan.CreateGraphics();

            if (e.Button == MouseButtons.Left && CreateSquare == true)
            {
                endPoint = new Point(e.X, e.Y);
                p = new Pen(ShapeCreationForm.chosenColour, 3);
                Square s = new Square(startPoint, endPoint);
                s.Draw(g, p);
                p.Dispose();
                CreateSquare = false;

                shapes.AddLast(s);

            }
        }
    }
}
