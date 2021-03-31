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
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            //if the shape list is not empty and the index is less than the amount of shapes in the list
            if (MainForm.shapes.Count > -1 && index < MainForm.shapes.Count)
            {
                //if the index is greater than 0, highlight the appropriate shape
                if (index >= 0)
                {
                    //highlight the shape based on the index
                    MainForm.shapes[index].HighlightShape(g);
                    MainForm.ResetDrawingRegion();
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
                shapeInfobx.Text = "There are no shapes to select";
            }
            else
            {
                shapeInfobx.Text = "No shape selected";
            }
        }

        /// <summary>
        /// Triggers wen the 'left' button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Leftbtn_Click(object sender, EventArgs e)
        {
            //if the index is not set to no shape selected
            if (index != -1)
            {
                //redraw all shapes to graphically represent no shape has been selected
                MainForm.RedrawAllShapes();

                //decrement the index
                index--;

                //highlight the appropriate shape
                HighlightShapeInList();

                //if the index is greater or equal to 0, allow for a shape to be selected 
                if (index >= 0)
                {
                    MainForm.ShapeSelected = true;

                    shapeInfobx.Text = MainForm.shapes[index].ShapeType + " " + (index + 1) + " Selected";
                    //   MainForm.ResetDrawingRegion();

                }           
                //if the index is less than 0, no shape can be selected
                else
                {
                    shapeInfobx.Text = "No shape selected";
                    MainForm.RedrawAllShapes();
                    MainForm.ResetDrawingRegion();
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
                //set ShapeSelected to true
                MainForm.ShapeSelected = true;

                //redraw all shapes to visually re-select shapes 
                MainForm.RedrawAllShapes();
                
                //increase the index 
                index++;

                //highlight the appropriate shape in the list
                HighlightShapeInList();

                //set the info box to hte appropriate information
                shapeInfobx.Text = MainForm.shapes[index].ShapeType + " " + (index + 1) + " Selected";
            }
        }

        /// <summary>
        /// Triggers when the form is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShapeSelectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //redraw all shapes on closing of the form to prevent a shape of being selected visually when the window is closed
            MainForm.RedrawAllShapes();
            MainForm.ResetDrawingRegion();

            //set index to -1 so no shapes are selected
            index = -1;
        }

        /// <summary>
        /// Triggers when the 'exit' button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            //close the window
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
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            //if the shape list isn't empty and the index is not 1
            if (MainForm.shapes.Count > 0 && index != -1)
            {
                //delte the shape in the selected index
                MainForm.shapes[index].Delete(g);

                //set the elemment in the array to null
               // MainForm.shapes[index] = null; potentially dont need

                //remove the shape from the list
                MainForm.shapes.RemoveAt(index);

                //change the selected shape indication to none
                shapeInfobx.Text = "No shape selected";

                //set the index to -1 (no shape selected)
                index = -1;

                //redraw all shapes
                MainForm.RedrawAllShapes();
                
                //reset the drawing region bitmap
                MainForm.ResetDrawingRegion();
            }
        }
    }
}

