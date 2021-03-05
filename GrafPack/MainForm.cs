using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GrafPack
{
    public partial class MainForm : Form
    {
        #region Attributes, Objects, & Variables
        public static List<Shape> shapes = new List<Shape>();
        public static bool CreateSquare { get; set; }
        public static bool CreateTriangle { get; set; }
        //https://math.stackexchange.com/questions/543961/determine-third-point-of-triangle-when-two-points-and-all-sides-are-known
        public static bool CreateCircle { get; set; }
        public static bool SelectShape { get; set; }
        Point startPoint;
        Point endPoint;
        Pen p;
        DoubleBufferedPanel Canvas;
        #endregion

        #region Methods
        public MainForm()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            CreateCanvas();
        }

        /// <summary>
        /// Creates a double buffered Panel to draw on
        /// </summary>
        void CreateCanvas()
        {
            Canvas = new DoubleBufferedPanel();
            Canvas.BackColor = Color.White;
            Canvas.Location = new Point(2, 70);
            Canvas.Size = new Size(this.Width - 17, this.Height);
            this.Controls.Add(Canvas);
            Canvas.BorderStyle = BorderStyle.FixedSingle;

            Canvas.MouseDown += new MouseEventHandler(this.CanvasMouseDown);
            Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CanvasMouseUp);
            Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanvasMouseMove);
        }

        /// <summary>
        /// <param name="sender"></
        /// click event for the exit button
        /// </summary>param>
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
        private void CanvasMouseDown(object sender, MouseEventArgs e)
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
        private void CanvasMouseUp(object sender, MouseEventArgs e)
        {
            using Graphics g = Canvas.CreateGraphics();

            if (e.Button == MouseButtons.Left && CreateSquare == true)
            {
                endPoint = new Point(e.X, e.Y);
                p = new Pen(ShapeCreationForm.chosenColour);
                Square s = new Square(startPoint, endPoint, p.Color, "Square");
                s.Draw(g, p);
                p.Dispose();
                CreateSquare = false;

                shapes.Add(s);
            }
        }

        /// <summary>
        /// Triggers on mouse move in the panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
             Graphics g = Canvas.CreateGraphics();

            if (e.Button == MouseButtons.Left && CreateSquare == true)
            {
                endPoint = new Point(e.X, e.Y);
                p = new Pen(ShapeCreationForm.chosenColour, 3);
                Square s = new Square(startPoint, endPoint, p.Color, "Square");

                Canvas.Refresh();
                RedrawAllShapes();
                s.Draw(g, p);
            }
        }

        /// <summary>
        /// On mouse move, all shapes are to be redrawn to preserve them and update the template for the shape being created
        /// </summary>
        void RedrawAllShapes()
        {
            using Graphics g = Canvas.CreateGraphics();

            Pen PenForEachShape;
           
            foreach (Square square in shapes)
            {
                PenForEachShape = new Pen(square.GetColor());
                square.Draw(g, PenForEachShape);
                PenForEachShape.Dispose();
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            ShapeSelectionForm shapeSelectionForm = new ShapeSelectionForm();
            shapeSelectionForm.Show();
        }
        #endregion
    }
}
