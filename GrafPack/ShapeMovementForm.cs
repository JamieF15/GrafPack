using System;
using System.Drawing;
using System.Windows.Forms;

namespace GrafPack
{
    public partial class ShapeMovementForm : Form
    {
        //states whether or not the form is open or not
        public static bool isOpen = false;

        public ShapeMovementForm()
        {
            InitializeComponent();
        }

        #region Variables
        //the movement increment when a shape is moved
        public int movementIncrement = 10;

        //how many degrees a shape will rotate every time a relevant button is clicked
        public int rotationIncrement;

        //used to stores the center of a shape for rotation
        public static Point ShapeCenter;
        #endregion

        private Pen CreateHighlightPen()
        {
            float[] dashValues = { 1, 5 };

            //pen to highlight shapes with
            Pen highlightPen = new Pen(MainForm.Canvas.BackColor, MainForm.PenSize)
            {
                DashPattern = dashValues
            };

            return highlightPen;
        }

        /// <summary>
        /// Rotates a point around another point by a certain angle
        /// </summary>
        /// <param name="pointToRotate">The point of a shape that is being rotated</param>
        /// <param name="centerPoint">the middle of the shape</param>
        /// <param name="angleInDegrees">The angle to rotate by</param>
        /// <returns></returns>
        //code refrenced form: https://stackoverflow.com/questions/13695317/rotate-a-point-around-another-point
        public Point RotatePoint(Point pointToRotate, Point centerPoint)
        {
            //convert the angle in radians
            double angleInRadians = rotationIncrement * (Math.PI / 180);

            //calculate the cosine of the angle
            double cosTheta = Math.Cos(angleInRadians);

            //calculate the sine of the angle
            double sinTheta = Math.Sin(angleInRadians);

            //return the rotated point
            return new Point
            {
                X = Convert.ToInt32(Math.Cos(angleInRadians) * (pointToRotate.X - centerPoint.X) - Math.Sin(angleInRadians) * (pointToRotate.Y - centerPoint.Y) + centerPoint.X),
                Y = Convert.ToInt32(Math.Sin(angleInRadians) * (pointToRotate.X - centerPoint.X) + Math.Cos(angleInRadians) * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y)
            };
        }

        /// <summary>
        /// Calculate the centre of a square object
        /// </summary>
        /// <param name="square">The square to find the centre of</param>
        public static void CalculateSquareCenter(Square square)
        {
            ShapeCenter.X = (square.Start.X + square.End.X) / 2;
            ShapeCenter.Y = (square.Start.Y + square.End.Y) / 2;
        }

        /// <summary>
        /// Calculates the centre of the selected triangle
        /// </summary>
        /// <param name="triangle"></param>
        public static void CalculateTriangleCentre(Triangle triangle)
        {
            ShapeCenter.X = (int)(triangle.Start.X + triangle.End.X + triangle.ThridPoint.X) / 3;
            ShapeCenter.Y = (int)(triangle.Start.Y + triangle.End.Y + triangle.ThridPoint.Y) / 3;
        }

        /// <summary>
        /// Find the direction to rotate the shape in
        /// </summary>
        /// <param name="direction">The direction</param>
        void DetermineRotationDirection(string direction)
        {
            //if the direction is left, set the rotation increment to minus 10
            if (direction == "left")
            {
                rotationIncrement = -5;
            }
            //if the direction is right, set the rotation increment to 10
            else if (direction == "right")
            {
                rotationIncrement = 5;
            }
        }

        /// <summary>
        /// Rotates the shape in the selected direction
        /// </summary>
        /// <param name="direction"></param>
        void RotateShape(String direction)
        {
            //determine the direction to rotate the shape
            DetermineRotationDirection(direction);

            //draw to the drawing region
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            //if the shape list is not empty
            if (ShapeSelectionForm.index != -1)
            {
                //switch statement on the shape type of the selected shape
                switch (MainForm.shapes[ShapeSelectionForm.index].Type)
                {
                    case "Square":
                        RotateSquare(g);
                        break;

                    case "Triangle":
                        RotateTriangle(g);
                        break;

                    case "Circle":
                        MessageBox.Show("Circles cannot be rotated.");
                        break;
                }
            }
        }

