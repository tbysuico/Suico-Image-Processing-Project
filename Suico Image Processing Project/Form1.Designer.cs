
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title10 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            this.bwSlider = new System.Windows.Forms.TrackBar();
            this.bwLabel = new System.Windows.Forms.Label();
            this.gammaButton = new System.Windows.Forms.Button();
            this.gammaSlider = new System.Windows.Forms.TrackBar();
            this.gammaLabel = new System.Windows.Forms.Label();
            this.avgButton = new System.Windows.Forms.Button();
            this.medianButton = new System.Windows.Forms.Button();
            this.highpassButton = new System.Windows.Forms.Button();
            this.unsharpenButton = new System.Windows.Forms.Button();
            this.highboostButton = new System.Windows.Forms.Button();
            this.gradientXYButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.gradientYButton = new System.Windows.Forms.Button();
            this.gradientXButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ogImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPalette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bwSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gammaSlider)).BeginInit();
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
            this.redButton.BackColor = System.Drawing.Color.Red;
            this.redButton.Location = new System.Drawing.Point(648, 111);
            this.redButton.Name = "redButton";
            this.redButton.Size = new System.Drawing.Size(30, 30);
            this.redButton.TabIndex = 13;
            this.redButton.UseVisualStyleBackColor = false;
            this.redButton.Click += new System.EventHandler(this.redButton_Click);
            // 
            // greenButton
            // 
            this.greenButton.BackColor = System.Drawing.Color.Green;
            this.greenButton.Location = new System.Drawing.Point(686, 111);
            this.greenButton.Name = "greenButton";
            this.greenButton.Size = new System.Drawing.Size(30, 30);
            this.greenButton.TabIndex = 14;
            this.greenButton.UseVisualStyleBackColor = false;
            this.greenButton.Click += new System.EventHandler(this.greenButton_Click);
            // 
            // blueButton
            // 
            this.blueButton.BackColor = System.Drawing.Color.Blue;
            this.blueButton.Location = new System.Drawing.Point(724, 111);
            this.blueButton.Name = "blueButton";
            this.blueButton.Size = new System.Drawing.Size(30, 30);
            this.blueButton.TabIndex = 15;
            this.blueButton.UseVisualStyleBackColor = false;
            this.blueButton.Click += new System.EventHandler(this.blueButton_Click);
            // 
            // histogram
            // 
            this.histogram.BackColor = System.Drawing.Color.Transparent;
            this.histogram.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea10.Name = "ChartArea1";
            this.histogram.ChartAreas.Add(chartArea10);
            this.histogram.IsSoftShadows = false;
            legend10.Name = "Legend1";
            this.histogram.Legends.Add(legend10);
            this.histogram.Location = new System.Drawing.Point(210, 369);
            this.histogram.Name = "histogram";
            this.histogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "Pixels";
            this.histogram.Series.Add(series10);
            this.histogram.Size = new System.Drawing.Size(340, 217);
            this.histogram.TabIndex = 16;
            this.histogram.Text = "Histogram";
            title10.Name = "Pixels";
            title10.Text = "Histogram";
            this.histogram.Titles.Add(title10);
            // 
            // grayButton
            // 
            this.grayButton.BackColor = System.Drawing.Color.Gray;
            this.grayButton.Location = new System.Drawing.Point(648, 147);
            this.grayButton.Name = "grayButton";
            this.grayButton.Size = new System.Drawing.Size(106, 23);
            this.grayButton.TabIndex = 17;
            this.grayButton.UseVisualStyleBackColor = false;
            this.grayButton.Click += new System.EventHandler(this.grayButton_Click);
            // 
            // negativeButton
            // 
            this.negativeButton.Location = new System.Drawing.Point(648, 205);
            this.negativeButton.Name = "negativeButton";
            this.negativeButton.Size = new System.Drawing.Size(106, 23);
            this.negativeButton.TabIndex = 18;
            this.negativeButton.Text = "Negative";
            this.negativeButton.UseVisualStyleBackColor = true;
            this.negativeButton.Click += new System.EventHandler(this.negativeButton_Click);
            // 
            // bwButton
            // 
            this.bwButton.Location = new System.Drawing.Point(518, 322);
            this.bwButton.Name = "bwButton";
            this.bwButton.Size = new System.Drawing.Size(106, 23);
            this.bwButton.TabIndex = 19;
            this.bwButton.Text = "B/W Thresholding";
            this.bwButton.UseVisualStyleBackColor = true;
            this.bwButton.Click += new System.EventHandler(this.bwButton_Click);
            // 
            // bwSlider
            // 
            this.bwSlider.Location = new System.Drawing.Point(562, 361);
            this.bwSlider.Maximum = 255;
            this.bwSlider.Name = "bwSlider";
            this.bwSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.bwSlider.Size = new System.Drawing.Size(45, 261);
            this.bwSlider.TabIndex = 20;
            this.bwSlider.TickFrequency = 10;
            this.bwSlider.Value = 125;
            this.bwSlider.Scroll += new System.EventHandler(this.bwSlider_Scroll);
            // 
            // bwLabel
            // 
            this.bwLabel.AutoSize = true;
            this.bwLabel.Location = new System.Drawing.Point(560, 347);
            this.bwLabel.Name = "bwLabel";
            this.bwLabel.Size = new System.Drawing.Size(25, 13);
            this.bwLabel.TabIndex = 22;
            this.bwLabel.Text = "125";
            // 
            // gammaButton
            // 
            this.gammaButton.Location = new System.Drawing.Point(648, 293);
            this.gammaButton.Name = "gammaButton";
            this.gammaButton.Size = new System.Drawing.Size(106, 23);
            this.gammaButton.TabIndex = 23;
            this.gammaButton.Text = "Gamma";
            this.gammaButton.UseVisualStyleBackColor = true;
            this.gammaButton.Click += new System.EventHandler(this.gammaButton_Click);
            // 
            // gammaSlider
            // 
            this.gammaSlider.Location = new System.Drawing.Point(648, 265);
            this.gammaSlider.Name = "gammaSlider";
            this.gammaSlider.Size = new System.Drawing.Size(106, 45);
            this.gammaSlider.TabIndex = 24;
            this.gammaSlider.Value = 5;
            this.gammaSlider.Scroll += new System.EventHandler(this.gammaSlider_Scroll);
            // 
            // gammaLabel
            // 
            this.gammaLabel.AutoSize = true;
            this.gammaLabel.Location = new System.Drawing.Point(694, 250);
            this.gammaLabel.Name = "gammaLabel";
            this.gammaLabel.Size = new System.Drawing.Size(13, 13);
            this.gammaLabel.TabIndex = 25;
            this.gammaLabel.Text = "5";
            // 
            // avgButton
            // 
            this.avgButton.Location = new System.Drawing.Point(648, 351);
            this.avgButton.Name = "avgButton";
            this.avgButton.Size = new System.Drawing.Size(106, 23);
            this.avgButton.TabIndex = 26;
            this.avgButton.Text = "Averaging";
            this.avgButton.UseVisualStyleBackColor = true;
            this.avgButton.Click += new System.EventHandler(this.avgButton_Click);
            // 
            // medianButton
            // 
            this.medianButton.Location = new System.Drawing.Point(648, 380);
            this.medianButton.Name = "medianButton";
            this.medianButton.Size = new System.Drawing.Size(106, 23);
            this.medianButton.TabIndex = 27;
            this.medianButton.Text = "Median";
            this.medianButton.UseVisualStyleBackColor = true;
            this.medianButton.Click += new System.EventHandler(this.medianButton_Click);
            // 
            // highpassButton
            // 
            this.highpassButton.Location = new System.Drawing.Point(648, 409);
            this.highpassButton.Name = "highpassButton";
            this.highpassButton.Size = new System.Drawing.Size(106, 23);
            this.highpassButton.TabIndex = 28;
            this.highpassButton.Text = "Highpass";
            this.highpassButton.UseVisualStyleBackColor = true;
            this.highpassButton.Click += new System.EventHandler(this.highpassButton_Click);
            // 
            // unsharpenButton
            // 
            this.unsharpenButton.Location = new System.Drawing.Point(648, 438);
            this.unsharpenButton.Name = "unsharpenButton";
            this.unsharpenButton.Size = new System.Drawing.Size(106, 23);
            this.unsharpenButton.TabIndex = 29;
            this.unsharpenButton.Text = "Unsharpen";
            this.unsharpenButton.UseVisualStyleBackColor = true;
            this.unsharpenButton.Click += new System.EventHandler(this.unsharpenButton_Click);
            // 
            // highboostButton
            // 
            this.highboostButton.Location = new System.Drawing.Point(648, 467);
            this.highboostButton.Name = "highboostButton";
            this.highboostButton.Size = new System.Drawing.Size(106, 23);
            this.highboostButton.TabIndex = 30;
            this.highboostButton.Text = "Highboost";
            this.highboostButton.UseVisualStyleBackColor = true;
            this.highboostButton.Click += new System.EventHandler(this.highboostButton_Click);
            // 
            // gradientXYButton
            // 
            this.gradientXYButton.Location = new System.Drawing.Point(723, 539);
            this.gradientXYButton.Name = "gradientXYButton";
            this.gradientXYButton.Size = new System.Drawing.Size(30, 20);
            this.gradientXYButton.TabIndex = 38;
            this.gradientXYButton.Text = "xy";
            this.gradientXYButton.UseVisualStyleBackColor = true;
            this.gradientXYButton.Click += new System.EventHandler(this.gradientXYButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(675, 523);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Gradient";
            // 
            // gradientYButton
            // 
            this.gradientYButton.Location = new System.Drawing.Point(685, 539);
            this.gradientYButton.Name = "gradientYButton";
            this.gradientYButton.Size = new System.Drawing.Size(30, 20);
            this.gradientYButton.TabIndex = 36;
            this.gradientYButton.Text = "y";
            this.gradientYButton.UseVisualStyleBackColor = true;
            this.gradientYButton.Click += new System.EventHandler(this.gradientYButton_Click);
            // 
            // gradientXButton
            // 
            this.gradientXButton.Location = new System.Drawing.Point(647, 539);
            this.gradientXButton.Name = "gradientXButton";
            this.gradientXButton.Size = new System.Drawing.Size(30, 20);
            this.gradientXButton.TabIndex = 35;
            this.gradientXButton.Text = "x";
            this.gradientXButton.UseVisualStyleBackColor = true;
            this.gradientXButton.Click += new System.EventHandler(this.gradientXButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 651);
            this.Controls.Add(this.gradientXYButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gradientYButton);
            this.Controls.Add(this.gradientXButton);
            this.Controls.Add(this.highboostButton);
            this.Controls.Add(this.unsharpenButton);
            this.Controls.Add(this.highpassButton);
            this.Controls.Add(this.medianButton);
            this.Controls.Add(this.gammaButton);
            this.Controls.Add(this.avgButton);
            this.Controls.Add(this.gammaLabel);
            this.Controls.Add(this.gammaSlider);
            this.Controls.Add(this.bwLabel);
            this.Controls.Add(this.bwSlider);
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
            ((System.ComponentModel.ISupportInitialize)(this.bwSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gammaSlider)).EndInit();
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
        public System.Windows.Forms.TrackBar bwSlider;
        private System.Windows.Forms.Button gammaButton;
        public System.Windows.Forms.TrackBar gammaSlider;
        private System.Windows.Forms.Label gammaLabel;
        private System.Windows.Forms.Button avgButton;
        private System.Windows.Forms.Button medianButton;
        private System.Windows.Forms.Button highpassButton;
        private System.Windows.Forms.Button unsharpenButton;
        private System.Windows.Forms.Button highboostButton;
        private System.Windows.Forms.Button gradientXYButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button gradientYButton;
        private System.Windows.Forms.Button gradientXButton;
    }
}

