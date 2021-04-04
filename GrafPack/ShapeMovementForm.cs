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
        public int movemenIncrement = 10;

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

        private Point ShapeCenter(Shape shape)
        {
            Point center;

            center = new Point((shape.ShapeStart.X + shape.ShapeEnd.X) / 2, (shape.ShapeStart.Y + shape.ShapeEnd.Y) / 2);

            return center;
        }

        private void trkbRotation_Scroll(object sender, EventArgs e)
        {
            txtDegree.Text = "Shape rotated by: " + trkbRotation.Value.ToString() + "°";

            RotateShape();
        }

        void RotateShape()
        {

           // trkbRotation.Value * (Math.PI / 360)
            Pen deletePen = new Pen(MainForm.Canvas.BackColor, MainForm.PenSize);

            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);
            switch (MainForm.shapes[ShapeSelectionForm.index].ShapeType)
            {


                case "Square":
      
                    Square oldSquare = new Square(MainForm.shapes[ShapeSelectionForm.index].ShapeStart, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd, MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

                    Square rotatedSquare = new Square(RotatePoint(MainForm.shapes[ShapeSelectionForm.index].ShapeStart, new Point(300, 300), 1),
                    RotatePoint(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd, new Point (300,300), 1),
                    MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

                //    MainForm.shapes[ShapeSelectionForm.index].CalculateCentre()
                    oldSquare.DrawSqaure(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

                    rotatedSquare.DrawSqaure(g, MainForm.mainPen);

                    MainForm.shapes.Insert(ShapeSelectionForm.index, rotatedSquare);

                    MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

                    rotatedSquare.DrawSqaure(g, CreateHighlightPen());
                    break;

                case "Triangle":

                    break;
            }


            MainForm.ApplyDrawingChange();
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
                                MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y + movemenIncrement),
                                new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y + movemenIncrement),
                                MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            oldTriangle.DrawTriangle(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, MainForm.PenSize);

            newTriangle.DrawTriangle(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, newTriangle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newTriangle.DrawTriangle(g, CreateHighlightPen());
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
                                MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y - movemenIncrement),
                                new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y - movemenIncrement),
                                MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            oldTriangle.DrawTriangle(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, MainForm.PenSize);

            newTriangle.DrawTriangle(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, newTriangle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newTriangle.DrawTriangle(g, CreateHighlightPen());

        }

        private void MoveTriangleRight(Graphics g)

        {
            Pen movedShapePen;

            Triangle oldTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            Triangle newTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X + movemenIncrement,
                                MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X + movemenIncrement,
                                MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            oldTriangle.DrawTriangle(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, MainForm.PenSize);

            newTriangle.DrawTriangle(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, newTriangle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newTriangle.DrawTriangle(g, CreateHighlightPen());

        }

        private void MoveTriangleLeft(Graphics g)

        {
            Pen movedShapePen;

            Triangle oldTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            Triangle newTriangle = new Triangle(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X - movemenIncrement,
                                MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X - movemenIncrement,
                                MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            oldTriangle.DrawTriangle(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, MainForm.PenSize);

            newTriangle.DrawTriangle(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, newTriangle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newTriangle.DrawTriangle(g, CreateHighlightPen());

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
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y + movemenIncrement),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y + movemenIncrement),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            oldSquare.DrawSqaure(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, MainForm.PenSize);

            movedSquare.DrawSqaure(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, movedSquare);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            movedSquare.DrawSqaure(g, CreateHighlightPen());
        }

        public void MoveSquareLeft(Graphics g)
        {
            Pen movedShapePen;

            Square oldSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            Square movedSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X - movemenIncrement,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X - movemenIncrement,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            oldSquare.DrawSqaure(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, MainForm.PenSize);

            movedSquare.DrawSqaure(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, movedSquare);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            movedSquare.DrawSqaure(g, CreateHighlightPen());
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
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y - movemenIncrement),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y - movemenIncrement),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            oldSquare.DrawSqaure(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, MainForm.PenSize);

            movedSquare.DrawSqaure(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, movedSquare);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            movedSquare.DrawSqaure(g, CreateHighlightPen());
        }

        public void MoveSquareRight(Graphics g)
        {
            Pen movedShapePen;

            Square oldSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            Square movedSquare = new Square(new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeStart.X + movemenIncrement,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeStart.Y),
                                            new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X + movemenIncrement,
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y),
                                            MainForm.shapes[ShapeSelectionForm.index].ShapeColour);

            oldSquare.DrawSqaure(g, new Pen(MainForm.Canvas.BackColor, MainForm.PenSize));

            movedShapePen = new Pen(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, MainForm.PenSize);

            movedSquare.DrawSqaure(g, movedShapePen);

            MainForm.shapes.Insert(ShapeSelectionForm.index, movedSquare);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            movedSquare.DrawSqaure(g, CreateHighlightPen());
        }

        public void MoveCircleDown()
        {
            Circle oldCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y), MainForm.shapes[ShapeSelectionForm.index].Radius);

            Circle newCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y + movemenIncrement), MainForm.shapes[ShapeSelectionForm.index].Radius);

            oldCircle.DeleteCircle();

            MainForm.shapes.Insert(ShapeSelectionForm.index, newCircle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newCircle.HighlightCircle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour);
        }

        public void MoveCircleLeft()
        {
            Circle oldCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y), MainForm.shapes[ShapeSelectionForm.index].Radius);

            Circle newCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X - movemenIncrement, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y), MainForm.shapes[ShapeSelectionForm.index].Radius);

            oldCircle.DeleteCircle();

            MainForm.shapes.Insert(ShapeSelectionForm.index, newCircle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newCircle.HighlightCircle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour);
        }

        public void MoveCircleRight()
        {
            Circle oldCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y), MainForm.shapes[ShapeSelectionForm.index].Radius);

            Circle newCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X + movemenIncrement, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y), MainForm.shapes[ShapeSelectionForm.index].Radius);

            oldCircle.DeleteCircle();

            MainForm.shapes.Insert(ShapeSelectionForm.index, newCircle);

            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            newCircle.HighlightCircle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour);
        }

        public void MoveCircleUp()
        {
            Circle oldCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y), MainForm.shapes[ShapeSelectionForm.index].Radius);

            Circle newCircle = new Circle(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, new Point(MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.X, MainForm.shapes[ShapeSelectionForm.index].ShapeEnd.Y - movemenIncrement), MainForm.shapes[ShapeSelectionForm.index].Radius);

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

        private void button1_Click(object sender, EventArgs e)
        {
            RotateShape();

        }
    }
}
