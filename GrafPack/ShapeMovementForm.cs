using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace GrafPack
{
    public partial class ShapeMovementForm : Form
    {
        public int movementIncrement = 10;
        public int rotationIncrement;
        public static Point ShapeCenter;

        public ShapeMovementForm()
        {
            InitializeComponent();
        }

        //code refrenced form: https://stackoverflow.com/questions/13695317/rotate-a-point-around-another-point
        public Point RotatePoint(Point pointToRotate, Point centerPoint, double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            return new Point
            {
                X =
                    (int)
                    (cosTheta * (pointToRotate.X - centerPoint.X) -
                    sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X),
                Y =
                    (int)
                    (sinTheta * (pointToRotate.X - centerPoint.X) +
                    cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y)
            };
        }


        //
        public static void CalculateSquareCenter(Square square)
        {
            ShapeCenter.X = (square.ShapeEnd.X + square.ShapeStart.X) / 2;
            ShapeCenter.Y = (square.ShapeEnd.Y + square.ShapeStart.Y) / 2;
        }

        public static void CalculateTriangleCentre(Triangle triangle)
        {
            ShapeCenter.X = (int)(triangle.ShapeStart.X + triangle.ShapeEnd.X + triangle.ThridPoint.X) / 3;
            ShapeCenter.Y = (int)(triangle.ShapeStart.Y + triangle.ShapeEnd.Y + triangle.ThridPoint.Y) / 3;
        }

        private void trkbRotation_Scroll(object sender, EventArgs e)
        {
            txtDegree.Text = "Shape rotated by: " + trkbRotation.Value.ToString() + "°";
        }

        void RotateShape(String direction)
        {
            if (direction == "left")
            {
                rotationIncrement = -10;
            }
            else if (direction == "right")
            {
                rotationIncrement = 10;
            }

            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            if (ShapeSelectionForm.index != -1)
            {
                switch (MainForm.shapes[ShapeSelectionForm.index].ShapeType)
                {
                    case "Square":
                        RotateSquare(g);
                        break;

                    case "Triangle":
                        RotateTriangle(g);
                        break;
                }
            }

            MainForm.ApplyDrawingChange();
        }

        private void RotateSquare(Graphics g)
        {
            Square oldSquare = new Square(MainForm.shapes[ShapeSelectionForm.index].ShapeStart, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd, MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            Square rotatedSquare = new Square(RotatePoint(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd, ShapeCenter, rotationIncrement),
            RotatePoint(MainForm.shapes[ShapeSelectionForm.index].ShapeStart, ShapeCenter, rotationIncrement),
            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            oldSquare.DrawSqaure(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            rotatedSquare.DrawSqaure(g, MainForm.mainPen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, rotatedSquare);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            rotatedSquare.DrawSqaure(g, CreateHighlightPen());
        }

        private void RotateTriangle(Graphics g)
        {
            Triangle oldTriangle = new Triangle(MainForm.shapes[ShapeSelectionForm.index].ShapeStart, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd, MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            Triangle rotatedTriangle = new Triangle(RotatePoint(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd, ShapeCenter, rotationIncrement),
            RotatePoint(MainForm.shapes[ShapeSelectionForm.index].ShapeStart, ShapeCenter, rotationIncrement),
            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            oldTriangle.DrawTriangle(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            rotatedTriangle.DrawTriangle(g, MainForm.mainPen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, rotatedTriangle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            rotatedTriangle.DrawTriangle(g, CreateHighlightPen());
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            if (ShapeSelectionForm.index != -1)
            {
                switch (MainForm.shapes[ShapeSelectionForm.index].ShapeType)
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
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            if (ShapeSelectionForm.index != -1)
            {
                switch (MainForm.shapes[ShapeSelectionForm.index].ShapeType)
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
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            if (ShapeSelectionForm.index != -1)
            {
                switch (MainForm.shapes[ShapeSelectionForm.index].ShapeType)
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
            }
        }

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

        private void btnDown_Click(object sender, EventArgs e)
        {
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            if (ShapeSelectionForm.index != -1)
            {
                switch (MainForm.shapes[ShapeSelectionForm.index].ShapeType)
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
            }
        }

        private void UpdateShape(Graphics g, Shape shape)
        {
            if (ShapeSelectionForm.index != -1)
            {
                switch (shape.ShapeType)
                {
                    case "Square":
                        Square nonSelectedSquare = new Square(shape.ShapeStart, shape.ShapeEnd, shape.ShapeColour);
                        nonSelectedSquare.DrawSqaure(g, new Pen(shape.ShapeColour, MainForm.PenSize));
                        break;

                    case "Circle":
                        Circle nonSelectedCircle = new Circle(shape.ShapeColour, shape.ShapeEnd, shape.Radius);
                        nonSelectedCircle.DrawCircle();
                        break;

                    case "Triangle":
                        Triangle nonSelectedTriangle = new Triangle(shape.ShapeStart, shape.ShapeEnd, shape.ShapeColour);
                        nonSelectedTriangle.DrawTriangle(g, new Pen(shape.ShapeColour, MainForm.PenSize));
                        break;
                }
                MainForm.ApplyDrawingChange();
            }
        }

        private void UpdateAllOtherShapes(int index)
        {

        }

        private void MoveTriangleDown(Graphics g)
        {
            Pen movedShapePen;

            Triangle oldTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            Triangle newTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X,
                                MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y + movementIncrement),
                                new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y + movementIncrement),
                                MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            oldTriangle.DrawTriangle(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, MainForm.PenSize);

            newTriangle.DrawTriangle(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, newTriangle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newTriangle.DrawTriangle(g, CreateHighlightPen());

            CalculateTriangleCentre(newTriangle);
        }

        private void MoveTriangleUp(Graphics g)
        {
            Pen movedShapePen;

            Triangle oldTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            Triangle newTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X,
                                MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y - movementIncrement),
                                new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y - movementIncrement),
                                MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            oldTriangle.DrawTriangle(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, MainForm.PenSize);

            newTriangle.DrawTriangle(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, newTriangle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newTriangle.DrawTriangle(g, CreateHighlightPen());

            CalculateTriangleCentre(newTriangle);
        }

        private void MoveTriangleRight(Graphics g)
        {
            Pen movedShapePen;

            Triangle oldTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            Triangle newTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X + movementIncrement,
                                MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X + movementIncrement,
                                MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            oldTriangle.DrawTriangle(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, MainForm.PenSize);

            newTriangle.DrawTriangle(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, newTriangle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newTriangle.DrawTriangle(g, CreateHighlightPen());

            CalculateTriangleCentre(newTriangle);
        }

        private void MoveTriangleLeft(Graphics g)
        {
            Pen movedShapePen;

            Triangle oldTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            Triangle newTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X - movementIncrement,
                                MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X - movementIncrement,
                                MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            oldTriangle.DrawTriangle(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, MainForm.PenSize);

            newTriangle.DrawTriangle(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, newTriangle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newTriangle.DrawTriangle(g, CreateHighlightPen());

            CalculateTriangleCentre(newTriangle);
        }

        public void MoveSquareDown(Graphics g)
        {
            Pen movedShapePen;

            Square oldSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            Square movedSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y + movementIncrement),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y + movementIncrement),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            oldSquare.DrawSqaure(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, MainForm.PenSize);

            movedSquare.DrawSqaure(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, movedSquare);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            movedSquare.DrawSqaure(g, CreateHighlightPen());

            CalculateSquareCenter(movedSquare);
        }

        public void MoveSquareLeft(Graphics g)
        {
            Pen movedShapePen;

            Square oldSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            Square movedSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X - movementIncrement,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X - movementIncrement,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            oldSquare.DrawSqaure(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, MainForm.PenSize);

            movedSquare.DrawSqaure(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, movedSquare);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            movedSquare.DrawSqaure(g, CreateHighlightPen());

            CalculateSquareCenter(movedSquare);
        }

        public void MoveSquareUp(Graphics g)
        {
            Pen movedShapePen;

            Square oldSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            Square movedSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y - movementIncrement),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y - movementIncrement),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            oldSquare.DrawSqaure(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, MainForm.PenSize);

            movedSquare.DrawSqaure(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, movedSquare);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            movedSquare.DrawSqaure(g, CreateHighlightPen());

            CalculateSquareCenter(movedSquare);
        }

        public void MoveSquareRight(Graphics g)
        {
            Pen movedShapePen;

            Square oldSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            Square movedSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X + movementIncrement,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X + movementIncrement,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            oldSquare.DrawSqaure(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, MainForm.PenSize);

            movedSquare.DrawSqaure(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, movedSquare);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            movedSquare.DrawSqaure(g, CreateHighlightPen());

            CalculateSquareCenter(movedSquare);
        }

        public void MoveCircleDown()
        {
            Circle oldCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y), MainForm.shapes[ShapeSelectionForm.index].Radius);

            Circle newCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y + movementIncrement), MainForm.shapes[ShapeSelectionForm.index].Radius);

            oldCircle.DeleteCircle();

            MainForm.shapes.Insert(ShapeSelectionForm.index, newCircle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newCircle.HighlightCircle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour);
        }

        public void MoveCircleLeft()
        {
            Circle oldCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y), MainForm.shapes[ShapeSelectionForm.index].Radius);

            Circle newCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X - movementIncrement, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y), MainForm.shapes[ShapeSelectionForm.index].Radius);

            oldCircle.DeleteCircle();

            MainForm.shapes.Insert(ShapeSelectionForm.index, newCircle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newCircle.HighlightCircle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour);
        }

        public void MoveCircleRight()
        {
            Circle oldCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y), MainForm.shapes[ShapeSelectionForm.index].Radius);

            Circle newCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X + movementIncrement, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y), MainForm.shapes[ShapeSelectionForm.index].Radius);

            oldCircle.DeleteCircle();

            MainForm.shapes.Insert(ShapeSelectionForm.index, newCircle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newCircle.HighlightCircle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour);
        }

        public void MoveCircleUp()
        {
            Circle oldCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y), MainForm.shapes[ShapeSelectionForm.index].Radius);

            Circle newCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y - movementIncrement), MainForm.shapes[ShapeSelectionForm.index].Radius);

            oldCircle.DeleteCircle();

            MainForm.shapes.Insert(ShapeSelectionForm.index, newCircle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newCircle.HighlightCircle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour);
        }

        private void ShapeMovementForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            for (int i = 0; i < MainForm.shapes.Count; i++)
            {
                if (ShapeSelectionForm.index != -1)
                {
                    switch (MainForm.shapes[i].ShapeType)
                    {
                        case "Square":
                            UpdateShape(g, (Square)MainForm.shapes[i]);
                            break;

                        case "Circle":
                            UpdateShape(g, (Circle)MainForm.shapes[i]);
                            break;

                        case "Triangle":
                            UpdateShape(g, (Triangle)MainForm.shapes[i]);
                            break;
                    }
                }
            }
            ShapeSelectionForm.index = -1;
        }

        /// <summary>
        /// Rotates a shape right
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            RotateShape("right");
        }

        /// <summary>
        /// Rotates a shape left
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            RotateShape("left");
        }
    }
}
