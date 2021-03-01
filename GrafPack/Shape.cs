using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GrafPack
{
    public abstract class Shape
    {

        
        public void HighlightShape()
        {
            float[] dashValues = { 1, 2, 3, 4 };

            Pen dashedPen = new Pen(Color.Black);
            dashedPen.DashPattern = dashValues;



        }
    }
}
