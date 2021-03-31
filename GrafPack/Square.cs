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

        ///// <summary>
        ///// Calculates the corners of a square based on 2 oppsoite corners
        ///// </summary>
        ///// <param name="g"></param>
        ///// <param name="p"></param>
        //public void Draw(Graphics g, Pen p)
        //{
        //    double diffX, diffY, xMid, yMid;

        //    diffX = StartPoint.X - EndPoint.X;
        //    diffY = StartPoint.Y - EndPoint.Y;
        //    xMid = (StartPoint.X + EndPoint.X) / 2;
        //    yMid = (StartPoint.Y + EndPoint.Y) / 2;

        //    g.DrawLine(p, (int)StartPoint.X, (int)StartPoint.Y, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2));
        //    g.DrawLine(p, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2), (int)EndPoint.X, EndPoint.Y);
        //    g.DrawLine(p, (int)EndPoint.X, (int)EndPoint.Y, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2));
        //    g.DrawLine(p, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2), (int)StartPoint.X, (int)StartPoint.Y);
        //}
        #endregion
    }
}
