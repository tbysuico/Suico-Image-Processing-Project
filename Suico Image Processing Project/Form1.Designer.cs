
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            this.imgDeg = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imgDegSlider = new System.Windows.Forms.TrackBar();
            this.noiseLevel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.imgRes = new System.Windows.Forms.ComboBox();
            this.qSlider = new System.Windows.Forms.TrackBar();
            this.qIndex = new System.Windows.Forms.Label();
            this.RLE = new System.Windows.Forms.Button();
            this.test = new System.Windows.Forms.Label();
            this.videoPlayer = new System.Windows.Forms.Button();
            this.imgSize1 = new System.Windows.Forms.Label();
            this.imgSize2 = new System.Windows.Forms.Label();
            this.pause = new System.Windows.Forms.Button();
            this.play = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Huffman = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ogImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPalette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bwSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gammaSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDegSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // ogImage
            // 
            this.ogImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ogImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ogImage.Location = new System.Drawing.Point(57, 44);
            this.ogImage.Name = "ogImage";
            this.ogImage.Size = new System.Drawing.Size(255, 255);
            this.ogImage.TabIndex = 1;
            this.ogImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Original Image";
            // 
            // open
            // 
            this.open.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.open.Location = new System.Drawing.Point(696, 43);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(106, 23);
            this.open.TabIndex = 7;
            this.open.Text = "Open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // imageInfo
            // 
            this.imageInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageInfo.Location = new System.Drawing.Point(57, 338);
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
            this.colorPalette.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.colorPalette.Location = new System.Drawing.Point(83, 533);
            this.colorPalette.Name = "colorPalette";
            this.colorPalette.Size = new System.Drawing.Size(80, 80);
            this.colorPalette.TabIndex = 10;
            this.colorPalette.TabStop = false;
            // 
            // processedImage
            // 
            this.processedImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.processedImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.processedImage.Location = new System.Drawing.Point(375, 44);
            this.processedImage.Name = "processedImage";
            this.processedImage.Size = new System.Drawing.Size(255, 255);
            this.processedImage.TabIndex = 11;
            this.processedImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Processed Image";
            // 
            // redButton
            // 
            this.redButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.redButton.BackColor = System.Drawing.Color.Red;
            this.redButton.Location = new System.Drawing.Point(696, 128);
            this.redButton.Name = "redButton";
            this.redButton.Size = new System.Drawing.Size(30, 30);
            this.redButton.TabIndex = 13;
            this.redButton.UseVisualStyleBackColor = false;
            this.redButton.Click += new System.EventHandler(this.redButton_Click);
            // 
            // greenButton
            // 
            this.greenButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.greenButton.BackColor = System.Drawing.Color.Green;
            this.greenButton.Location = new System.Drawing.Point(734, 128);
            this.greenButton.Name = "greenButton";
            this.greenButton.Size = new System.Drawing.Size(30, 30);
            this.greenButton.TabIndex = 14;
            this.greenButton.UseVisualStyleBackColor = false;
            this.greenButton.Click += new System.EventHandler(this.greenButton_Click);
            // 
            // blueButton
            // 
            this.blueButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.blueButton.BackColor = System.Drawing.Color.Blue;
            this.blueButton.Location = new System.Drawing.Point(772, 128);
            this.blueButton.Name = "blueButton";
            this.blueButton.Size = new System.Drawing.Size(30, 30);
            this.blueButton.TabIndex = 15;
            this.blueButton.UseVisualStyleBackColor = false;
            this.blueButton.Click += new System.EventHandler(this.blueButton_Click);
            // 
            // histogram
            // 
            this.histogram.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.histogram.BackColor = System.Drawing.Color.Transparent;
            this.histogram.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.histogram.ChartAreas.Add(chartArea1);
            this.histogram.IsSoftShadows = false;
            legend1.Name = "Legend1";
            this.histogram.Legends.Add(legend1);
            this.histogram.Location = new System.Drawing.Point(290, 418);
            this.histogram.Name = "histogram";
            this.histogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Pixels";
            this.histogram.Series.Add(series1);
            this.histogram.Size = new System.Drawing.Size(340, 217);
            this.histogram.TabIndex = 16;
            this.histogram.Text = "Histogram";
            title1.Name = "Pixels";
            title1.Text = "Histogram";
            this.histogram.Titles.Add(title1);
            // 
            // grayButton
            // 
            this.grayButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grayButton.BackColor = System.Drawing.Color.Gray;
            this.grayButton.Location = new System.Drawing.Point(696, 164);
            this.grayButton.Name = "grayButton";
            this.grayButton.Size = new System.Drawing.Size(106, 23);
            this.grayButton.TabIndex = 17;
            this.grayButton.UseVisualStyleBackColor = false;
            this.grayButton.Click += new System.EventHandler(this.grayButton_Click);
            // 
            // negativeButton
            // 
            this.negativeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.negativeButton.Location = new System.Drawing.Point(696, 211);
            this.negativeButton.Name = "negativeButton";
            this.negativeButton.Size = new System.Drawing.Size(106, 23);
            this.negativeButton.TabIndex = 18;
            this.negativeButton.Text = "Negative";
            this.negativeButton.UseVisualStyleBackColor = true;
            this.negativeButton.Click += new System.EventHandler(this.negativeButton_Click);
            // 
            // bwButton
            // 
            this.bwButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bwButton.Location = new System.Drawing.Point(838, 393);
            this.bwButton.Name = "bwButton";
            this.bwButton.Size = new System.Drawing.Size(106, 23);
            this.bwButton.TabIndex = 19;
            this.bwButton.Text = "B/W Thresholding";
            this.bwButton.UseVisualStyleBackColor = true;
            this.bwButton.Click += new System.EventHandler(this.bwButton_Click);
            // 
            // bwSlider
            // 
            this.bwSlider.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bwSlider.Location = new System.Drawing.Point(881, 433);
            this.bwSlider.Maximum = 255;
            this.bwSlider.Name = "bwSlider";
            this.bwSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.bwSlider.Size = new System.Drawing.Size(45, 202);
            this.bwSlider.TabIndex = 20;
            this.bwSlider.TickFrequency = 10;
            this.bwSlider.Value = 125;
            this.bwSlider.Scroll += new System.EventHandler(this.bwSlider_Scroll);
            // 
            // bwLabel
            // 
            this.bwLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bwLabel.AutoSize = true;
            this.bwLabel.Location = new System.Drawing.Point(839, 420);
            this.bwLabel.Name = "bwLabel";
            this.bwLabel.Size = new System.Drawing.Size(104, 13);
            this.bwLabel.TabIndex = 22;
            this.bwLabel.Text = "B/W Threshold: 125";
            // 
            // gammaButton
            // 
            this.gammaButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gammaButton.Location = new System.Drawing.Point(696, 242);
            this.gammaButton.Name = "gammaButton";
            this.gammaButton.Size = new System.Drawing.Size(106, 23);
            this.gammaButton.TabIndex = 23;
            this.gammaButton.Text = "Gamma";
            this.gammaButton.UseVisualStyleBackColor = true;
            this.gammaButton.Click += new System.EventHandler(this.gammaButton_Click);
            // 
            // gammaSlider
            // 
            this.gammaSlider.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gammaSlider.Location = new System.Drawing.Point(695, 286);
            this.gammaSlider.Name = "gammaSlider";
            this.gammaSlider.Size = new System.Drawing.Size(106, 45);
            this.gammaSlider.TabIndex = 24;
            this.gammaSlider.Value = 5;
            this.gammaSlider.Scroll += new System.EventHandler(this.gammaSlider_Scroll);
            // 
            // gammaLabel
            // 
            this.gammaLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gammaLabel.AutoSize = true;
            this.gammaLabel.Location = new System.Drawing.Point(706, 271);
            this.gammaLabel.Name = "gammaLabel";
            this.gammaLabel.Size = new System.Drawing.Size(84, 13);
            this.gammaLabel.TabIndex = 25;
            this.gammaLabel.Text = "Gamma Index: 5";
            // 
            // avgButton
            // 
            this.avgButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.avgButton.Location = new System.Drawing.Point(696, 336);
            this.avgButton.Name = "avgButton";
            this.avgButton.Size = new System.Drawing.Size(106, 23);
            this.avgButton.TabIndex = 26;
            this.avgButton.Text = "Averaging";
            this.avgButton.UseVisualStyleBackColor = true;
            this.avgButton.Click += new System.EventHandler(this.avgButton_Click);
            // 
            // medianButton
            // 
            this.medianButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.medianButton.Location = new System.Drawing.Point(696, 365);
            this.medianButton.Name = "medianButton";
            this.medianButton.Size = new System.Drawing.Size(106, 23);
            this.medianButton.TabIndex = 27;
            this.medianButton.Text = "Median";
            this.medianButton.UseVisualStyleBackColor = true;
            this.medianButton.Click += new System.EventHandler(this.medianButton_Click);
            // 
            // highpassButton
            // 
            this.highpassButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.highpassButton.Location = new System.Drawing.Point(696, 394);
            this.highpassButton.Name = "highpassButton";
            this.highpassButton.Size = new System.Drawing.Size(106, 23);
            this.highpassButton.TabIndex = 28;
            this.highpassButton.Text = "Highpass";
            this.highpassButton.UseVisualStyleBackColor = true;
            this.highpassButton.Click += new System.EventHandler(this.highpassButton_Click);
            // 
            // unsharpenButton
            // 
            this.unsharpenButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.unsharpenButton.Location = new System.Drawing.Point(696, 423);
            this.unsharpenButton.Name = "unsharpenButton";
            this.unsharpenButton.Size = new System.Drawing.Size(106, 23);
            this.unsharpenButton.TabIndex = 29;
            this.unsharpenButton.Text = "Unsharpen";
            this.unsharpenButton.UseVisualStyleBackColor = true;
            this.unsharpenButton.Click += new System.EventHandler(this.unsharpenButton_Click);
            // 
            // highboostButton
            // 
            this.highboostButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.highboostButton.Location = new System.Drawing.Point(696, 452);
            this.highboostButton.Name = "highboostButton";
            this.highboostButton.Size = new System.Drawing.Size(106, 23);
            this.highboostButton.TabIndex = 30;
            this.highboostButton.Text = "Highboost";
            this.highboostButton.UseVisualStyleBackColor = true;
            this.highboostButton.Click += new System.EventHandler(this.highboostButton_Click);
            // 
            // gradientXYButton
            // 
            this.gradientXYButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gradientXYButton.Location = new System.Drawing.Point(914, 349);
            this.gradientXYButton.Name = "gradientXYButton";
            this.gradientXYButton.Size = new System.Drawing.Size(30, 20);
            this.gradientXYButton.TabIndex = 38;
            this.gradientXYButton.Text = "xy";
            this.gradientXYButton.UseVisualStyleBackColor = true;
            this.gradientXYButton.Click += new System.EventHandler(this.gradientXYButton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(866, 333);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Gradient";
            // 
            // gradientYButton
            // 
            this.gradientYButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gradientYButton.Location = new System.Drawing.Point(876, 349);
            this.gradientYButton.Name = "gradientYButton";
            this.gradientYButton.Size = new System.Drawing.Size(30, 20);
            this.gradientYButton.TabIndex = 36;
            this.gradientYButton.Text = "y";
            this.gradientYButton.UseVisualStyleBackColor = true;
            this.gradientYButton.Click += new System.EventHandler(this.gradientYButton_Click);
            // 
            // gradientXButton
            // 
            this.gradientXButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gradientXButton.Location = new System.Drawing.Point(838, 349);
            this.gradientXButton.Name = "gradientXButton";
            this.gradientXButton.Size = new System.Drawing.Size(30, 20);
            this.gradientXButton.TabIndex = 35;
            this.gradientXButton.Text = "x";
            this.gradientXButton.UseVisualStyleBackColor = true;
            this.gradientXButton.Click += new System.EventHandler(this.gradientXButton_Click);
            // 
            // imgDeg
            // 
            this.imgDeg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgDeg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imgDeg.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgDeg.FormattingEnabled = true;
            this.imgDeg.Items.AddRange(new object[] {
            "Salt Noise",
            "Pepper Noise",
            "Salt and Pepper Noise"});
            this.imgDeg.Location = new System.Drawing.Point(837, 138);
            this.imgDeg.Name = "imgDeg";
            this.imgDeg.Size = new System.Drawing.Size(107, 21);
            this.imgDeg.TabIndex = 39;
            this.imgDeg.SelectedIndexChanged += new System.EventHandler(this.imgDeg_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(843, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Image Degradation";
            // 
            // imgDegSlider
            // 
            this.imgDegSlider.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgDegSlider.Location = new System.Drawing.Point(838, 174);
            this.imgDegSlider.Name = "imgDegSlider";
            this.imgDegSlider.Size = new System.Drawing.Size(106, 45);
            this.imgDegSlider.TabIndex = 41;
            this.imgDegSlider.Value = 5;
            this.imgDegSlider.Scroll += new System.EventHandler(this.imgDegSlider_Scroll);
            // 
            // noiseLevel
            // 
            this.noiseLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.noiseLevel.AutoSize = true;
            this.noiseLevel.Location = new System.Drawing.Point(849, 162);
            this.noiseLevel.Name = "noiseLevel";
            this.noiseLevel.Size = new System.Drawing.Size(83, 13);
            this.noiseLevel.TabIndex = 42;
            this.noiseLevel.Text = "Noise Level: 5%";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(845, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Image Restoration";
            // 
            // imgRes
            // 
            this.imgRes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imgRes.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgRes.FormattingEnabled = true;
            this.imgRes.Items.AddRange(new object[] {
            "Geometric Mean",
            "Contraharmonic",
            "Median"});
            this.imgRes.Location = new System.Drawing.Point(838, 242);
            this.imgRes.Name = "imgRes";
            this.imgRes.Size = new System.Drawing.Size(107, 21);
            this.imgRes.TabIndex = 44;
            this.imgRes.SelectedIndexChanged += new System.EventHandler(this.imgRes_SelectedIndexChanged);
            // 
            // qSlider
            // 
            this.qSlider.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.qSlider.Location = new System.Drawing.Point(838, 285);
            this.qSlider.Maximum = 5;
            this.qSlider.Minimum = -5;
            this.qSlider.Name = "qSlider";
            this.qSlider.Size = new System.Drawing.Size(106, 45);
            this.qSlider.TabIndex = 48;
            this.qSlider.Scroll += new System.EventHandler(this.qSlider_Scroll);
            // 
            // qIndex
            // 
            this.qIndex.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.qIndex.AutoSize = true;
            this.qIndex.Location = new System.Drawing.Point(825, 269);
            this.qIndex.Name = "qIndex";
            this.qIndex.Size = new System.Drawing.Size(132, 13);
            this.qIndex.TabIndex = 49;
            this.qIndex.Text = "Contraharmonic Q-index: 0";
            // 
            // RLE
            // 
            this.RLE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RLE.Location = new System.Drawing.Point(696, 94);
            this.RLE.Name = "RLE";
            this.RLE.Size = new System.Drawing.Size(36, 23);
            this.RLE.TabIndex = 50;
            this.RLE.Text = "RLE";
            this.RLE.UseVisualStyleBackColor = true;
            this.RLE.Click += new System.EventHandler(this.RLE_Click);
            // 
            // test
            // 
            this.test.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.test.AutoSize = true;
            this.test.Location = new System.Drawing.Point(576, 374);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(24, 13);
            this.test.TabIndex = 51;
            this.test.Text = "test";
            // 
            // videoPlayer
            // 
            this.videoPlayer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.videoPlayer.Location = new System.Drawing.Point(837, 43);
            this.videoPlayer.Name = "videoPlayer";
            this.videoPlayer.Size = new System.Drawing.Size(106, 23);
            this.videoPlayer.TabIndex = 52;
            this.videoPlayer.Text = "Play a video";
            this.videoPlayer.UseVisualStyleBackColor = true;
            // 
            // imgSize1
            // 
            this.imgSize1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgSize1.AutoSize = true;
            this.imgSize1.Location = new System.Drawing.Point(54, 298);
            this.imgSize1.Name = "imgSize1";
            this.imgSize1.Size = new System.Drawing.Size(62, 13);
            this.imgSize1.TabIndex = 53;
            this.imgSize1.Text = "Image Size:";
            this.imgSize1.Visible = false;
            // 
            // imgSize2
            // 
            this.imgSize2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgSize2.AutoSize = true;
            this.imgSize2.Location = new System.Drawing.Point(372, 298);
            this.imgSize2.Name = "imgSize2";
            this.imgSize2.Size = new System.Drawing.Size(62, 13);
            this.imgSize2.TabIndex = 54;
            this.imgSize2.Text = "Image Size:";
            this.imgSize2.Visible = false;
            // 
            // pause
            // 
            this.pause.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pause.Location = new System.Drawing.Point(837, 66);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(50, 23);
            this.pause.TabIndex = 57;
            this.pause.Text = "pause";
            this.pause.UseVisualStyleBackColor = true;
            // 
            // play
            // 
            this.play.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.play.Location = new System.Drawing.Point(893, 66);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(50, 23);
            this.play.TabIndex = 58;
            this.play.Text = "play";
            this.play.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(837, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 23);
            this.button1.TabIndex = 59;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(893, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 23);
            this.button2.TabIndex = 60;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Huffman
            // 
            this.Huffman.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Huffman.Location = new System.Drawing.Point(747, 94);
            this.Huffman.Name = "Huffman";
            this.Huffman.Size = new System.Drawing.Size(55, 23);
            this.Huffman.TabIndex = 61;
            this.Huffman.Text = "Huffman";
            this.Huffman.UseVisualStyleBackColor = true;
            this.Huffman.Click += new System.EventHandler(this.Huffman_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(699, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 62;
            this.label6.Text = "Image Compression";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 674);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Huffman);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.play);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.imgSize2);
            this.Controls.Add(this.imgSize1);
            this.Controls.Add(this.videoPlayer);
            this.Controls.Add(this.test);
            this.Controls.Add(this.RLE);
            this.Controls.Add(this.qIndex);
            this.Controls.Add(this.qSlider);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.imgRes);
            this.Controls.Add(this.noiseLevel);
            this.Controls.Add(this.imgDegSlider);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.imgDeg);
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
            this.Text = "Suico Image Processor";
            ((System.ComponentModel.ISupportInitialize)(this.ogImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPalette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bwSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gammaSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgDegSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qSlider)).EndInit();
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
        private System.Windows.Forms.ComboBox imgDeg;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TrackBar imgDegSlider;
        private System.Windows.Forms.Label noiseLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox imgRes;
        public System.Windows.Forms.TrackBar qSlider;
        private System.Windows.Forms.Label qIndex;
        private System.Windows.Forms.Button RLE;
        private System.Windows.Forms.Label test;
        private System.Windows.Forms.Button videoPlayer;
        private System.Windows.Forms.Label imgSize1;
        private System.Windows.Forms.Label imgSize2;
        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Huffman;
        private System.Windows.Forms.Label label6;
    }
}

