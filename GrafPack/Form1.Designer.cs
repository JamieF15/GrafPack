
namespace GrafPack
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ExitButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.TransformButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CanvasPan = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExitButton.Location = new System.Drawing.Point(556, 8);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(93, 32);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeleteButton.Location = new System.Drawing.Point(422, 8);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(128, 32);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // TransformButton
            // 
            this.TransformButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TransformButton.Location = new System.Drawing.Point(288, 8);
            this.TransformButton.Name = "TransformButton";
            this.TransformButton.Size = new System.Drawing.Size(128, 32);
            this.TransformButton.TabIndex = 2;
            this.TransformButton.Text = "Transform";
            this.TransformButton.UseVisualStyleBackColor = true;
            // 
            // CreateButton
            // 
            this.CreateButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateButton.Location = new System.Drawing.Point(20, 8);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(128, 32);
            this.CreateButton.TabIndex = 0;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SelectButton.Location = new System.Drawing.Point(154, 8);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(128, 32);
            this.SelectButton.TabIndex = 1;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CreateButton);
            this.panel1.Controls.Add(this.ExitButton);
            this.panel1.Controls.Add(this.SelectButton);
            this.panel1.Controls.Add(this.TransformButton);
            this.panel1.Controls.Add(this.DeleteButton);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 63);
            this.panel1.TabIndex = 5;
            // 
            // CanvasPan
            // 
            this.CanvasPan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CanvasPan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CanvasPan.Location = new System.Drawing.Point(0, 46);
            this.CanvasPan.Name = "CanvasPan";
            this.CanvasPan.Size = new System.Drawing.Size(669, 403);
            this.CanvasPan.TabIndex = 6;
            this.CanvasPan.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CanvasPan_MouseDown);
            this.CanvasPan.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CanvasPan_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(669, 450);
            this.Controls.Add(this.CanvasPan);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Shape Maker 4000";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button TransformButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel CanvasPan;
    }
}

