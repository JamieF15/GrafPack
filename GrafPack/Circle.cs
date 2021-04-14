using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace GrafPack
{
    class Circle : Shape
    {
        /// <summary>
        /// Circle contructor
        /// </summary>
        /// <param name="_shapeColor">The colour of the shape</param>
        /// <param name="shapeCentre">The centre of the shape</param>
        /// <param name="_radius">The radius of the shape</param>
        public Circle(Color _shapeColor, Point shapeCentre, Point _end, int _radius)
        {
            Colour = _shapeColor;
            Start = shapeCentre;
            End = _end;
            Radius = _radius;
            Type = "Circle";
        }

        #region Methods

        /// <summary>
        /// Gets the distance between two points for circle radius
        /// </summary>
        /// <param name="startX">Start point x</param>
        /// <param name="endY">End point y</param>
        /// <param name="endX">End point x</param>
        /// <param name="startY">Start point y</param>
        /// <returns></returns>
        public static int CalculateSize(double startX, double endY, double endX, double startY)
        {
            return (int)Math.Sqrt(Math.Pow(endX - startX, 2) + Math.Pow(startY - endY, 2));
        }

        /// <summary>
        /// Places a pixels on the screen 
        /// </summary>
        /// <param name="x">x coodinate of the pixel</param>
        /// <param name="y">y coordinate of the pixel</param>
        /// <param name="c">colour of the pixel</param>
        private void PlacePixel(int x, int y, Color c)
        {
            //draw to the drawing region
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            //bitmap to contain the pixel
            Bitmap bm = new Bitmap(1, 1);

            //draw the pixel to the bitmap
            bm.SetPixel(0, 0, c);

            //draw the pixel to the drawing region
            g.DrawImageUnscaled(bm, x, y);
        }

        /// <summary>
        /// Creates a circle by placing pixels on the screen
        /// </summary>
        /// <param name="start">The start point for drawing</param>
        /// <param name="end">The end point for drawing</param>
        /// <param name="x">The x coodinate</param>
        /// <param name="y">The y coodinate</param>
        private void DrawCirclePixels(int start, int end, int x, int y)
        {
            PlacePixel(start + x, end + y, Colour);
            PlacePixel(start - x, end + y, Colour);
            PlacePixel(start + x, end - y, Colour);
            PlacePixel(start - x, end - y, Colour);
            PlacePixel(start + y, end + x, Colour);
            PlacePixel(start - y, end + x, Colour);
            PlacePixel(start + y, end - x, Colour);
            PlacePixel(start - y, end - x, Colour);
        }

        /// <summary>
        /// Highlights the circle by removing opposing segments
        /// </summary>
        /// <param name="start">The start point for drawing</param>
        /// <param name="end">The end point for drawing</param>
        /// <param name="x">The x coodinate</param>
        /// <param name="y">The y coodinate</param>
        /// <param name="shapeColour">The colour of the shape</param>
        public void HighlightCirclePixels(int start, int end, int x, int y, Color shapeColour)
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
        /// Deletes a circle by drawing a circle over it at the same position
        /// </summary>
        /// <param name="start">The start point for drawing</param>
        /// <param name="end">The end point for drawing</param>
        /// <param name="x">The x coodinate</param>
        /// <param name="y">The y coodinate</param>
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
        /// Draws a circle to the canvas on a mouse click using Brasenhams circle drawing algorithm
        /// </summary>
        /// code refrenced form: https://www.geeksforgeeks.org/bresenhams-circle-drawing-algorithm/
        public void Draw()
        {
            //the x coordinate of the pixel to draw
            int x = 0;

            //the y coordinate of the pixel to draw
            int y = Radius;

            //the diameter of the cirle 
            int d = 3 - 2 * Radius;

            //loop until the is smaller than x
            while (y >= x)
            {
                //increment x
                x++;

                //check that the diameter is greater than 0
                if (d > 0)
                {
                    //decrement y
                    y--;

                    //set hte diameter
                    d = d + 4 * (x - y) + 10;
                }
                //if the diameter is less than 0
                else
                {
                    //set the diamter appropriatly
                    d = d + 4 * x + 6;
                }

                //draw the pixels to the drawing region
                DrawCirclePixels(End.X, End.Y, x, y);
            }
        }

        /// <summary>
        /// Highlights the circle to show it is selected
        /// </summary>
        /// <param name="shapeColour">The colour of the shape</param>
        public void Highlight(Color shapeColour)
        {
            //the x coordinate of the pixel to draw
            int x = 0;

            //the y coordinate of the pixel to draw
            int y = Radius;

            //the diameter of the cirle 
            int d = 3 - 2 * Radius;

            //loop until the is smaller than x
            while (y >= x)
            {
                //increment x
                x++;

                //check that the diameter is greater than 0
                if (d > 0)
                {
                    //decrement y
                    y--;

                    //set hte diameter
                    d = d + 4 * (x - y) + 10;
                }
                //if the diameter is less than 0
                else
                {
                    //set the diamter appropriatly
                    d = d + 4 * x + 6;
                }

                //draw pixels to the drawing region to highlight the circle
                HighlightCirclePixels(End.X, End.Y, x, y, shapeColour);
            }
        }

        /// <summary>
        /// Replaces the circle with a circle the same size but the colour of the canvas
        /// </summary>
        public void Delete()
        {
            //the x coordinate of the pixel to draw
            int x = 0;

            //the y coordinate of the pixel to draw
            int y = Radius;

            //the diameter of the cirle 
            int d = 3 - 2 * Radius;

            //loop until the is smaller than x
            while (y >= x)
            {
                //increment x
                x++;

                //check that the diameter is greater than 0
                if (d > 0)
                {
                    //decrement y
                    y--;

                    //set hte diameter
                    d = d + 4 * (x - y) + 10;
                }
                //if the diameter is less than 0
                else
                {
                    //set the diamter appropriatly
                    d = d + 4 * x + 6;
                }

                //delete the circle in the designated position
                DeleteCirclePixels(End.X, End.Y, x, y);
            }
        }
        #endregion
    }
}
