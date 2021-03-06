﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GrafPack
{
    public abstract class Shape
    {
        //represnets the colour of hte shape
        public Color ShapeColour { get; set; }
        public string ShapeType { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        /// <summary>
        /// Returns the colour of the shape
        /// </summary>
        /// <returns></returns>
        public Color GetColor()
        {
            return this.ShapeColour;
        }
        
        public void Delete(Graphics g)
        {
            Pen deletePen = new Pen(MainForm.Canvas.BackColor, MainForm.PenSize);

            switch (ShapeType)
            {
                case "Square":

                    double diffX, diffY, xMid, yMid;

                    diffX = StartPoint.X - EndPoint.X;
                    diffY = StartPoint.Y - EndPoint.Y;
                    xMid = (StartPoint.X + EndPoint.X) / 2;
                    yMid = (StartPoint.Y + EndPoint.Y) / 2;

                    g.DrawLine(deletePen, (int)StartPoint.X, (int)StartPoint.Y, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2));
                    g.DrawLine(deletePen, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2), (int)EndPoint.X, EndPoint.Y);
                    g.DrawLine(deletePen, (int)EndPoint.X, (int)EndPoint.Y, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2));
                    g.DrawLine(deletePen, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2), (int)StartPoint.X, (int)StartPoint.Y);
                    break;
            }
        }

        public void HighlightShape(Graphics g)
        {
            float[] dashValues = { 1, 6 };

            Pen dashedPen = new Pen(MainForm.Canvas.BackColor, 3)
            {
                DashPattern = dashValues
            };

            switch (ShapeType)
            {
                case "Square":

                    double diffX, diffY, xMid, yMid;

                    diffX = StartPoint.X - EndPoint.X;
                    diffY = StartPoint.Y - EndPoint.Y;
                    xMid = (StartPoint.X + EndPoint.X) / 2;
                    yMid = (StartPoint.Y + EndPoint.Y) / 2;

                    g.DrawLine(dashedPen, (int)StartPoint.X, (int)StartPoint.Y, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2));
                    g.DrawLine(dashedPen, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2), (int)EndPoint.X, EndPoint.Y);
                    g.DrawLine(dashedPen, (int)EndPoint.X, (int)EndPoint.Y, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2));
                    g.DrawLine(dashedPen, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2), (int)StartPoint.X, (int)StartPoint.Y);

                    break;
            }
        }
    }
}
