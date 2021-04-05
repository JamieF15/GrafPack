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
            ShapeStart = _startCorner;
            ShapeEnd = _endCorner;
            ShapeColour = _shapeColour;
            ShapeType = "Square";
        }

        /// <summary>
        /// Draws a square to th canvas based on mouse clicks
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        public void DrawSqaure(Graphics g, Pen p)
        {
            double diffX, diffY, xMid, yMid;

            diffX = ShapeStart.X - ShapeEnd.X;
            diffY = ShapeStart.Y - ShapeEnd.Y;
            xMid = (ShapeStart.X + ShapeEnd.X) / 2;
            yMid = (ShapeStart.Y + ShapeEnd.Y) / 2;

            g.DrawLine(p, (int)ShapeStart.X, (int)ShapeStart.Y, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2));
            g.DrawLine(p, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2), (int)ShapeEnd.X, ShapeEnd.Y);
            g.DrawLine(p, (int)ShapeEnd.X, (int)ShapeEnd.Y, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2));
            g.DrawLine(p, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2), (int)ShapeStart.X, (int)ShapeStart.Y);
        }

        #endregion
    }
}
