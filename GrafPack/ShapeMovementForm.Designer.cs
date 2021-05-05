
namespace GrafPack
{
    partial class ShapeMovementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShapeMovementForm));
            this.btnUp = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.txtMoveShape = new System.Windows.Forms.TextBox();
            this.txtRotateShape = new System.Windows.Forms.TextBox();
            this.btnRotateRight = new System.Windows.Forms.Button();
            this.btnRotateLeft = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUp
            // 
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(67, 34);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(45, 43);
            this.btnUp.TabIndex = 0;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnRight
            // 
            this.btnRight.Image = ((System.Drawing.Image)(resources.GetObject("btnRight.Image")));
            this.btnRight.Location = new System.Drawing.Point(118, 83);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(45, 43);
            this.btnRight.TabIndex = 1;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnLeft.Image")));
            this.btnLeft.Location = new System.Drawing.Point(16, 83);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(45, 43);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnDown
            // 
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(67, 132);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(45, 43);
            this.btnDown.TabIndex = 3;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // txtMoveShape
            // 
            this.txtMoveShape.BackColor = System.Drawing.Color.White;
            this.txtMoveShape.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMoveShape.Location = new System.Drawing.Point(56, 12);
            this.txtMoveShape.Name = "txtMoveShape";
            this.txtMoveShape.ReadOnly = true;
            this.txtMoveShape.Size = new System.Drawing.Size(77, 16);
            this.txtMoveShape.TabIndex = 6;
            this.txtMoveShape.Text = "Move Shape";
            // 
            // txtRotateShape
            // 
            this.txtRotateShape.BackColor = System.Drawing.Color.White;
            this.txtRotateShape.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRotateShape.Location = new System.Drawing.Point(233, 12);
            this.txtRotateShape.Name = "txtRotateShape";
            this.txtRotateShape.ReadOnly = true;
            this.txtRotateShape.Size = new System.Drawing.Size(77, 16);
            this.txtRotateShape.TabIndex = 7;
            this.txtRotateShape.Text = "Rotate Shape";
            // 
            // btnRotateRight
            // 
            this.btnRotateRight.Image = ((System.Drawing.Image)(resources.GetObject("btnRotateRight.Image")));
            this.btnRotateRight.Location = new System.Drawing.Point(282, 83);
            this.btnRotateRight.Name = "btnRotateRight";
            this.btnRotateRight.Size = new System.Drawing.Size(45, 43);
            this.btnRotateRight.TabIndex = 10;
            this.btnRotateRight.UseVisualStyleBackColor = true;
            this.btnRotateRight.Click += new System.EventHandler(this.btnRotateRight_Click);
            // 
            // btnRotateLeft
            // 
            this.btnRotateLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnRotateLeft.Image")));
            this.btnRotateLeft.Location = new System.Drawing.Point(209, 83);
            this.btnRotateLeft.Name = "btnRotateLeft";
            this.btnRotateLeft.Size = new System.Drawing.Size(45, 43);
            this.btnRotateLeft.TabIndex = 11;
            this.btnRotateLeft.UseVisualStyleBackColor = true;
            this.btnRotateLeft.Click += new System.EventHandler(this.btnRotateLeft_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(118, 193);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(136, 23);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ShapeMovementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(343, 228);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRotateLeft);
            this.Controls.Add(this.btnRotateRight);
            this.Controls.Add(this.txtRotateShape);
            this.Controls.Add(this.txtMoveShape);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnUp);
            this.MaximizeBox = false;
            this.Name = "ShapeMovementForm";
            this.ShowIcon = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShapeMovementForm_FormClosed);
            this.Load += new System.EventHandler(this.ShapeMovementForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.TextBox txtMoveShape;
        private System.Windows.Forms.TextBox txtRotateShape;
        private System.Windows.Forms.Button btnRotateRight;
        private System.Windows.Forms.Button btnRotateLeft;
        private System.Windows.Forms.Button btnExit;
    }
}