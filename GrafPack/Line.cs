using System;
using System.Drawing;

namespace GrafPack
{
    public static class Line
    {
        private static void PlacePixel(int x, int y, Color c)
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
        /// Highlights a square based on its point positions
        /// Refrenced from: https://stackoverflow.com/questions/11678693/all-cases-covered-bresenhams-line-algorithm
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="color"></param>
        public static void HighlightLine(int x, int y, int x2, int y2, Color color)
        {
            //width
            int w = x2 - x;

            //height
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int pixelOrder = 0;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
               //if the pixel placed is even, set the pixel to the background color
                if(pixelOrder % 2 == 0)
                {
                    PlacePixel(x, y, MainForm.Canvas.BackColor);
                }
                else
                {
                    PlacePixel(x, y, color);
                }
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
                pixelOrder++;
            }
        }

        public static void DrawLine(int x, int y, int x2, int y2, Color color)
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {

                PlacePixel(x, y, color);

                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }
    }
}