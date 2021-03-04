using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GrafPack
{
    public abstract class Shape
    {
        public enum Shapes { Square, circle, triangle };

        public void HighlightShape()
        {
            float[] dashValues = { 1, 2, 3, 4 };

            Pen dashedPen = new Pen(Color.Black);
            dashedPen.DashPattern = dashValues;
        }

        public void Draw(string shape)
        {
            if (shape == Shapes.Square.ToString())
            {

            }
        }
    }
}
