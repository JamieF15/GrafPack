using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GrafPack
{
    public class Square : Shape
    {
        #region Methods
        public Square(Point _startCorner, Point _endCorner, Color _shapeColour)
        {
            Start = _startCorner;
            End = _endCorner;
            Colour = _shapeColour;
            Type = "Square";
        }

        /// <summary>
        /// Draws a square to th canvas based on mouse clicks
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        public void DrawSqaure(Graphics g, Pen p)
        {
            double diffX, diffY, xMid, yMid;

            diffX = Start.X - End.X;
            diffY = Start.Y - End.Y;
            xMid = (Start.X + End.X) / 2;
            yMid = (Start.Y + End.Y) / 2;

            g.DrawLine(p, (int)Start.X, (int)Start.Y, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2));
            g.DrawLine(p, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2), (int)End.X, End.Y);
            g.DrawLine(p, (int)End.X, (int)End.Y, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2));
            g.DrawLine(p, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2), (int)Start.X, (int)Start.Y);
        }

        #endregion
    }
}
