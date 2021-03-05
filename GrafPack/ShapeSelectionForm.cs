using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GrafPack
{
    public partial class ShapeSelectionForm : Form
    {
        int index = -1;

        public ShapeSelectionForm()
        {
            InitializeComponent();
        }

        void IterateShapeList()
        {
            using Graphics g = MainForm.Canvas.CreateGraphics();

            Point p1, p2;

            if (MainForm.shapes.Count > -1 && index < MainForm.shapes.Count)
            {
                if (index >= 0)
                {
                    MainForm.shapes[index].HighlightShape(g, p1 = new Point(MainForm.shapes[index].StartPoint.X, MainForm.shapes[index].StartPoint.Y),
                                                             p2 = new Point(MainForm.shapes[index].EndPoint.X, MainForm.shapes[index].EndPoint.Y));
                }
            }
        }

        private void ShapeSelectionForm_Load(object sender, EventArgs e)
        {

            if (MainForm.shapes.Count == 0)
            {
                shapeInfobx.Text = "There are no shapes to select.";
            }
            else
            {
                shapeInfobx.Text = "No shape selected.";
            }

            //test

        }

        private void Leftbtn_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {
                index--;
                MainForm.RedrawAllShapes();
                IterateShapeList();

                if (index >= 0)
                {
                    shapeInfobx.Text = index.ToString();
                }
                else
                {
                    shapeInfobx.Text = "No shape selected.";
                }
            }
         
        }

        private void Rightbtn_Click(object sender, EventArgs e)
        {
            if (index != MainForm.shapes.Count - 1)
            {
                index++;

                IterateShapeList();
                shapeInfobx.Text = index.ToString();
            }
        }
    }
}
