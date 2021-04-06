using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GrafPack
{
    public partial class MainForm : Form
    {
        #region Attributes, Objects, & Variables
        //Stores the shapes that were created
        public static List<Shape> shapes = new List<Shape>();
        public static bool CreateSquare { get; set; }
        public static bool CreateTriangle { get; set; }
        public static bool CreateCircle { get; set; }
        public static bool ShapeSelected { get; set; }
        public static int PenSize { get; set; } = 3;

        Point startPoint;
        Point endPoint;
        public static Pen mainPen;

        public static DoubleBufferedPanel Canvas;
        public static Bitmap drawingRegion;
        public static Bitmap allShapes;
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
            //create a new double buffered panel
            Canvas = new DoubleBufferedPanel();

            //set the back colour to the back colour of the form
            Canvas.BackColor = this.BackColor;

            //offset it to position it correctly
            Canvas.Location = new Point(Convert.ToInt32( 1.5), 60);

            // set the size of it to the size of the frame
            Canvas.Size = this.Size;

            //add the canvas to the frame
            this.Controls.Add(Canvas);

            //set the border style
            Canvas.BorderStyle = BorderStyle.FixedSingle;

            //create a bitmap to to store drawings
            drawingRegion = new Bitmap(Canvas.Width, Canvas.Height);

            //create a buffer bitmap to store each shape when it is created
            allShapes = new Bitmap(Canvas.Width, Canvas.Height);

            //mouse down event for the canvas
            Canvas.MouseDown += new MouseEventHandler(this.CanvasMouseDown);

            //mouse up event for the canvas
            Canvas.MouseUp += new MouseEventHandler(this.CanvasMouseUp);

            //mouse move event for the canvas
            Canvas.MouseMove += new MouseEventHandler(this.CanvasMouseMove);
        }

        /// <summary>
        /// <param name="sender"></
        /// Creates an instance of the exit form to allow the user to exit
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
            //check if the left mouse button has been clicked
            if (e.Button == MouseButtons.Left)
            {
                //set the global start point to hte postion of the mouse
                startPoint = new Point(e.X, e.Y);
            }
        }

        /// <summary>
        /// Create the shape when the mouse is released 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanvasMouseUp(object sender, MouseEventArgs e)
        {
            //draw to the drawing region
            using Graphics g = Graphics.FromImage(drawingRegion);

            //set the end point to the position of the mouse
            endPoint = new Point(e.X, e.Y);

            //create a pen to create the square
            mainPen = new Pen(ShapeCreationForm.chosenColour, PenSize);

            //check if the left mouse button has been clicked and CreateSquare is true
            if (e.Button == MouseButtons.Left && CreateSquare == true)
            {
                //create a square object
                Square s = new Square(startPoint, endPoint, mainPen.Color);

                //draw the square
                s.DrawSqaure(g, mainPen);

                //dispose of the pen object
                mainPen.Dispose();

                //set the CreateSquare flag to false
                CreateSquare = false;

                //add the square to the list of shapes
                shapes.Add(s);
            }
            //check if the left mouse button has been clicked and CreateCircle is true
            else if (e.Button == MouseButtons.Left && CreateCircle == true)
            {
                //create a circle object
                Circle c = new Circle(mainPen.Color, startPoint, endPoint, 0);
              //  c.Draw();
                CreateCircle = false;
                shapes.Add(c);
            }
            else if (e.Button == MouseButtons.Left && CreateTriangle == true)
            {
                Triangle t = new Triangle(startPoint, endPoint, mainPen.Color);
                t.Draw(g, mainPen);
                CreateTriangle = false;
                shapes.Add(t);
            }

            Canvas.BackgroundImage = drawingRegion;
            allShapes = (Bitmap)drawingRegion.Clone();
            mainPen.Dispose();
            ResetDrawingRegion();
        }

        /// <summary>
        /// Triggers on mouse move in the panel and 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            //  using Graphics g = Canvas.CreateGraphics();
            using Graphics g = Graphics.FromImage(drawingRegion);

            //create a pen object
            mainPen = new Pen(ShapeCreationForm.chosenColour, PenSize);

            // if the mouse used to click was the left button and the CreateSqaure is true
            if (e.Button == MouseButtons.Left && CreateSquare == true)
            {
                //set the endPoint to the positon of the mouse
                endPoint = new Point(e.X, e.Y);

                //create a square object to represent the template of the square
                Square s = new Square(startPoint, endPoint, mainPen.Color);

                //refresh the canvas to prevent creating a vast amount of shapes
                ResetDrawingRegion();

                //draw the square to the canvas
                s.DrawSqaure(g, mainPen);

            }
            else if (e.Button == MouseButtons.Left && CreateCircle == true)
            {
                endPoint = new Point(e.X, e.Y);

                Circle c = new Circle(mainPen.Color, startPoint, endPoint, (int)GetPointDistance(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y));

                ResetDrawingRegion();

                c.Draw();

            }
            else if (e.Button == MouseButtons.Left && CreateTriangle == true)
            {
                //set the endPoint to the positon of the mouse
                endPoint = new Point(e.X, e.Y);

                //create a square object to represent the template of the square
                Triangle t = new Triangle(startPoint, endPoint, mainPen.Color);

                //refresh the canvas to prevent creating a vast amount of shapes
                ResetDrawingRegion();

                //draw the square to the canvas
                t.Draw(g, mainPen);
            }

            //set the background of the canvas to the drawing region
            Canvas.BackgroundImage = drawingRegion;
        }

        private static double GetPointDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        /// <summary>
        /// Used to set the bitmap to all white and refresh the canvas 
        /// </summary>
        public static void ResetDrawingRegion()
        {
            using Graphics g = Graphics.FromImage(drawingRegion);

            Canvas.Refresh();
            g.Clear(Canvas.BackColor);
            g.DrawImage(allShapes, 0, 0);
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            ShapeSelectionForm shapeSelectionForm = new ShapeSelectionForm();
            shapeSelectionForm.Show();
        }

        public static void ApplyDrawingChange()
        {
            MainForm.Canvas.BackgroundImage = MainForm.drawingRegion;
            MainForm.allShapes = (Bitmap)MainForm.drawingRegion.Clone();
            MainForm.ResetDrawingRegion();
        }
        #endregion
    }
}
