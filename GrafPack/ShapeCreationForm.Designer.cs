
namespace GrafPack
{
    partial class ShapeCreationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TriangleButton = new System.Windows.Forms.Button();
            this.SquareButton = new System.Windows.Forms.Button();
            this.CircleButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ChooseColourButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // TriangleButton
            // 
            this.TriangleButton.Location = new System.Drawing.Point(22, 99);
            this.TriangleButton.Name = "TriangleButton";
            this.TriangleButton.Size = new System.Drawing.Size(162, 32);
            this.TriangleButton.TabIndex = 3;
            this.TriangleButton.Text = "Triangle";
            this.TriangleButton.UseVisualStyleBackColor = true;
            // 
            // SquareButton
            // 
            this.SquareButton.Location = new System.Drawing.Point(22, 61);
            this.SquareButton.Name = "SquareButton";
            this.SquareButton.Size = new System.Drawing.Size(162, 32);
            this.SquareButton.TabIndex = 2;
            this.SquareButton.Text = "Square";
            this.SquareButton.UseVisualStyleBackColor = true;
            this.SquareButton.Click += new System.EventHandler(this.SquareButton_Click);
            // 
            // CircleButton
            // 
            this.CircleButton.Location = new System.Drawing.Point(22, 23);
            this.CircleButton.Name = "CircleButton";
            this.CircleButton.Size = new System.Drawing.Size(162, 32);
            this.CircleButton.TabIndex = 1;
            this.CircleButton.Text = "Circle";
            this.CircleButton.UseVisualStyleBackColor = true;
            this.CircleButton.Click += new System.EventHandler(this.CircleButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(22, 159);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(162, 32);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ChooseColourButton
            // 
            this.ChooseColourButton.Location = new System.Drawing.Point(203, 61);
            this.ChooseColourButton.Name = "ChooseColourButton";
            this.ChooseColourButton.Size = new System.Drawing.Size(122, 70);
            this.ChooseColourButton.TabIndex = 5;
            this.ChooseColourButton.Text = "Choose shape colour";
            this.ChooseColourButton.UseVisualStyleBackColor = true;
            this.ChooseColourButton.Click += new System.EventHandler(this.ChooseColourButton_Click);
            // 
            // ShapeCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 207);
            this.Controls.Add(this.ChooseColourButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.CircleButton);
            this.Controls.Add(this.SquareButton);
            this.Controls.Add(this.TriangleButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShapeCreationForm";
            this.Text = "ShapeCreationForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TriangleButton;
        private System.Windows.Forms.Button SquareButton;
        private System.Windows.Forms.Button CircleButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ChooseColourButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}