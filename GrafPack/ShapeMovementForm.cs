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

        }

        private void btnUp_Click(object sender, EventArgs e)
        {

        }

        private void btnLeft_Click(object sender, EventArgs e)
        {

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            Pen movedShapePen;

            float[] dashValues = { 1, 5 };

            //pen to highlight shapes with
            Pen highlightPen = new Pen(MainForm.shapes[ShapeSelectionForm.index].ShapeColour, 3)
            {
                DashPattern = dashValues
            };


            switch (MainForm.shapes[ShapeSelectionForm.index].ShapeType)
            {

                case "Square":


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

                    //movedSquare.DrawSqaure(g, movedShapePen);
                    movedSquare.DrawSqaure(g,highlightPen);

                    MainForm.shapes.Insert(ShapeSelectionForm.index, movedSquare);
                    MainForm.shapes.RemoveAt(ShapeSelectionForm.index + 1);

                    break;

                case "Circle":

                    break;

                case "Triangle":

                    break;


            }

            MainForm.Canvas.BackgroundImage = MainForm.drawingRegion;
            MainForm.allShapes = (Bitmap)MainForm.drawingRegion.Clone();
            MainForm.ResetDrawingRegion();

        }
    }
}
