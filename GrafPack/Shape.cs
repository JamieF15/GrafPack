using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GrafPack
{
    public abstract class Shape
    {
        #region Attributes
        //the colour of hte shape
        public Color Colour { get; set; }

        //the type of the shape e.g. circle, triangle, or square
        public string Type { get; set; }

        //the start point of the shape
        public Point Start { get; set; }

        //the end point of the shape
        public Point End { get; set; }

        //the radius of a circle (it is here because it needs to be accessed from within a list that stores shapes, not circles)
        public int Radius { get; set; }
        #endregion
    }
}
