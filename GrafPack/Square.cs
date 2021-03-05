using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GrafPack
{
    public class Square : Shape
    {
        #region Attributes
        private Point StartCorner { get; set; }
        private Point EndCorner { get; set; }
        #endregion

        #region Methods
        public Square(Point _startCorner, Point _endCorner, Color _colour, string _type)
        {
            StartCorner = _startCorner;
            EndCorner = _endCorner;
            colour = _colour;
            type = _type;
        }

        public void Highlight()
        {

        }

        public void Delete()
        {

        }

        /// <summary>
        /// Calculates the corners of a square based on 2 oppsoite corners
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        public void Draw(Graphics g, Pen p)
        {
            double diffX, diffY, xMid, yMid;

            diffX = StartCorner.X - EndCorner.X;
            diffY = StartCorner.Y - EndCorner.Y;
            xMid = (StartCorner.X + EndCorner.X) / 2;
            yMid = (StartCorner.Y + EndCorner.Y) / 2;

            g.DrawLine(p, (int)StartCorner.X, (int)StartCorner.Y, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2));
            g.DrawLine(p, (int)(xMid + diffY / 2), (int)(yMid - diffX / 2), (int)EndCorner.X, EndCorner.Y);
            g.DrawLine(p, (int)EndCorner.X, (int)EndCorner.Y, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2));
            g.DrawLine(p, (int)(xMid - diffY / 2), (int)(yMid + diffX / 2), (int)StartCorner.X, (int)StartCorner.Y);
        }
        #endregion
    }
}
