
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
            this.btnTowardsLastShape = new System.Windows.Forms.Button();
            this.btnTowardsFirstShape = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnTransform = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTowardsLastShape
            // 
            this.btnTowardsLastShape.Location = new System.Drawing.Point(145, 12);
            this.btnTowardsLastShape.Name = "btnTowardsLastShape";
            this.btnTowardsLastShape.Size = new System.Drawing.Size(127, 45);
            this.btnTowardsLastShape.TabIndex = 1;
            this.btnTowardsLastShape.Text = "Select Towards Next Shape";
            this.btnTowardsLastShape.UseVisualStyleBackColor = true;
            this.btnTowardsLastShape.Click += new System.EventHandler(this.Rightbtn_Click);
            // 
            // btnTowardsFirstShape
            // 
            this.btnTowardsFirstShape.Location = new System.Drawing.Point(12, 12);
            this.btnTowardsFirstShape.Name = "btnTowardsFirstShape";
            this.btnTowardsFirstShape.Size = new System.Drawing.Size(127, 45);
            this.btnTowardsFirstShape.TabIndex = 0;
            this.btnTowardsFirstShape.Text = "Select Towards Previous Shape";
            this.btnTowardsFirstShape.UseVisualStyleBackColor = true;
            this.btnTowardsFirstShape.Click += new System.EventHandler(this.Leftbtn_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(411, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(127, 45);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // btnTransform
            // 
            this.btnTransform.Location = new System.Drawing.Point(278, 12);
            this.btnTransform.Name = "btnTransform";
            this.btnTransform.Size = new System.Drawing.Size(127, 45);
            this.btnTransform.TabIndex = 2;
            this.btnTransform.Text = "Transform Shape";
            this.btnTransform.UseVisualStyleBackColor = true;
            this.btnTransform.Click += new System.EventHandler(this.btnTransform_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(544, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(127, 45);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // ShapeSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 68);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnTransform);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnTowardsFirstShape);
            this.Controls.Add(this.btnTowardsLastShape);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShapeSelectionForm";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShapeSelectionForm_FormClosed);
            this.Load += new System.EventHandler(this.ShapeSelectionForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTowardsLastShape;
        private System.Windows.Forms.Button btnTowardsFirstShape;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnTransform;
        private System.Windows.Forms.Button btnExit;
    }
}