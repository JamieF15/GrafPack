
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
            this.shapeInfobx = new System.Windows.Forms.TextBox();
            this.Deletebtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Rightbtn
            // 
            this.Rightbtn.Location = new System.Drawing.Point(145, 12);
            this.Rightbtn.Name = "Rightbtn";
            this.Rightbtn.Size = new System.Drawing.Size(127, 45);
            this.Rightbtn.TabIndex = 1;
            this.Rightbtn.Text = "Select Towards Last Shape";
            this.Rightbtn.UseVisualStyleBackColor = true;
            this.Rightbtn.Click += new System.EventHandler(this.Rightbtn_Click);
            // 
            // Leftbtn
            // 
            this.Leftbtn.Location = new System.Drawing.Point(12, 12);
            this.Leftbtn.Name = "Leftbtn";
            this.Leftbtn.Size = new System.Drawing.Size(127, 45);
            this.Leftbtn.TabIndex = 0;
            this.Leftbtn.Text = "Select Towards First Shape";
            this.Leftbtn.UseVisualStyleBackColor = true;
            this.Leftbtn.Click += new System.EventHandler(this.Leftbtn_Click);
            // 
            // shapeInfobx
            // 
            this.shapeInfobx.Location = new System.Drawing.Point(249, 75);
            this.shapeInfobx.Multiline = true;
            this.shapeInfobx.Name = "shapeInfobx";
            this.shapeInfobx.ReadOnly = true;
            this.shapeInfobx.Size = new System.Drawing.Size(182, 27);
            this.shapeInfobx.TabIndex = 3;
            this.shapeInfobx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Deletebtn
            // 
            this.Deletebtn.Location = new System.Drawing.Point(411, 12);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(127, 45);
            this.Deletebtn.TabIndex = 4;
            this.Deletebtn.Text = "Delete";
            this.Deletebtn.UseVisualStyleBackColor = true;
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(278, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 45);
            this.button2.TabIndex = 2;
            this.button2.Text = "Transform Shape";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(544, 12);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(127, 45);
            this.ExitBtn.TabIndex = 6;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // ShapeSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 121);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Deletebtn);
            this.Controls.Add(this.shapeInfobx);
            this.Controls.Add(this.Leftbtn);
            this.Controls.Add(this.Rightbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShapeSelectionForm";
            this.RightToLeftLayout = true;
            this.Text = "ShapeSelectionForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShapeSelectionForm_FormClosed);
            this.Load += new System.EventHandler(this.ShapeSelectionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Rightbtn;
        private System.Windows.Forms.Button Leftbtn;
        private System.Windows.Forms.TextBox shapeInfobx;
        private System.Windows.Forms.Button Deletebtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ExitBtn;
    }
}