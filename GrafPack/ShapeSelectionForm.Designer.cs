
namespace GrafPack
{
    partial class ShapeSelectionForm
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
            this.Rightbtn = new System.Windows.Forms.Button();
            this.Leftbtn = new System.Windows.Forms.Button();
            this.doubleBufferedPanel1 = new GrafPack.DoubleBufferedPanel();
            this.shapeInfobx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Rightbtn
            // 
            this.Rightbtn.Location = new System.Drawing.Point(180, 195);
            this.Rightbtn.Name = "Rightbtn";
            this.Rightbtn.Size = new System.Drawing.Size(127, 45);
            this.Rightbtn.TabIndex = 0;
            this.Rightbtn.Text = "Right";
            this.Rightbtn.UseVisualStyleBackColor = true;
            this.Rightbtn.Click += new System.EventHandler(this.Rightbtn_Click);
            // 
            // Leftbtn
            // 
            this.Leftbtn.Location = new System.Drawing.Point(12, 195);
            this.Leftbtn.Name = "Leftbtn";
            this.Leftbtn.Size = new System.Drawing.Size(127, 45);
            this.Leftbtn.TabIndex = 1;
            this.Leftbtn.Text = "Left";
            this.Leftbtn.UseVisualStyleBackColor = true;
            this.Leftbtn.Click += new System.EventHandler(this.Leftbtn_Click);
            // 
            // doubleBufferedPanel1
            // 
            this.doubleBufferedPanel1.Location = new System.Drawing.Point(97, 71);
            this.doubleBufferedPanel1.Name = "doubleBufferedPanel1";
            this.doubleBufferedPanel1.Size = new System.Drawing.Size(127, 118);
            this.doubleBufferedPanel1.TabIndex = 2;
            // 
            // shapeInfobx
            // 
            this.shapeInfobx.Location = new System.Drawing.Point(97, 42);
            this.shapeInfobx.Multiline = true;
            this.shapeInfobx.Name = "shapeInfobx";
            this.shapeInfobx.Size = new System.Drawing.Size(127, 23);
            this.shapeInfobx.TabIndex = 3;
            // 
            // ShapeSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 252);
            this.Controls.Add(this.shapeInfobx);
            this.Controls.Add(this.doubleBufferedPanel1);
            this.Controls.Add(this.Leftbtn);
            this.Controls.Add(this.Rightbtn);
            this.Name = "ShapeSelectionForm";
            this.Text = "ShapeSelectionForm";
            this.Load += new System.EventHandler(this.ShapeSelectionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Rightbtn;
        private System.Windows.Forms.Button Leftbtn;
        private DoubleBufferedPanel doubleBufferedPanel1;
        private System.Windows.Forms.TextBox shapeInfobx;
    }
}