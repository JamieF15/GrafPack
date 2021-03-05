using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GrafPack
{
    public abstract class Shape
    {
        //represnets the colour of hte shape
        public Color colour;
        public string type;

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        /// <summary>
        /// Returns the colour of the shape
        /// </summary>
        /// <returns></returns>
        public Color GetColor()
        {
            return this.colour;
        }

        public void HighlightShape(Graphics g, Point p1, Point p2)
        {
            float[] dashValues = { 1, 2, 3, 4 };

            Pen dashedPen = new Pen(MainForm.Canvas.BackColor);

            dashedPen.DashPattern = dashValues;

            if (type == "Square")
            {
                double diffX, diffY, xMid, yMid;

                diffX = StartPoint.X - EndPoint.X;
                diffY = StartPoint.Y - EndPoint.Y;
                xMid = (StartPoint.X + EndPoint.X) / 2;
                yMid = (StartPoint.Y + EndPoint.Y) / 2;

                g.DrawLine(dashedPen, (int)StartPoint.X, (int)StartPoint.Y, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2));
                g.DrawLine(dashedPen, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2), (int)EndPoint.X, EndPoint.Y);
                g.DrawLine(dashedPen, (int)EndPoint.X, (int)EndPoint.Y, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2));
                g.DrawLine(dashedPen, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2), (int)StartPoint.X, (int)StartPoint.Y);
            }
        }
    }
}
