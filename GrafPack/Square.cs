using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GrafPack
{
    public class Square : Shape
    {
        Point startCorner, endCorner;
        Color color;

        public Square(Point _startCorner, Point _endCorner, Color _color)
        {
            startCorner = _startCorner;
            endCorner = _endCorner;
            color = _color;
        }

        public void Draw(Graphics g, Pen p)
        {
            double diffX, diffY, xMid, yMid;

            diffX = startCorner.X - endCorner.X;
            diffY = startCorner.Y - endCorner.Y;
            xMid = (startCorner.X + endCorner.X) / 2;
            yMid = (startCorner.Y + endCorner.Y) / 2;

            g.DrawLine(p, (int)startCorner.X, (int)startCorner.Y, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2));
            g.DrawLine(p, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2), (int)endCorner.X, endCorner.Y);
            g.DrawLine(p, (int)endCorner.X, (int)endCorner.Y, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2));
            g.DrawLine(p, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2), (int) startCorner.X, (int) startCorner.Y);
        }

        public Color GetColor()
        {
            return this.color;
        }
    }
}
