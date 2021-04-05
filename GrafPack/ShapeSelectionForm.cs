using System;
using System.Drawing;
using System.Windows.Forms;

namespace GrafPack
{
    public partial class ShapeSelectionForm : Form
    {
        //represents the element of the shape array
        public static int index = -1;
        public static string ShapeInfoText;

        public ShapeSelectionForm()
        {
            InitializeComponent();
        }

        public void ChangeInfoBox(string newText)
        {
            shapeInfobx.Text = newText;
        }

        /// <summary>
        /// Loops through the shape list and highlights 
        /// </summary>
        public static void HighlightShapeInList()
        {
            //draws to the canvas of the main form
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            //formation of dashes to highlight a shape with
            float[] dashValues = { 1, 5 };

            //pen to highlight shapes with
            Pen highlightPen = new Pen(MainForm.Canvas.BackColor, MainForm.PenSize)
            {
                DashPattern = dashValues
            };

            //if the shape list is not empty and the index is less than the amount of shapes in the list
            if (MainForm.shapes.Count > -1 && index < MainForm.shapes.Count)
            {
                //if the index is greater than 0, highlight the appropriate shape
                if (index >= 0)
                {
                    switch (MainForm.shapes[index].ShapeType)
                    {
                        case "Square":
                            Square replacementSquare = new Square(MainForm.shapes[index].ShapeStart, MainForm.shapes[index].ShapeEnd, MainForm.shapes[index].ShapeColour);
                            replacementSquare.DrawSqaure(g, highlightPen);
                            ShapeMovementForm.CalculateSquareCenter(replacementSquare);
                            break;

                        case "Circle":
                            Circle replacementCircle = new Circle(MainForm.shapes[index].ShapeColour, MainForm.shapes[index].ShapeEnd, 100);
                            replacementCircle.HighlightCircle(MainForm.shapes[index].ShapeColour);
                            break;

                        case "Triangle":
                            Triangle replacementTriangle = new Triangle(MainForm.shapes[index].ShapeStart, MainForm.shapes[index].ShapeEnd, MainForm.shapes[index].ShapeColour);
                            replacementTriangle.DrawTriangle(g, highlightPen);
                            ShapeMovementForm.CalculateTriangleCentre(replacementTriangle);
                            break;
                    }

                    MainForm.ResetDrawingRegion();
                }
            }
        }

        /// <summary>
        /// Triggers when the form loads and checks if there are any shapes in the list 
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
        /// Triggers wen the 'left' button is clicked and iterates left through the end of the list of shapes 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Leftbtn_Click(object sender, EventArgs e)
        {
            //if the index is not set to no shape selected
            if (index != -1)
            {
                //decrement the index
                index--;

                //highlight the appropriate shape
                HighlightShapeInList();

                //if the index is greater or equal to 0, allow for a shape to be selected 
                if (index >= 0)
                {
                    MainForm.ShapeSelected = true;

                    shapeInfobx.Text = MainForm.shapes[index].ShapeType + " " + (index + 1) + " Selected";
                }

                //if the index is less than 0, no shape can be selected
                else
                {
                    shapeInfobx.Text = "No shape selected";
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
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            //if the index is not equal to the amount of shapes in the list - 1
            if (index != MainForm.shapes.Count - 1)
            {
                //set ShapeSelected to true
                MainForm.ShapeSelected = true;

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

            Pen deletePen = new Pen(MainForm.Canvas.BackColor, MainForm.PenSize);

            //if the shape list isn't empty and the index is not 1
            if (MainForm.shapes.Count > 0 && index != -1)
            {
                switch (MainForm.shapes[index].ShapeType)
                {
                    case "Square":
                        Square deletetionSquare = new Square(MainForm.shapes[index].ShapeStart, MainForm.shapes[index].ShapeEnd, MainForm.shapes[index].ShapeColour);
                        deletetionSquare.DrawSqaure(g, deletePen);
                        break;

                    case "Circle":
                        Circle deletionCircle = new Circle(MainForm.shapes[index].ShapeColour, MainForm.shapes[index].ShapeEnd, MainForm.shapes[index].Radius);
                        deletionCircle.DeleteCircle(); 
                        break;

                    case "Triangle":
                        Triangle deletionTrianlge = new Triangle(MainForm.shapes[index].ShapeStart, MainForm.shapes[index].ShapeEnd, MainForm.shapes[index].ShapeColour);
                        deletionTrianlge.DrawTriangle(g, deletePen);
                        break;
                }

                //stops the shapes from re-appearing when the canvas is refreshed
                MainForm.allShapes = (Bitmap)MainForm.drawingRegion.Clone();

                //remove the shape from the list
                MainForm.shapes.RemoveAt(index);

                //change the selected shape indication to none
                shapeInfobx.Text = "No shape selected";

                //set the index to -1 (no shape selected)
                index = -1;

                //reset the drawing region bitmap
                MainForm.ResetDrawingRegion();
            }

            //remove the delete pen from memory
            deletePen.Dispose();
        }

        /// <summary>
        /// Opens a form to allow the user to move and rotate a shape
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransform_Click(object sender, EventArgs e)
        {
            //if a shape is selcted, allow the user to move it
            if (index != -1)
            {
                //if a shape is selected, open the form to move it 
                if (MainForm.ShapeSelected == true)
                {
                    ShapeMovementForm shapeMovementForm = new ShapeMovementForm();
                    shapeMovementForm.Show();
                }
                else
                {
                    //if there are now shapes, inform the user
                    if (MainForm.shapes.Count == 0)
                    {
                        MessageBox.Show("There are no shapes to select.");

                    }
                    //if there are shapes, inform the user to select one
                    else
                    {
                        MessageBox.Show("Select a shape to transform.");
                    }
                }
            }
        }
    }
}

