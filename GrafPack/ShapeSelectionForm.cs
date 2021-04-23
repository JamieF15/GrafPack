using System;
using System.Drawing;
using System.Windows.Forms;

namespace GrafPack
{
    public partial class ShapeSelectionForm : Form
    {
        //represents the element of the shape array
        public static int index = -1;
        public static bool isOpen = false;

        public ShapeSelectionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a pen that can highlight a shape
        /// </summary>
        /// <returns>A pen object</returns>
        public static Pen CreateHighlightPen()
        {
            //formation of dashes to highlight a shape with
            float[] dashValues = { 1, 5 };

            //pen to highlight shapes with
            Pen highlightPen = new Pen(MainForm.Canvas.BackColor, MainForm.PenSize)
            {
                DashPattern = dashValues
            };

            //return the pen
            return highlightPen;
        }

        /// <summary>
        /// Hightlights the relevant shape to show it is selected
        /// </summary>
        public static void HighlightShapeInList()
        {
            //draws to the canvas of the main form
            using Graphics g = Graphics.FromImage(MainForm.drawingRegion);

            //if the shape list is not empty and the index is less than the amount of shapes in the list
            if (MainForm.shapes.Count > -1 && index < MainForm.shapes.Count)
            {
                //if the index is greater than 0, highlight the appropriate shape
                if (index >= 0)
                {
                    //switch statement for the shape type
                    switch (MainForm.shapes[index].Type)
                    {
                        case "Square":
                            //shape object to replace the old square
                            Square replacementSquare = new Square(MainForm.shapes[index].Start, MainForm.shapes[index].End, MainForm.shapes[index].Colour);

                            //draw the replacement square with the highlight pen
                            replacementSquare.DrawSqaure(g, CreateHighlightPen());

                            //calculate the centre of the new square for rotation
                            ShapeMovementForm.CalculateSquareCenter(replacementSquare);
                            break;

                        case "Circle":
                            //circle object to replace the old circle
                            Circle replacementCircle = new Circle(MainForm.shapes[index].Colour, MainForm.shapes[index].Start, MainForm.shapes[index].End, MainForm.shapes[index].Radius);

                            //draw the circle 
                            replacementCircle.Highlight(MainForm.shapes[ShapeSelectionForm.index].Colour);
                            break;

                        case "Triangle":
                            //triangle object to replace the old one
                            Triangle replacementTriangle = new Triangle(MainForm.shapes[index].Start, MainForm.shapes[index].End, MainForm.shapes[index].Colour);

                            //draw the replacement triangle
                            replacementTriangle.Draw(g, CreateHighlightPen());

                            //calculate the centre of the new triangle
                            ShapeMovementForm.CalculateTriangleCentre(replacementTriangle);
                            break;
                    }

                    //reset the drawing region
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
            isOpen = true;
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
                }
                //if the index is less than 0, no shape can be selected
                else
                {
                    //reset the drawign region
                    MainForm.ResetDrawingRegion();

                    //set the ShapeSelected bool to false
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
            //draw to the drawing region
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
            Close();
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

            //used to remove a shape from the canvas
            Pen deletePen = new Pen(MainForm.Canvas.BackColor, MainForm.PenSize);

            if (index != -1)
            {
                //if the shape list isn't empty and the index is not 1
                if (MainForm.shapes.Count > 0 && index != -1)
                {
                    //switch statement on the shape type
                    switch (MainForm.shapes[index].Type)
                    {
                        case "Square":
                            //square object to delete the old sqaure
                            Square deletetionSquare = new Square(MainForm.shapes[index].Start, MainForm.shapes[index].End, MainForm.shapes[index].Colour);

                            //draw the new square over the old square
                            deletetionSquare.DrawSqaure(g, deletePen);
                            break;

                        case "Circle":
                            //circle object to delete the old square
                            Circle deletionCircle = new Circle(MainForm.shapes[index].Colour, MainForm.shapes[index].Start, MainForm.shapes[index].End, MainForm.shapes[index].Radius);

                            //deletet the old circle
                            deletionCircle.Delete();
                            break;

                        case "Triangle":
                            //triangle object to delete the old triangle
                            Triangle deletionTrianlge = new Triangle(MainForm.shapes[index].Start, MainForm.shapes[index].End, MainForm.shapes[index].Colour);

                            //delete the old triangle 
                            deletionTrianlge.Draw(g, deletePen);
                            break;
                    }

                    ShapeMovementForm.RepairAllOtherShapes();

                    //stops the shapes from re-appearing when the canvas is refreshed
                    MainForm.allShapes = (Bitmap)MainForm.drawingRegion.Clone();

                    //remove the shape from the list
                    MainForm.shapes.RemoveAt(index);

                    //set the index to -1 (no shape selected)
                    index = -1;

                    //reset the drawing region bitmap
                    MainForm.ResetDrawingRegion();
                }

                //remove the delete pen from memory
                deletePen.Dispose();
            }
            else
            {
                MessageBox.Show("Select a shape to delete.");
            }
        }

        /// <summary>
        /// Opens a form to allow the user to move and rotate a shape
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransform_Click(object sender, EventArgs e)
        {
            if (!ShapeMovementForm.isOpen)
            {
                //if a shape is selcted, allow the user to move it
                if (index != -1)
                {
                    //if a shape is selected, open the form to move it 
                    if (MainForm.ShapeSelected == true)
                    {
                        //create an object of the shape movement fornm
                        ShapeMovementForm shapeMovementForm = new ShapeMovementForm();

                        //open the shape movement form
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
                else
                {
                    MessageBox.Show("Select a shape to transform.");
                }
            }
            else
            {
                MessageBox.Show("Only one shape can be transformed at a time.");
            }
        }
    }
}
