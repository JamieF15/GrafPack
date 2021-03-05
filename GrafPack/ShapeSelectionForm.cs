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
            if (MainForm.shapes.Count != 0)
            {
                MainForm.shapes[index].HighlightShape();
            }
        }

        private void ShapeSelectionForm_Load(object sender, EventArgs e)
        {
            shapeInfobx.Text = "No shape selected.";
        }

        private void Leftbtn_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {

                IterateShapeList();
                index--;
                shapeInfobx.Text = index.ToString();
            }
        }

        private void Rightbtn_Click(object sender, EventArgs e)
        {
            if (index != MainForm.shapes.Count - 1)
            {
                IterateShapeList();
                index++;
                shapeInfobx.Text = index.ToString();
            }
        }
    }
}
