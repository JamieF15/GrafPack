using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace GrafPack
{
    class Circle : Shape
    {
       // public int Radius { get; set; }

        public Circle(Color _shapeColor, Point shapeCentre, int _radius)
        {
            ShapeColour = _shapeColor;
            ShapeEnd = shapeCentre;
            Radius = _radius;
            ShapeType = "Circle";
        }

        /// <summary>
        /// Places a pixels on the screen 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="c"></param>
        void PlacePixel(int x, int y, Color c)
        {
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);
            Bitmap bm = new Bitmap(1, 1);
            bm.SetPixel(0, 0, c);
            g.DrawImageUnscaled(bm, x, y);
        }

        /// <summary>
        /// Creates a circle by placing pixels on the screen
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
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

        /// <summary>
        /// Highlights the circle by removing opposing segments
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="shapeColour"></param>
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

        /// <summary>
        /// Deletes a circle by drawing a circle over it 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
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

        /// <summary>
        /// 
        /// </summary>
        public void DrawCircle()
        {
            int x = 0;
            int y = Radius;
            int d = 3 - 2 * Radius;

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

        /// <summary>
        /// Highlights the circle to show it is selected
        /// </summary>
        /// <param name="shapeColour"></param>
        public void HighlightCircle(Color shapeColour)
        {
            int x = 0;
            int y = Radius;
            int d = 3 - 2 * Radius;

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

        /// <summary>
        /// Replaces the circle with a circle the same size but the colour of the canvas
        /// </summary>
        public void DeleteCircle()
        {
            int x = 0;
            int y = Radius;
            int d = 3 - 2 * Radius;

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
