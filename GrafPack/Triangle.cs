using System.Drawing;
using System.Drawing.Drawing2D;

namespace GrafPack
{
    public class Triangle : Shape
    {
        //the third point of the triangle
        public PointF ThridPoint;

        /// <summary>
        /// Triangle contstuctor
        /// </summary>
        /// <param name="_shapeStart">The starting point of the triangle</param>
        /// <param name="_shapeEnd">The end point of the triangle</param>
        /// <param name="_shapeColour">The colour of the triangle</param>
        public Triangle(Point _shapeStart, Point _shapeEnd, Color _shapeColour)
        {
            Start = _shapeStart;
            End = _shapeEnd;
            Colour = _shapeColour;
            Type = "Triangle";
        }

        //Code refreneced from: https://stackoverflow.com/questions/41294315/draw-an-equilateral-triangle-c-sharp
        /// <summary>
        /// Draws a triangle to the canvas based on mouse clicks
        /// </summary>
        /// <param name="g">Graphics object</param>
        /// <param name="p">Pen object</param>
        public void DrawTriangle(Pen p)
        {
            //the difference between the two points on the x axis
            float xDiff = Start.X - End.X;

            //the difference between the two points on the y axis
            float yDiff = Start.Y - End.Y;

            //the middle point of the two points on the x axis
            float xMid = (Start.X + End.X) / 2;

            //the middle point of the two points on the y axis
            float yMid = (Start.Y + End.Y) / 2;

            //the third point of the triangle
            ThridPoint = new PointF(xMid + yDiff / 2, yMid - xDiff / 2);

            Line.DrawLine((int)Start.X, (int)Start.Y, (int)(xMid + yDiff / 2), (int)(yMid - xDiff / 2), p.Color);
            Line.DrawLine((int)(xMid + yDiff / 2), (int)(yMid - xDiff / 2), (int)End.X, (int)End.Y, p.Color);
            Line.DrawLine((int)Start.X, (int)Start.Y, End.X, End.Y, p.Color);
        }

        //Code refreneced from: https://stackoverflow.com/questions/41294315/draw-an-equilateral-triangle-c-sharp
        /// <summary>
        /// Highlights a triangle to the canvas based on its position
        /// </summary>
        /// <param name="g">Graphics object</param>
        /// <param name="p">Pen object</param>
        public void HighlightTriangle(Pen p)
        {
            //the difference between the two points on the x axis
            float xDiff = Start.X - End.X;

            //the difference between the two points on the y axis
            float yDiff = Start.Y - End.Y;

            //the middle point of the two points on the x axis
            float xMid = (Start.X + End.X) / 2;

            //the middle point of the two points on the y axis
            float yMid = (Start.Y + End.Y) / 2;

            //the third point of the triangle
            ThridPoint = new PointF(xMid + yDiff / 2, yMid - xDiff / 2);

            Line.HighlightLine((int)Start.X, (int)Start.Y, (int)(xMid + yDiff / 2), (int)(yMid - xDiff / 2), p.Color);
            Line.HighlightLine((int)(xMid + yDiff / 2), (int)(yMid - xDiff / 2), (int)End.X, (int)End.Y, p.Color);
            Line.HighlightLine((int)Start.X, (int)Start.Y, End.X, End.Y, p.Color);
        }
    }
}
