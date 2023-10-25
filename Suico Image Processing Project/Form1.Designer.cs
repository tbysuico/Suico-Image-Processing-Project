
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.ogImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.open = new System.Windows.Forms.Button();
            this.imageInfo = new System.Windows.Forms.TextBox();
            this.colorPalette = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.processedImage = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.redButton = new System.Windows.Forms.Button();
            this.greenButton = new System.Windows.Forms.Button();
            this.blueButton = new System.Windows.Forms.Button();
            this.histogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grayButton = new System.Windows.Forms.Button();
            this.negativeButton = new System.Windows.Forms.Button();
            this.bwButton = new System.Windows.Forms.Button();
            this.slider = new System.Windows.Forms.TrackBar();
            this.bwLabel = new System.Windows.Forms.Label();
            this.gammaButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ogImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPalette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
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
            this.open.Location = new System.Drawing.Point(648, 31);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(106, 23);
            this.open.TabIndex = 7;
            this.open.Text = "Open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // imageInfo
            // 
            this.imageInfo.Location = new System.Drawing.Point(34, 325);
            this.imageInfo.Multiline = true;
            this.imageInfo.Name = "imageInfo";
            this.imageInfo.ReadOnly = true;
            this.imageInfo.Size = new System.Drawing.Size(158, 297);
            this.imageInfo.TabIndex = 9;
            this.imageInfo.TabStop = false;
            this.imageInfo.Text = resources.GetString("imageInfo.Text");
            // 
            // colorPalette
            // 
            this.colorPalette.Location = new System.Drawing.Point(60, 520);
            this.colorPalette.Name = "colorPalette";
            this.colorPalette.Size = new System.Drawing.Size(80, 80);
            this.colorPalette.TabIndex = 10;
            this.colorPalette.TabStop = false;
            // 
            // processedImage
            // 
            this.processedImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.processedImage.Location = new System.Drawing.Point(352, 31);
            this.processedImage.Name = "processedImage";
            this.processedImage.Size = new System.Drawing.Size(255, 255);
            this.processedImage.TabIndex = 11;
            this.processedImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Processed Image";
            // 
            // redButton
            // 
            this.redButton.Location = new System.Drawing.Point(648, 60);
            this.redButton.Name = "redButton";
            this.redButton.Size = new System.Drawing.Size(106, 23);
            this.redButton.TabIndex = 13;
            this.redButton.Text = "Red Channel";
            this.redButton.UseVisualStyleBackColor = true;
            this.redButton.Click += new System.EventHandler(this.redButton_Click);
            // 
            // greenButton
            // 
            this.greenButton.Location = new System.Drawing.Point(648, 89);
            this.greenButton.Name = "greenButton";
            this.greenButton.Size = new System.Drawing.Size(106, 23);
            this.greenButton.TabIndex = 14;
            this.greenButton.Text = "Green Channel";
            this.greenButton.UseVisualStyleBackColor = true;
            this.greenButton.Click += new System.EventHandler(this.greenButton_Click);
            // 
            // blueButton
            // 
            this.blueButton.Location = new System.Drawing.Point(648, 118);
            this.blueButton.Name = "blueButton";
            this.blueButton.Size = new System.Drawing.Size(106, 23);
            this.blueButton.TabIndex = 15;
            this.blueButton.Text = "Blue Channel";
            this.blueButton.UseVisualStyleBackColor = true;
            this.blueButton.Click += new System.EventHandler(this.blueButton_Click);
            // 
            // histogram
            // 
            this.histogram.BackColor = System.Drawing.Color.Transparent;
            this.histogram.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.histogram.ChartAreas.Add(chartArea2);
            this.histogram.IsSoftShadows = false;
            legend2.Name = "Legend1";
            this.histogram.Legends.Add(legend2);
            this.histogram.Location = new System.Drawing.Point(267, 369);
            this.histogram.Name = "histogram";
            this.histogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Pixels";
            this.histogram.Series.Add(series2);
            this.histogram.Size = new System.Drawing.Size(340, 217);
            this.histogram.TabIndex = 16;
            this.histogram.Text = "Histogram";
            title2.Name = "Pixels";
            title2.Text = "Histogram";
            this.histogram.Titles.Add(title2);
            // 
            // grayButton
            // 
            this.grayButton.Location = new System.Drawing.Point(648, 147);
            this.grayButton.Name = "grayButton";
            this.grayButton.Size = new System.Drawing.Size(106, 23);
            this.grayButton.TabIndex = 17;
            this.grayButton.Text = "Grayscale";
            this.grayButton.UseVisualStyleBackColor = true;
            this.grayButton.Click += new System.EventHandler(this.grayButton_Click);
            // 
            // negativeButton
            // 
            this.negativeButton.Location = new System.Drawing.Point(648, 176);
            this.negativeButton.Name = "negativeButton";
            this.negativeButton.Size = new System.Drawing.Size(106, 23);
            this.negativeButton.TabIndex = 18;
            this.negativeButton.Text = "Negative";
            this.negativeButton.UseVisualStyleBackColor = true;
            this.negativeButton.Click += new System.EventHandler(this.negativeButton_Click);
            // 
            // bwButton
            // 
            this.bwButton.Location = new System.Drawing.Point(648, 205);
            this.bwButton.Name = "bwButton";
            this.bwButton.Size = new System.Drawing.Size(106, 23);
            this.bwButton.TabIndex = 19;
            this.bwButton.Text = "B/W Thresholding";
            this.bwButton.UseVisualStyleBackColor = true;
            this.bwButton.Click += new System.EventHandler(this.bwButton_Click);
            // 
            // slider
            // 
            this.slider.Location = new System.Drawing.Point(691, 309);
            this.slider.Maximum = 255;
            this.slider.Name = "slider";
            this.slider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.slider.Size = new System.Drawing.Size(45, 261);
            this.slider.TabIndex = 20;
            this.slider.TickFrequency = 10;
            this.slider.Scroll += new System.EventHandler(this.slider_Scroll);
            // 
            // bwLabel
            // 
            this.bwLabel.AutoSize = true;
            this.bwLabel.Location = new System.Drawing.Point(694, 293);
            this.bwLabel.Name = "bwLabel";
            this.bwLabel.Size = new System.Drawing.Size(13, 13);
            this.bwLabel.TabIndex = 22;
            this.bwLabel.Text = "0";
            // 
            // gammaButton
            // 
            this.gammaButton.Location = new System.Drawing.Point(648, 234);
            this.gammaButton.Name = "gammaButton";
            this.gammaButton.Size = new System.Drawing.Size(106, 23);
            this.gammaButton.TabIndex = 23;
            this.gammaButton.Text = "Gamma";
            this.gammaButton.UseVisualStyleBackColor = true;
            this.gammaButton.Click += new System.EventHandler(this.gammaButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 651);
            this.Controls.Add(this.gammaButton);
            this.Controls.Add(this.bwLabel);
            this.Controls.Add(this.slider);
            this.Controls.Add(this.bwButton);
            this.Controls.Add(this.negativeButton);
            this.Controls.Add(this.grayButton);
            this.Controls.Add(this.histogram);
            this.Controls.Add(this.blueButton);
            this.Controls.Add(this.greenButton);
            this.Controls.Add(this.redButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.processedImage);
            this.Controls.Add(this.colorPalette);
            this.Controls.Add(this.imageInfo);
            this.Controls.Add(this.open);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ogImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ogImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPalette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ogImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button open;
        public System.Windows.Forms.TextBox imageInfo;
        private System.Windows.Forms.PictureBox colorPalette;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox processedImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button redButton;
        private System.Windows.Forms.Button greenButton;
        private System.Windows.Forms.Button blueButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart histogram;
        private System.Windows.Forms.Button grayButton;
        private System.Windows.Forms.Button negativeButton;
        private System.Windows.Forms.Button bwButton;
        private System.Windows.Forms.Label bwLabel;
        public System.Windows.Forms.TrackBar slider;
        private System.Windows.Forms.Button gammaButton;
    }
}

