using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GrafPack
{
    public abstract class Shape
    {
        //represents the colour of hte shape
        public Color ShapeColour { get; set; }
        public string ShapeType { get; set; }
        public Point ShapeStart { get; set; }
        public Point ShapeEnd { get; set; }
        public int Radius { get; set; }
        public Point Centre { get; set; }


        public Point CalculateCentre()
        {
            switch (ShapeType)
            {
                case "Square":
                    Centre = new Point((ShapeStart.X + ShapeEnd.X) / 2, (ShapeStart.Y + ShapeEnd.Y));
                    break;
            }

            return Centre;
        }
    }
}
