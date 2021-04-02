using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GrafPack
{
    public abstract class Shape
    {
        //represnets the colour of hte shape
        public Color ShapeColour { get; set; }
        public string ShapeType { get; set; }
        public Point ShapeStart { get; set; }
        public Point ShapeEnd { get; set; }
        public int Size { get; set; }


        /// <summary>
        /// Returns the colour of the shape
        /// </summary>
        /// <returns></returns>
        public Color GetColor()
        {
            return ShapeColour;
        }


        //public void Delete(Graphics g)
        //{
        //    Pen deletePen = new Pen(MainForm.Canvas.BackColor, MainForm.PenSize);

        //    Draw(g, deletePen);
        //    // MainForm.RedrawAllShapes();

        //    MainForm.ResetDrawingRegion();
        //}

        //public void Draw(Graphics g, Pen p)
        //{
        //    switch (ShapeType)
        //    {
        //        case "Square":

        //           // DrawSqaure(g, p);

        //            break;

        //        case "Circle":

        //            DrawCircle();

        //            break;
        //    }
        //}


        //public void DrawSqaure(Graphics g, Pen p)
        //{
        //    double diffX, diffY, xMid, yMid;

        //    diffX = ShapeStart.X - ShapeEnd.X;
        //    diffY = ShapeStart.Y - ShapeEnd.Y;
        //    xMid = (ShapeStart.X + ShapeEnd.X) / 2;
        //    yMid = (ShapeStart.Y + ShapeEnd.Y) / 2;

        //    g.DrawLine(p, (int)ShapeStart.X, (int)ShapeStart.Y, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2));
        //    g.DrawLine(p, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2), (int)ShapeEnd.X, ShapeEnd.Y);
        //    g.DrawLine(p, (int)ShapeEnd.X, (int)ShapeEnd.Y, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2));
        //    g.DrawLine(p, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2), (int)ShapeStart.X, (int)ShapeStart.Y);
        //}



        void PlacePixel(int x, int y, Color c)
        {
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);
            Bitmap bm = new Bitmap(1, 1);
            bm.SetPixel(0, 0, c);
            g.DrawImageUnscaled(bm, x, y);
        }

        void SetCirclePixels(int start, int end, int x, int y)
        {
            PlacePixel(start + x, end + y, ShapeCreationForm.chosenColour);
            PlacePixel(start - x, end + y, ShapeCreationForm.chosenColour);
            PlacePixel(start + x, end - y, ShapeCreationForm.chosenColour);
            PlacePixel(start - x, end - y, ShapeCreationForm.chosenColour);
            PlacePixel(start + y, end + x, ShapeCreationForm.chosenColour);
            PlacePixel(start - y, end + x, ShapeCreationForm.chosenColour);
            PlacePixel(start + y, end - x, ShapeCreationForm.chosenColour);
            PlacePixel(start - y, end - x, ShapeCreationForm.chosenColour);
        }

        public void SetCircleHighlightPixels(int start, int end, int x, int y, Color shapeColour)
        {
            PlacePixel(start + x, end + y, MainForm.Canvas.BackColor);
            PlacePixel(start - x, end + y, shapeColour);
            PlacePixel(start + x, end - y, shapeColour);
            PlacePixel(start - x, end - y, MainForm.Canvas.BackColor);
            PlacePixel(start + y, end + x, shapeColour);
            PlacePixel(start - y, end + x, MainForm.Canvas.BackColor);
            PlacePixel(start + y, end - x, MainForm.Canvas.BackColor);
            PlacePixel(start - y, end - x, shapeColour);
        }

        public void DeleteCirclePixels(int start, int end, int x, int y)
        {
            PlacePixel(start + x, end + y, MainForm.Canvas.BackColor);
            PlacePixel(start - x, end + y, MainForm.Canvas.BackColor);
            PlacePixel(start + x, end - y, MainForm.Canvas.BackColor);
            PlacePixel(start - x, end - y, MainForm.Canvas.BackColor);
            PlacePixel(start + y, end + x, MainForm.Canvas.BackColor);
            PlacePixel(start - y, end + x, MainForm.Canvas.BackColor);
            PlacePixel(start + y, end - x, MainForm.Canvas.BackColor);
            PlacePixel(start - y, end - x, MainForm.Canvas.BackColor);
        }

        public void DrawCircle()
        {
            int radius = 100;
            int x = 0;
            int y = radius;
            int d = 3 - 2 * radius;

            while (y >= x)
            {
                // for each pixel we will
                // draw all eight pixels

                x++;

                // check for decision parameter
                // and correspondingly 
                // update d, x, y
                if (d > 0)
                {
                    y--;
                    d = d + 4 * (x - y) + 10;
                }
                else
                {
                    d = d + 4 * x + 6;
                }

                SetCirclePixels(ShapeEnd.X, ShapeEnd.Y, x, y);
            }
        }

        public void HighlightCircle(Color shapeColour)
        {
            int radius = 100;
            int x = 0;
            int y = radius;
            int d = 3 - 2 * radius;

            while (y >= x)
            {
                // for each pixel we will
                // draw all eight pixels

                x++;

                // check for decision parameter
                // and correspondingly 
                // update d, x, y
                if (d > 0)
                {
                    y--;
                    d = d + 4 * (x - y) + 10;
                }
                else
                {
                    d = d + 4 * x + 6;
                }

                SetCircleHighlightPixels(ShapeEnd.X, ShapeEnd.Y, x, y, shapeColour);
            }
        }

        public void DeleteCircle()
        {
            int radius = 100;
            int x = 0;
            int y = radius;
            int d = 3 - 2 * radius;

            while (y >= x)
            {
                // for each pixel we will
                // draw all eight pixels

                x++;

                // check for decision parameter
                // and correspondingly 
                // update d, x, y
                if (d > 0)
                {
                    y--;
                    d = d + 4 * (x - y) + 10;
                }
                else
                {
                    d = d + 4 * x + 6;
                }

                DeleteCirclePixels(ShapeEnd.X, ShapeEnd.Y, x, y);
            }
        }

      
    }
}