        /// <summary>
        /// Rotate a square 
        /// </summary>
        /// <param name="g"></param>
        private void RotateSquare(Graphics g)
        {
            //old square object to delete the old one
            Square oldSquare = new Square(MainForm.shapes[ShapeSelectionForm.index].Start,
                                          MainForm.shapes[ShapeSelectionForm.index].End,
                                          MainForm.shapes[ShapeSelectionForm.index].Colour);

            //square object with rotated points 
            Square rotatedSquare = new Square(RotatePoint(MainForm.shapes[ShapeSelectionForm.index].Start, ShapeCenter),
                                              RotatePoint(MainForm.shapes[ShapeSelectionForm.index].End, ShapeCenter),
                                                          MainForm.shapes[ShapeSelectionForm.index].Colour);

            //delete the old square
            oldSquare.DrawSqaure(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            //draw the rotated square
            rotatedSquare.DrawSqaure(g, new Pen(rotatedSquare.Colour, MainForm.PenSize));

            //insert the square into the index of the selected shape
            MainForm.shapes.Insert(ShapeSelectionForm.index, rotatedSquare);

            //remove the shape after the inserted shape
            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            //highlight the newly rotated square
            rotatedSquare.DrawSqaure(g, CreateHighlightPen());

            MainForm.ApplyDrawingChange();
        }

        /// <summary>
        /// Rotate a triangle
        /// </summary>
        /// <param name="g"></param>
        private void RotateTriangle(Graphics g)
        {
            //old triangle used to delete the old one
            Triangle oldTriangle = new Triangle(MainForm.shapes[ShapeSelectionForm.index].Start,
                                                MainForm.shapes[ShapeSelectionForm.index].End,
                                                MainForm.shapes[ShapeSelectionForm.index].Colour);

            //triangle with rotated points
            Triangle rotatedTriangle = new Triangle(RotatePoint(MainForm.shapes[ShapeSelectionForm.index].Start, ShapeCenter),
                                                    RotatePoint(MainForm.shapes[ShapeSelectionForm.index].End, ShapeCenter),
                                                    MainForm.shapes[ShapeSelectionForm.index].Colour);

            //delete the old triangle
            oldTriangle.Draw(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            //draw the rotated triangle
            rotatedTriangle.Draw(g, new Pen(rotatedTriangle.Colour, MainForm.PenSize));

            //replace the shape in the index of the selected shape with the rotated triangle
            MainForm.shapes.Insert(ShapeSelectionForm.index, rotatedTriangle);

            //remove shape after the newly inserted one
            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            //draw the rotated triangle
            rotatedTriangle.Draw(g, CreateHighlightPen());

            MainForm.ApplyDrawingChange();
        }

        #region Movement Buttons

        /// <summary>
        /// Move the selected shape right
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, EventArgs e)
        {
            //draw to the drawing region
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            if (ShapeSelectionForm.index != -1)
            {
                switch (MainForm.shapes[ShapeSelectionForm.index].Type)
                {
                    case "Square":
                        MoveSquareRight(g);
                        break;

                    case "Circle":
                        MoveCircleRight();
                        break;

                    case "Triangle":
                        MoveTriangleRight(g);
                        break;
                }
                MainForm.ApplyDrawingChange();
                RepairAllOtherShapes();
            }
        }

        /// <summary>
        /// Moves the selected shape up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            if (ShapeSelectionForm.index != -1)
            {
                switch (MainForm.shapes[ShapeSelectionForm.index].Type)
                {
                    case "Square":
                        MoveSquareUp(g);
                        break;

                    case "Circle":
                        MoveCircleUp();
                        break;

                    case "Triangle":
                        MoveTriangleUp(g);
                        break;
                }
                MainForm.ApplyDrawingChange();
                RepairAllOtherShapes();
            }
        }

