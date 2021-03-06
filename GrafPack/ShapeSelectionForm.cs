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

        /// <summary>
        /// Loops through the shape list and highlights 
        /// </summary>
        void HighlightShapeInList()
        {
            //draws to the canvas of the main form
            using Graphics g = MainForm.Canvas.CreateGraphics();

            //if the shape list is not empty and the index is less than the amount of shapes in the list
            if (MainForm.shapes.Count > -1 && index < MainForm.shapes.Count)
            {
                //if the index is greater than 0, highlight the appropriate shape
                if (index >= 0)
                {
                    //highlight the shape based on the index
                    MainForm.shapes[index].HighlightShape(g);
                }
            }
        }

        /// <summary>
        /// Triggers when the form loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShapeSelectionForm_Load(object sender, EventArgs e)
        {
            //set ShapeSelected to false (maybe delete variable)
            MainForm.ShapeSelected = false;

            // if the main form isn't empty, show that there are no shapes to select
            if (MainForm.shapes.Count == 0)
            {
                shapeInfobx.Text = "There are no shapes to select.";
            }
            else
            {
                shapeInfobx.Text = "No shape selected.";
            }
        }

        private void Leftbtn_Click(object sender, EventArgs e)
        {
            //if the index is not set to no shape selected
            if (index != -1)
            {
                //decrement the index
                index--;

                //redraw all shapes to graphically represent no shape has been selected
                MainForm.RedrawAllShapes();

                //highlight the appropriate shape
                HighlightShapeInList();

                if (index >= 0)
                {
                    MainForm.ShapeSelected = true;

                    shapeInfobx.Text = MainForm.shapes[index].ShapeType + " " + (index + 1) + " Selected.";
                }
                else
                {
                    shapeInfobx.Text = "No shape selected.";
                    MainForm.ShapeSelected = false;
                }
            }
        }

        /// <summary>
        /// Triggers when the 'right' button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rightbtn_Click(object sender, EventArgs e)
        {
            //if the index is not equal to the amount of shapes in the list - 1
            if (index != MainForm.shapes.Count - 1)
            {
                //
                MainForm.ShapeSelected = true;

                MainForm.RedrawAllShapes();

                index++;

                HighlightShapeInList();
                shapeInfobx.Text = MainForm.shapes[index].ShapeType + " " + (index + 1) + " Selected.";
            }
        }

        private void ShapeSelectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.RedrawAllShapes();

            //set index to -1 so no shapes are selected
            index = -1;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Triggers on clicking the delete button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Deletebtn_Click(object sender, EventArgs e)
        {
            //draws to the canvas
            using Graphics g = MainForm.Canvas.CreateGraphics();

            //if the shape list isn't empty and the index is not 1
            if (MainForm.shapes.Count > 0 && index != -1)
            {
                MainForm.shapes[index].Delete(g);
                MainForm.shapes[index] = null;
                shapeInfobx.Text = "No shape selected";
                MainForm.shapes.RemoveAt(index);
                MainForm.RedrawAllShapes();
                index = -1;
            }
        }
    }
}

