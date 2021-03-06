using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace GrafPack
{
    class Circle : Shape
    {
        public Circle(Point _startPoint, Point _endPoint , Color _shapeColor)
        {
            StartPoint = _startPoint;
            EndPoint = _endPoint;
            ShapeColour = _shapeColor;
            ShapeType = "Circle";
        }
    }
}
