using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace GrafPack
{
    class Circle : Shape
    {
        private int radius;

        public Circle(Color _shapeColor, Point shapeCentre, int _radius)
        {
            ShapeColour = _shapeColor;
            ShapeEnd = shapeCentre;
            radius = _radius;
            ShapeType = "Circle";
        }

        /// <summary>
        /// Returns the radiou
        /// </summary>
        /// <returns></returns>
        public int GetRadius()
        {
            return radius;
        }

        /// <summary>
        /// Places a pixel on the screen at a designated area
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void PlacePixel(int x, int y)
        {
            using Graphics g = MainForm.Canvas.CreateGraphics();
            Bitmap bm = new Bitmap(1, 1);
            bm.SetPixel(0, 0, ShapeCreationForm.chosenColour);
            g.DrawImageUnscaled(bm, x, y);
        }

        void DrawCircle(int start, int end, int x, int y)
        {
            PlacePixel(start + x, end + y);
            PlacePixel(start - x, end + y);
            PlacePixel(start + x, end - y);
            PlacePixel(start - x, end - y);
            PlacePixel(start + y, end + x);
            PlacePixel(start - y, end + x);
            PlacePixel(start + y, end - x);
            PlacePixel(start - y, end - x);
        }

        //public void Draw()
        //{
        //    int x = 0;

        //    int y = radius;

        //    int d = 3 - 2 * radius;

        //    DrawCircle(start, end, x, y);

        //    while (y >= x)
        //    {
        //        // for each pixel we will
        //        // draw all eight pixels

        //        x++;

        //        // check for decision parameter
        //        // and correspondingly 
        //        // update d, x, y
        //        if (d > 0)
        //        {
        //            y--;
        //            d = d + 4 * (x - y) + 10;
        //        }
        //        else
        //            d = d + 4 * x + 6;

        //        DrawCircle(start, end, x, y);
        //    }
        //}


    }
    }
