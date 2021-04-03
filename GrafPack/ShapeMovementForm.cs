using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void trkbRotation_Scroll(object sender, EventArgs e)
        {
            txtDegree.Text = "Shape rotated by: " + trkbRotation.Value.ToString() + "°";
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
                        //MoveCircleDown();
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
                        //MoveCircleDown();
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
                        //MoveCircleDown();
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
                        //MoveCircleDown();
                        break;

                    case "Triangle":
                        MoveTriangleDown(g);
                        break;
                }

                MainForm.ApplyDrawingChange();
            }
        }


        private void UpdateSquare(Graphics g, Square square)
        {
            Square nonSelectedSquare = new Square(square.ShapeStart, square.ShapeEnd, square.ShapeColour);
            nonSelectedSquare.DrawSqaure(g, new Pen(square.ShapeColour, MainForm.PenSize));

            MainForm.shapes.Insert(ShapeSelectionForm.index, nonSelectedSquare);
            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            MainForm.ApplyDrawingChange();
            ResetShapeSelection();
        }

        private void UpdateTriangle(Graphics g, Triangle triangle)
        {
            Triangle nonSelectedTriangle = new Triangle(triangle.ShapeStart, triangle.ShapeEnd, triangle.ShapeColour);
            nonSelectedTriangle.DrawTriangle(g, new Pen(triangle.ShapeColour, MainForm.PenSize));

            MainForm.shapes.Insert(ShapeSelectionForm.index, nonSelectedTriangle);
            MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

            MainForm.ApplyDrawingChange();
            ResetShapeSelection();
        }

        public void ResetShapeSelection()
        {
            ShapeSelectionForm.index = -1;
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


        void ReplaceShapesInList(Shape oldShape, Shape newShape)
        {

        }

        private void ShapeMovementForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            for (int i = 0; i < MainForm.shapes.Count; i++)
            {
                switch (MainForm.shapes[i].ShapeType)
                {
                    case "Square":
                        UpdateSquare(g, (Square)MainForm.shapes[i]);
                        break;

                    case "Triangle":
                        UpdateTriangle(g, (Triangle)MainForm.shapes[i]);
                        break;
                }
            }
        }
    }
}
