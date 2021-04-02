using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GrafPack
{
    class Triangle : Shape
    {
        //Code refreneced from: https://stackoverflow.com/questions/41294315/draw-an-equilateral-triangle-c-sharp
        public Triangle(Point _shapeStart, Point _shapeEnd, Color _shapeColour)
        {
            ShapeStart = _shapeStart;
            ShapeEnd = _shapeEnd;
            ShapeColour = _shapeColour;
            ShapeType = "Triangle";
        }

        public void DrawTriangle(Graphics g, Pen p)
        {
            float xDiff = ShapeStart.X - ShapeEnd.X;
            float yDiff = ShapeStart.Y - ShapeEnd.Y;
            float xMid = (ShapeStart.X + ShapeEnd.X) / 2;
            float yMid = (ShapeStart.Y + ShapeEnd.Y) / 2;

            var path = new GraphicsPath();

            path.AddLines(new PointF[] {ShapeStart, new PointF(xMid + yDiff/2, yMid-xDiff/2), ShapeEnd,});

            path.CloseFigure();

            // Draw Triangle
            g.DrawPath(p, path);
        }
    }
}