        /// <summary>
        /// Move the selected shape left
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeft_Click(object sender, EventArgs e)
        {
            //draw to the drawing region
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            //if the shape list is not empty 
            if (ShapeSelectionForm.index != -1)
            {
                //switch statement on the shape type
                switch (MainForm.shapes[ShapeSelectionForm.index].Type)
                {
                    case "Square":
                        MoveSquareLeft(g);
                        break;

                    case "Circle":
                        MoveCircleLeft();
                        break;

                    case "Triangle":
                        MoveTriangleLeft(g);
                        break;
                }
                MainForm.ApplyDrawingChange();
                RepairAllOtherShapes();
            }
        }

        /// <summary>
        /// Moves a shape down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            if (ShapeSelectionForm.index != -1)
            {
                switch (MainForm.shapes[ShapeSelectionForm.index].Type)
                {
                    case "Square":
                        MoveSquareDown(g);
                        break;

                    case "Circle":
                        MoveCircleDown();
                        break;

                    case "Triangle":
                        MoveTriangleDown(g);
                        break;
                }
                MainForm.ApplyDrawingChange();
                RepairAllOtherShapes();
            }
        }

        /// <summary>
        /// Rotates a shape right
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            //rotate the selected shape right
            RotateShape("right");

            //repair all other shapes to preserve them
            RepairAllOtherShapes();
        }

        /// <summary>
        /// Rotates a shape left
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            //rotate the selected shape left
            RotateShape("left");

            //repair all other shapes to preserve them
            RepairAllOtherShapes();
        }
        #endregion

        /// <summary>
        /// Ensures when a shape is moved or rotated, all other shapes will not be damaged in the process
        /// </summary>
        public static void RepairAllOtherShapes()
        {
            //draw to the drawing region
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            //loop through the shape array
            for (int i = 0; i < MainForm.shapes.Count; i++)
            {
                //if the index is not equal to the index of the selected shape, up date it
                if (ShapeSelectionForm.index != i)
                {
                    //update all shapes that are not the selected shape
                    UpdateShape(g, MainForm.shapes[i]);
                }
            }
        }

        /// <summary>
        /// Updates a shape by redrawing it
        /// </summary>
        /// <param name="g"></param>
        /// <param name="shape"></param>
        public static void UpdateShape(Graphics g, Shape shape)
        {
            //if the index not -1, meaning a shape is not selected
            if (ShapeSelectionForm.index != -1)
            {
                //switch on the shape type
                switch (shape.Type)
                {
                    case "Square":
                        Square nonSelectedSquare = new Square(shape.Start, shape.End, shape.Colour);
                        nonSelectedSquare.DrawSqaure(g, new Pen(shape.Colour, MainForm.PenSize));
                        break;

                    case "Circle":
                        Circle nonSelectedCircle = new Circle(shape.Colour, shape.Start, shape.End, shape.Radius);
                        nonSelectedCircle.Draw();
                        break;

                    case "Triangle":
                        Triangle nonSelectedTriangle = new Triangle(shape.Start, shape.End, shape.Colour);
                        nonSelectedTriangle.Draw(g, new Pen(shape.Colour, MainForm.PenSize));
                        break;
                }
                //apply the drawing change
                MainForm.ApplyDrawingChange();
            }
        }

        #region Triangle Movement

        /// <summary>
        /// Moves a triangle down
        /// </summary>
        /// <param name="g"></param>
        private void MoveTriangleDown(Graphics g)
        {
            //pen for the moved shape
            Pen movedShapePen;

            //old triangle object to replace to non-moved triangle
            Triangle oldTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X,
                                            MainForm.shapes[ShapeSelectionForm.index].Start.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].End.X,
                                            MainForm.shapes[ShapeSelectionForm.index].End.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].Colour);

            //triangle object to be placed as the moved triangle
            Triangle newTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X,
                                MainForm.shapes[ShapeSelectionForm.index].Start.Y + movementIncrement),
                                new Point(MainForm.shapes[ShapeSelectionForm.index].End.X,
                                MainForm.shapes[ShapeSelectionForm.index].End.Y + movementIncrement),
                                MainForm.shapes[ShapeSelectionForm.index].Colour);

            //delete the old triangle
            oldTriangle.Draw(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            //set the pen to the colour of the shape
            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].Colour, MainForm.PenSize);

            //draw the moved triangle
            newTriangle.Draw(g, movedShapePen);

            //insert the new triangle into the array element of the selected shape
            MainForm.shapes.Insert(ShapeSelectionForm.index, newTriangle);

            //remove the shape after the inserted shape
            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            //highlight the new triangle
            newTriangle.Draw(g, CreateHighlightPen());

            //calculate the triangle's centre
            CalculateTriangleCentre(newTriangle);
        }

        private void MoveTriangleUp(Graphics g)
        {
            Pen movedShapePen;

            Triangle oldTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X,
                                            MainForm.shapes[ShapeSelectionForm.index].Start.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].End.X,
                                            MainForm.shapes[ShapeSelectionForm.index].End.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].Colour);

            Triangle newTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X,
                                MainForm.shapes[ShapeSelectionForm.index].Start.Y - movementIncrement),
                                new Point(MainForm.shapes[ShapeSelectionForm.index].End.X,
                                MainForm.shapes[ShapeSelectionForm.index].End.Y - movementIncrement),
                                MainForm.shapes[ShapeSelectionForm.index].Colour);

            oldTriangle.Draw(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].Colour, MainForm.PenSize);

            newTriangle.Draw(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, newTriangle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newTriangle.Draw(g, CreateHighlightPen());

            CalculateTriangleCentre(newTriangle);
        }

        private void MoveTriangleRight(Graphics g)
        {
            Pen movedShapePen;

            Triangle oldTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X,
                                            MainForm.shapes[ShapeSelectionForm.index].Start.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].End.X,
                                            MainForm.shapes[ShapeSelectionForm.index].End.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].Colour);

            Triangle newTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X + movementIncrement,
                                MainForm.shapes[ShapeSelectionForm.index].Start.Y),
                                new Point(MainForm.shapes[ShapeSelectionForm.index].End.X + movementIncrement,
                                MainForm.shapes[ShapeSelectionForm.index].End.Y),
                                MainForm.shapes[ShapeSelectionForm.index].Colour);

            oldTriangle.Draw(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].Colour, MainForm.PenSize);

            newTriangle.Draw(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, newTriangle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newTriangle.Draw(g, CreateHighlightPen());

            CalculateTriangleCentre(newTriangle);
        }

        private void MoveTriangleLeft(Graphics g)
        {
            Pen movedShapePen;

            Triangle oldTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X,
                                            MainForm.shapes[ShapeSelectionForm.index].Start.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].End.X,
                                            MainForm.shapes[ShapeSelectionForm.index].End.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].Colour);

            Triangle newTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X - movementIncrement,
                                MainForm.shapes[ShapeSelectionForm.index].Start.Y),
                                new Point(MainForm.shapes[ShapeSelectionForm.index].End.X - movementIncrement,
                                MainForm.shapes[ShapeSelectionForm.index].End.Y),
                                MainForm.shapes[ShapeSelectionForm.index].Colour);

            oldTriangle.Draw(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].Colour, MainForm.PenSize);

            newTriangle.Draw(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, newTriangle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newTriangle.Draw(g, CreateHighlightPen());

            CalculateTriangleCentre(newTriangle);
        }
        #endregion

        #region Square Movement

        public void MoveSquareDown(Graphics g)
        {
            Pen movedShapePen;

            Square oldSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X,
                                            MainForm.shapes[ShapeSelectionForm.index].Start.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].End.X,
                                            MainForm.shapes[ShapeSelectionForm.index].End.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].Colour);

            Square movedSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X,
                                            MainForm.shapes[ShapeSelectionForm.index].Start.Y + movementIncrement),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].End.X,
                                            MainForm.shapes[ShapeSelectionForm.index].End.Y + movementIncrement),
                                            MainForm.shapes[ShapeSelectionForm.index].Colour);

            oldSquare.DrawSqaure(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].Colour, MainForm.PenSize);

            movedSquare.DrawSqaure(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, movedSquare);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            movedSquare.DrawSqaure(g, CreateHighlightPen());

            CalculateSquareCenter(movedSquare);
        }

        public void MoveSquareLeft(Graphics g)
        {
            Pen movedShapePen;

            Square oldSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X,
                                            MainForm.shapes[ShapeSelectionForm.index].Start.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].End.X,
                                            MainForm.shapes[ShapeSelectionForm.index].End.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].Colour);

            Square movedSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X - movementIncrement,
                                            MainForm.shapes[ShapeSelectionForm.index].Start.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].End.X - movementIncrement,
                                            MainForm.shapes[ShapeSelectionForm.index].End.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].Colour);

            oldSquare.DrawSqaure(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].Colour, MainForm.PenSize);

            movedSquare.DrawSqaure(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, movedSquare);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            movedSquare.DrawSqaure(g, CreateHighlightPen());

            CalculateSquareCenter(movedSquare);
        }

        public void MoveSquareUp(Graphics g)
        {
            Pen movedShapePen;

            Square oldSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X,
                                            MainForm.shapes[ShapeSelectionForm.index].Start.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].End.X,
                                            MainForm.shapes[ShapeSelectionForm.index].End.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].Colour);

            Square movedSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X,
                                            MainForm.shapes[ShapeSelectionForm.index].Start.Y - movementIncrement),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].End.X,
                                            MainForm.shapes[ShapeSelectionForm.index].End.Y - movementIncrement),
                                            MainForm.shapes[ShapeSelectionForm.index].Colour);

            oldSquare.DrawSqaure(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].Colour, MainForm.PenSize);

            movedSquare.DrawSqaure(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, movedSquare);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            movedSquare.DrawSqaure(g, CreateHighlightPen());

            CalculateSquareCenter(movedSquare);
        }

        public void MoveSquareRight(Graphics g)
        {
            Pen movedShapePen;

            Square oldSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X,
                                            MainForm.shapes[ShapeSelectionForm.index].Start.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].End.X,
                                            MainForm.shapes[ShapeSelectionForm.index].End.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].Colour);

            Square movedSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X + movementIncrement,
                                            MainForm.shapes[ShapeSelectionForm.index].Start.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].End.X + movementIncrement,
                                            MainForm.shapes[ShapeSelectionForm.index].End.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].Colour);

            oldSquare.DrawSqaure(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].Colour, MainForm.PenSize);

            movedSquare.DrawSqaure(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, movedSquare);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            movedSquare.DrawSqaure(g, CreateHighlightPen());

            CalculateSquareCenter(movedSquare);
        }
        #endregion

        #region Circle Movement
        public void MoveCircleDown()
        {
            Circle oldCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].Colour, new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X, MainForm.shapes[ShapeSelectionForm.index].Start.Y), new Point(MainForm.shapes[ShapeSelectionForm.index].End.X, MainForm.shapes[ShapeSelectionForm.index].End.Y), MainForm.shapes[ShapeSelectionForm.index].Radius);

            Circle newCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].Colour, new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X, MainForm.shapes[ShapeSelectionForm.index].Start.Y), new Point(MainForm.shapes[ShapeSelectionForm.index].End.X, MainForm.shapes[ShapeSelectionForm.index].End.Y + movementIncrement), MainForm.shapes[ShapeSelectionForm.index].Radius);

            oldCircle.Delete();

            MainForm.shapes.Insert(ShapeSelectionForm.index, newCircle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newCircle.Highlight(MainForm.shapes[ShapeSelectionForm.index].Colour);
        }

        public void MoveCircleLeft()
        {
            Circle oldCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].Colour, new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X, MainForm.shapes[ShapeSelectionForm.index].Start.Y), new Point(MainForm.shapes[ShapeSelectionForm.index].End.X, MainForm.shapes[ShapeSelectionForm.index].End.Y), MainForm.shapes[ShapeSelectionForm.index].Radius);

            Circle newCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].Colour, new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X, MainForm.shapes[ShapeSelectionForm.index].Start.Y), new Point(MainForm.shapes[ShapeSelectionForm.index].End.X - movementIncrement, MainForm.shapes[ShapeSelectionForm.index].End.Y), MainForm.shapes[ShapeSelectionForm.index].Radius);

            oldCircle.Delete();

            MainForm.shapes.Insert(ShapeSelectionForm.index, newCircle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newCircle.Highlight(MainForm.shapes[ShapeSelectionForm.index].Colour);
        }

        public void MoveCircleRight()
        {
            Circle oldCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].Colour, new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X, MainForm.shapes[ShapeSelectionForm.index].Start.Y), new Point(MainForm.shapes[ShapeSelectionForm.index].End.X, MainForm.shapes[ShapeSelectionForm.index].End.Y), MainForm.shapes[ShapeSelectionForm.index].Radius);

            Circle newCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].Colour, new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X, MainForm.shapes[ShapeSelectionForm.index].Start.Y), new Point(MainForm.shapes[ShapeSelectionForm.index].End.X + movementIncrement, MainForm.shapes[ShapeSelectionForm.index].End.Y), MainForm.shapes[ShapeSelectionForm.index].Radius);

            oldCircle.Delete();

            MainForm.shapes.Insert(ShapeSelectionForm.index, newCircle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newCircle.Highlight(MainForm.shapes[ShapeSelectionForm.index].Colour);
        }

        public void MoveCircleUp()
        {
            Circle oldCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].Colour, new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X, MainForm.shapes[ShapeSelectionForm.index].Start.Y), new Point(MainForm.shapes[ShapeSelectionForm.index].End.X, MainForm.shapes[ShapeSelectionForm.index].End.Y), MainForm.shapes[ShapeSelectionForm.index].Radius);

            Circle newCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].Colour, new Point(MainForm.shapes[ShapeSelectionForm.index].Start.X, MainForm.shapes[ShapeSelectionForm.index].Start.Y), new Point(MainForm.shapes[ShapeSelectionForm.index].End.X, MainForm.shapes[ShapeSelectionForm.index].End.Y - movementIncrement), MainForm.shapes[ShapeSelectionForm.index].Radius);

            oldCircle.Delete();

            MainForm.shapes.Insert(ShapeSelectionForm.index, newCircle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newCircle.Highlight(MainForm.shapes[ShapeSelectionForm.index].Colour);
        }
        #endregion

        /// <summary>
        /// When the form closes, reset all shapse to repair them and unselect them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShapeMovementForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //draw to the drawing region
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            //check if there is a shape to update
            if (ShapeSelectionForm.index != -1)
            {
                //loop through the shape list
                for (int i = 0; i < MainForm.shapes.Count; i++)
                {
                    //update the shape
                    UpdateShape(g, MainForm.shapes[i]);
                }
            }
            //reset the shape selection
            ShapeSelectionForm.index = -1;

            //set the isOpen bool to false to show that is it closed
            isOpen = false;
        }

        /// <summary>
        /// When hte form loads, set the bool that states if it is open to true to prevent more than one shape to be moved at a time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShapeMovementForm_Load(object sender, EventArgs e)
        {
            isOpen = true;
        }

        /// <summary>
        /// Exits the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
