using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GrafPack
{
    public class Square : Shape
    {
        Point startCorner, endCorner;

        public Square(Point _startCorner, Point _endCorner)
        {
            startCorner = _startCorner;
            endCorner = _endCorner;
        }

        public void Draw(Graphics g, Pen p)
        {

        }
    }
}
