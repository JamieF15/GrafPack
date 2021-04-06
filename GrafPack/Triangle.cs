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
        public void Draw(Graphics g, Pen p)
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

            //graphics path to stores the lines
            GraphicsPath path = new GraphicsPath();

            //add the lines to the path
            path.AddLines(new PointF[] { Start, ThridPoint, End, });

            //close the path
            path.CloseFigure();

            //draw the triangle
            g.DrawPath(p, path);
        }
    }
}
