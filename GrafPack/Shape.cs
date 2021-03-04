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

        /// <summary>
        /// Returns the colour of the shape
        /// </summary>
        /// <returns></returns>
        public Color GetColor()
        {
            return this.colour;
        }

        public void HighlightShape()
        {
            float[] dashValues = { 1, 2, 3, 4 };

            Pen dashedPen = new Pen(Color.Black);
            dashedPen.DashPattern = dashValues;
        }
    }
}
