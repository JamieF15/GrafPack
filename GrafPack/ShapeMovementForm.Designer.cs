
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
            this.trkbRotation = new System.Windows.Forms.TrackBar();
            this.txtDegree = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtRotateBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRotateRight = new System.Windows.Forms.Button();
            this.btnRotateLeft = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trkbRotation)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUp
            // 
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(70, 31);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(45, 43);
            this.btnUp.TabIndex = 0;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnRight
            // 
            this.btnRight.Image = ((System.Drawing.Image)(resources.GetObject("btnRight.Image")));
            this.btnRight.Location = new System.Drawing.Point(121, 80);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(45, 43);
            this.btnRight.TabIndex = 1;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnLeft.Image")));
            this.btnLeft.Location = new System.Drawing.Point(19, 80);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(45, 43);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnDown
            // 
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(70, 129);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(45, 43);
            this.btnDown.TabIndex = 3;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // trkbRotation
            // 
            this.trkbRotation.Location = new System.Drawing.Point(425, 96);
            this.trkbRotation.Maximum = 360;
            this.trkbRotation.Name = "trkbRotation";
            this.trkbRotation.Size = new System.Drawing.Size(209, 45);
            this.trkbRotation.TabIndex = 4;
            this.trkbRotation.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkbRotation.Scroll += new System.EventHandler(this.trkbRotation_Scroll);
            // 
            // txtDegree
            // 
            this.txtDegree.Location = new System.Drawing.Point(425, 31);
            this.txtDegree.Name = "txtDegree";
            this.txtDegree.Size = new System.Drawing.Size(209, 23);
            this.txtDegree.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(19, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(77, 16);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Move Shape";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(234, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(77, 16);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "Rotate Shape";
            // 
            // txtRotateBox
            // 
            this.txtRotateBox.Location = new System.Drawing.Point(425, 154);
            this.txtRotateBox.Name = "txtRotateBox";
            this.txtRotateBox.Size = new System.Drawing.Size(100, 23);
            this.txtRotateBox.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(531, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Rotate";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnRotateRight
            // 
            this.btnRotateRight.Image = ((System.Drawing.Image)(resources.GetObject("btnRotateRight.Image")));
            this.btnRotateRight.Location = new System.Drawing.Point(282, 80);
            this.btnRotateRight.Name = "btnRotateRight";
            this.btnRotateRight.Size = new System.Drawing.Size(45, 43);
            this.btnRotateRight.TabIndex = 10;
            this.btnRotateRight.UseVisualStyleBackColor = true;
            this.btnRotateRight.Click += new System.EventHandler(this.btnRotateRight_Click);
            // 
            // btnRotateLeft
            // 
            this.btnRotateLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnRotateLeft.Image")));
            this.btnRotateLeft.Location = new System.Drawing.Point(209, 80);
            this.btnRotateLeft.Name = "btnRotateLeft";
            this.btnRotateLeft.Size = new System.Drawing.Size(45, 43);
            this.btnRotateLeft.TabIndex = 11;
            this.btnRotateLeft.UseVisualStyleBackColor = true;
            this.btnRotateLeft.Click += new System.EventHandler(this.btnRotateLeft_Click);
            // 
            // ShapeMovementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 189);
            this.Controls.Add(this.btnRotateLeft);
            this.Controls.Add(this.btnRotateRight);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtRotateBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtDegree);
            this.Controls.Add(this.trkbRotation);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnUp);
            this.Name = "ShapeMovementForm";
            this.Text = "Tranform Shape";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShapeMovementForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.trkbRotation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.TrackBar trkbRotation;
        private System.Windows.Forms.TextBox txtDegree;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtRotateBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRotateRight;
        private System.Windows.Forms.Button btnRotateLeft;
    }
}