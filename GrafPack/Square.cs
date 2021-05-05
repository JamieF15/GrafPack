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
        /// Code refrenced from canvas
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        public void DrawSqaure(Pen p)
        {
            double diffX, diffY, xMid, yMid;

            diffX = Start.X - End.X;
            diffY = Start.Y - End.Y;
            xMid = (Start.X + End.X) / 2;
            yMid = (Start.Y + End.Y) / 2;

            Line.DrawLine((int)Start.X, (int)Start.Y, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2), p.Color);
            Line.DrawLine((int)(xMid + diffY / 2), (int)(yMid - diffX / 2), (int)End.X, End.Y, p.Color);
            Line.DrawLine((int)End.X, (int)End.Y, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2), p.Color);
            Line.DrawLine((int)(xMid - diffY / 2), (int)(yMid + diffX / 2), (int)Start.X, (int)Start.Y, p.Color);
        }

        public void HighlightSqaure(Pen p)
        {
            double diffX, diffY, xMid, yMid;

            diffX = Start.X - End.X;
            diffY = Start.Y - End.Y;
            xMid = (Start.X + End.X) / 2;
            yMid = (Start.Y + End.Y) / 2;

            Line.HighlightLine((int)Start.X, (int)Start.Y, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2), p.Color);
            Line.HighlightLine((int)(xMid + diffY / 2), (int)(yMid - diffX / 2), (int)End.X, End.Y, p.Color);
            Line.HighlightLine((int)End.X, (int)End.Y, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2), p.Color);
            Line.HighlightLine((int)(xMid - diffY / 2), (int)(yMid + diffX / 2), (int)Start.X, (int)Start.Y, p.Color);
        }

        #endregion
    }
}
