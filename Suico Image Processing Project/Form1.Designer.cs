
namespace Suico_Image_Processing_Project
{
    partial class Form1
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
            this.ogImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.open = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ogImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ogImage
            // 
            this.ogImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ogImage.Location = new System.Drawing.Point(34, 31);
            this.ogImage.Name = "ogImage";
            this.ogImage.Size = new System.Drawing.Size(255, 255);
            this.ogImage.TabIndex = 1;
            this.ogImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Original Image";
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(650, 31);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(106, 23);
            this.open.TabIndex = 7;
            this.open.Text = "Open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.open);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ogImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ogImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ogImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button open;
    }
}

