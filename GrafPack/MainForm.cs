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

        //
        public static bool CreateSquare { get; set; }
        public static bool CreateTriangle { get; set; }
        //https://math.stackexchange.com/questions/543961/determine-third-point-of-triangle-when-two-points-and-all-sides-are-known
        public static bool CreateCircle { get; set; }
        public static bool ShapeSelected { get; set; }
        public static int PenSize { get; set; } = 3;
        Point startPoint;
        Point endPoint;
        Pen p;
        public static DoubleBufferedPanel Canvas;
        public static Bitmap drawingRegion;

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
            Canvas.Location = new Point(2, 60);
            Canvas.Size = new Size(this.Width, this.Height);
            this.Controls.Add(Canvas);
            Canvas.BorderStyle = BorderStyle.FixedSingle;
            drawingRegion = new Bitmap(Canvas.Width, Canvas.Height);

            Canvas.MouseDown += new MouseEventHandler(this.CanvasMouseDown);
            Canvas.MouseUp += new MouseEventHandler(this.CanvasMouseUp);
            Canvas.MouseMove += new MouseEventHandler(this.CanvasMouseMove);
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
            if (e.Button == MouseButtons.Left)
            {
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
            using Graphics g = Graphics.FromImage(drawingRegion);

            //set the end point to the position of the mouse
            endPoint = new Point(e.X, e.Y);

            if (e.Button == MouseButtons.Left && CreateSquare == true)
            {
                //create a pen to create the square
                p = new Pen(ShapeCreationForm.chosenColour, PenSize);

                //create a square object
                Square s = new Square(startPoint, endPoint, p.Color);

                //draw the square
                s.Draw(g, p);

                //dispose of the pen object
                p.Dispose();

                //set the CreateSquare flag to false
                CreateSquare = false;

                //add the square to the list of shapes
                shapes.Add(s);

                Canvas.BackgroundImage = drawingRegion;
            }

            if (e.Button == MouseButtons.Left && CreateCircle == true)
            {
                Circle c = new Circle(p.Color, endPoint, 100);
                c.Draw(g, p);

                p.Dispose();
                CreateCircle = false;
                shapes.Add(c);
            }
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
            p = new Pen(ShapeCreationForm.chosenColour, PenSize);

            // if the mouse used to click was the left button and the CreateSqaure is true
            if (e.Button == MouseButtons.Left && CreateSquare == true)
            {
                //set the endPoint to the positon of the mouse
                endPoint = new Point(e.X, e.Y);

                //create a square object to represent the template of the square
                Square s = new Square(startPoint, endPoint, p.Color);

                //refresh the canvas to prevent creating a vast amount of shapes
                ResetDrawingRegion();

                //redraw all shapes to preserve the ones that were already there
                RedrawAllShapes();

                //draw the square to the canvas
                s.Draw(g, p);

                //set the background of the canvas to the drawing region
                Canvas.BackgroundImage = drawingRegion;
            }
        }

        /// <summary>
        /// Used to set the bitmap to all white and refresh the canvas 
        /// </summary>
        public static void ResetDrawingRegion()
        {
            using Graphics g = Graphics.FromImage(drawingRegion);

            Canvas.Refresh();
            g.Clear(Canvas.BackColor);
        }

        /// <summary>
        /// On mouse move, all shapes are to be redrawn to preserve them and update the template for the shape being created
        /// </summary>
        public static void RedrawAllShapes()
        {
            using Graphics g = Graphics.FromImage(drawingRegion);

            Pen PenForEachShape;

            for (int i = 0; i < shapes.Count; i++)
            {
                PenForEachShape = new Pen(shapes[i].GetColor(), MainForm.PenSize);
                shapes[i].Draw(g, PenForEachShape);
                PenForEachShape.Dispose();
            }



            //foreach (Square square in shapes)
            //{
            //    PenForEachShape = new Pen(square.GetColor(), PenSize);
            //    square.Draw(g, PenForEachShape);
            //    PenForEachShape.Dispose();
            //}

            //foreach(Circle circle in shapes)
            //{
            //    PenForEachShape = new Pen(circle.GetColor());
            //    circle.Draw(circle.GetStart(), circle.GetEnd(), circle.GetRadius());
            //}
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            ShapeSelectionForm shapeSelectionForm = new ShapeSelectionForm();
            shapeSelectionForm.Show();
        }
        #endregion
    }
}
