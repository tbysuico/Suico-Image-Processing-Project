using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Suico_Image_Processing_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static class Globals
        {
            public static Bitmap newImage = null;
            public static string imgAddress;

            public static Bitmap setImage
            {
                get { return newImage; }
                set { newImage = value; }
            }

            public static bool noise = false;
            public static List<Bitmap> newImages;
            public static List<Bitmap> playImages;
            public static int frameIndex = 0;
            public static bool playing;
            public static Timer timer = new Timer();
        }

        public void nullProject2ui()
        {
            Globals.noise = true;
            imgDeg.SelectedItem = null;
            Globals.noise = true;
            imgRes.SelectedItem = null;
        }

        private void open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog(); // Opens file dialog
            openFile.Filter = "(*.pcx)| *.pcx"; // File filter for .pcx files

            if (DialogResult.OK == openFile.ShowDialog())
            {
                setup("img");
                Globals.imgAddress = openFile.FileName;
                Bitmap newImage = Project1g2.ProcessImage(openFile.FileName);  // Function call for processing image of bitmap
                Globals.setImage = newImage;
                ogImage.Image = newImage;
                imageInfo.Text = Project1g2.PCXInfo(openFile.FileName);

                colorPalette.Image = Project1g2.ExtractPalette(openFile.FileName);

                histogram.Series.Clear(); // Clears histogram
                processedImage.Image = null; // Clears the processed image box
                nullProject2ui();
                Globals.noise = false;
                label1.Text = "Original Image";
                label2.Text = "Processed Image";

                Globals.newImages = null;
                Globals.playImages = null;
                Globals.playing = false;
                Globals.frameIndex = 0;
            }
        }

        //  Project 1 Guide 3
        private void redButton_Click(object sender, EventArgs e) // Function for Red Channel button
        {
            if (ogImage.Image == null && Globals.newImages == null) // Checks if there is an available image to process
            {
                MessageBox.Show("Please open a pcx file or play a video first.");
            }
            else if (Globals.newImages != null)
            {
                var redImages = new List<Bitmap>();

                foreach (var image in Globals.newImages)
                    redImages.Add(Project1g3.GetReds(image));

                Globals.playImages = redImages;
                initializeTimer();
            }
            else
            {
                histogram.Series.Clear(); // Clears histogram
                histogram.Series.Add("Pixels"); // Re-initializes Pixels series for chart
                Bitmap redChannel = Project1g3.GetReds(Globals.newImage);
                int[] intensity = Project1g3.GetHist(redChannel);

                label2.Text = "Red Channel";
                processedImage.Image = redChannel;
                for (int x = 0; x < 256; x++)
                {
                    histogram.Series["Pixels"].Points.AddXY(x, intensity[x]);
                }
            }
        }

        private void greenButton_Click(object sender, EventArgs e) // Function for Green Channel button
        {

            if (ogImage.Image == null && Globals.newImages == null) // Check
            {
                MessageBox.Show("Please open a pcx file or play a video first.");
            }
            else if (Globals.newImages != null)
            {
                var greenImages = new List<Bitmap>();

                foreach (var image in Globals.newImages)
                    greenImages.Add(Project1g3.GetGreens(image));

                Globals.playImages = greenImages;
                initializeTimer();
            }
            else
            {
                histogram.Series.Clear(); // Clears histogram
                histogram.Series.Add("Pixels"); // Re-initializes Pixels series for chart
                Bitmap greenChannel = Project1g3.GetGreens(Globals.newImage);
                int[] intensity = Project1g3.GetHist(greenChannel);

                label2.Text = "Green Channel";
                processedImage.Image = greenChannel;
                for (int x = 0; x < 256; x++)
                {
                    histogram.Series["Pixels"].Points.AddXY(x, intensity[x]);
                }
            }
        }

        private void blueButton_Click(object sender, EventArgs e) // Function for Blue Channel button
        {

            if (ogImage.Image == null && Globals.newImages == null)
            {
                MessageBox.Show("Please open a pcx file or play a video first.");
            }
            else if (Globals.newImages != null)
            {
                var blueImages = new List<Bitmap>();

                foreach (var image in Globals.newImages)
                    blueImages.Add(Project1g3.GetBlues(image));

                Globals.playImages = blueImages;
                initializeTimer();
            }
            else
            {
                histogram.Series.Clear(); // Clears histogram
                histogram.Series.Add("Pixels"); // Re-initializes Pixels series for chart
                Bitmap blueChannel = Project1g3.GetReds(Globals.newImage);
                int[] intensity = Project1g3.GetHist(blueChannel);

                label2.Text = "Blue Channel";
                processedImage.Image = blueChannel;
                for (int x = 0; x < 256; x++)
                {
                    histogram.Series["Pixels"].Points.AddXY(x, intensity[x]);
                }
            }
        }

        //  Project 1 Guide 4
        private void grayButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null && Globals.newImages == null)
            {
                MessageBox.Show("Please open a pcx file or play a video first.");
            }
            else if (Globals.newImages != null)
            {
                var grayImages = new List<Bitmap>();

                foreach (var image in Globals.newImages)
                    grayImages.Add(Project1g4.GetGrayscale(image));

                Globals.playImages = grayImages;
                initializeTimer();
            }
            else
            {
                histogram.Series.Clear(); // Clears histogram
                histogram.Series.Add("Pixels"); // Re-initializes Pixels series for chart
                Bitmap gray = Project1g4.GetGrayscale(Globals.newImage);
                int[] intensity = Project1g3.GetHist(gray) ;

                for (int x = 0; x < 256; x++)
                {
                    histogram.Series["Pixels"].Points.AddXY(x, intensity[x]);
                }

                processedImage.Image = gray;
                label2.Text = "Grayscale";
            }
        }

        private void negativeButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null && Globals.newImages == null)
            {
                MessageBox.Show("Please open a pcx file or play a video first.");
            }
            else if (Globals.newImages != null)
            {
                var negImages = new List<Bitmap>();

                foreach (var image in Globals.newImages)
                    negImages.Add(Project1g4.GetNegative(image));

                Globals.playImages = negImages;
                initializeTimer();
            }
            else
            {
                histogram.Series.Clear();
                processedImage.Image = Project1g4.GetNegative(Globals.newImage);
                label2.Text = "Negative";
            }
        }

        private void bwButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null && Globals.newImages == null)
            {
                MessageBox.Show("Please open a pcx file or play a video first.");
            }
            else if (Globals.newImages != null)
            {
                var bwImages = new List<Bitmap>();

                foreach (var image in Globals.newImages)
                    bwImages.Add(Project1g4.GetBW(image, bwSlider.Value));

                Globals.playImages = bwImages;
                initializeTimer();
            }
            else
            {
                histogram.Series.Clear();
                processedImage.Image = Project1g4.GetBW(Globals.newImage, bwSlider.Value);
                label2.Text = "Black/White Thresholding";
            }
        }

        private void bwSlider_Scroll(object sender, EventArgs e)
        {
            bwLabel.Text = "B/W Threshold: "+bwSlider.Value.ToString();
        }

        private void gammaSlider_Scroll(object sender, EventArgs e)
        {
            gammaLabel.Text = "Gamma Index: "+gammaSlider.Value.ToString();
        }

        private void gammaButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null && Globals.newImages == null)
            {
                MessageBox.Show("Please open a pcx file or play a video first.");
            }
            else if (Globals.newImages != null)
            {
                var gammaImages = new List<Bitmap>();

                foreach (var image in Globals.newImages)
                    gammaImages.Add(Project1g4.GetGamma(image, gammaSlider.Value));

                Globals.playImages = gammaImages;
                initializeTimer();
            }
            else
            {
                histogram.Series.Clear();
                label2.Text = "Gamma Transformation";
                processedImage.Image = Project1g4.GetGamma(Globals.newImage, gammaSlider.Value);
            }
        }
        
        //  Project 1 Guide 5
        private void avgButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null && Globals.newImages == null)
            {
                MessageBox.Show("Please open a pcx file or play a video first.");
            }
            else if (Globals.newImages != null)
            {
                var avgImages = new List<Bitmap>();

                foreach (var image in Globals.newImages)
                    avgImages.Add(Project1g5.GetAverage(image));

                Globals.playImages = avgImages;
                initializeTimer();
            }
            else
            {
                histogram.Series.Clear();
                label2.Text = "Averaged";
                processedImage.Image = Project1g5.GetAverage(Globals.newImage);
            }
        }

        private void medianButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null && Globals.newImages == null)
            {
                MessageBox.Show("Please open a pcx file or play a video first.");
            }
            else if (Globals.newImages != null)
            {
                var medianizedImages = new List<Bitmap>();

                foreach (var image in Globals.newImages)
                    medianizedImages.Add(Project1g5.GetMedian(image));

                Globals.playImages = medianizedImages;
                initializeTimer();
            }
            else
            {
                histogram.Series.Clear();
                label2.Text = "Median";
                processedImage.Image = Project1g5.GetMedian(Globals.newImage);
            }
        }

        private void highpassButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null && Globals.newImages == null)
            {
                MessageBox.Show("Please open a pcx file or play a video first.");
            }
            else if (Globals.newImages != null)
            {
                var highpassedImages = new List<Bitmap>();

                foreach (var image in Globals.newImages)
                    highpassedImages.Add(Project1g5.GetHighpass(image));

                Globals.playImages = highpassedImages;
                initializeTimer();
            }
            else
            {
                histogram.Series.Clear();
                label2.Text = "Highpass";
                processedImage.Image = Project1g5.GetHighpass(Globals.newImage);
            }
        }

        private void unsharpenButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null && Globals.newImages == null)
            {
                MessageBox.Show("Please open a pcx file or play a video first.");
            }
            else if (Globals.newImages != null)
            {
                var unsharpenedImages = new List<Bitmap>();

                foreach (var image in Globals.newImages)
                    unsharpenedImages.Add(Project1g5.Unsharpen(image));

                Globals.playImages = unsharpenedImages;
                initializeTimer();
            }
            else
            {
                histogram.Series.Clear();
                label2.Text = "Unsharpened";
                processedImage.Image = Project1g5.Unsharpen(Globals.newImage);
            }
        }

        private void highboostButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null && Globals.newImages == null)
            {
                MessageBox.Show("Please open a pcx file or play a video first.");
            }
            else if (Globals.newImages != null)
            {
                var highboostedImages = new List<Bitmap>();

                foreach (var image in Globals.newImages)
                    highboostedImages.Add(Project1g5.GetHighboost(image));

                Globals.playImages = highboostedImages;
                initializeTimer();
            }
            else
            {
                histogram.Series.Clear();
                label2.Text = "Highboost";
                processedImage.Image = Project1g5.GetHighboost(Globals.newImage);
            }
        }

        private void gradientXButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null && Globals.newImages == null)
            {
                MessageBox.Show("Please open a pcx file or play a video first.");
            }
            else if (Globals.newImages != null)
            {
                var gradientXImages = new List<Bitmap>();

                foreach (var image in Globals.newImages)
                    gradientXImages.Add(Project1g5.GetGradientX(image));

                Globals.playImages = gradientXImages;
                initializeTimer();
            }
            else
            {
                histogram.Series.Clear();
                label2.Text = "Gradient Sobel X";
                processedImage.Image = Project1g5.GetGradientX(Globals.newImage);
            }
        }

        private void gradientYButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null && Globals.newImages == null)
            {
                MessageBox.Show("Please open a pcx file or play a video first.");
            }
            else if (Globals.newImages != null)
            {
                var gradientYImages = new List<Bitmap>();

                foreach (var image in Globals.newImages)
                    gradientYImages.Add(Project1g5.GetGradientY(image));

                Globals.playImages = gradientYImages;
                initializeTimer();
            }
            else
            {
                histogram.Series.Clear();
                label2.Text = "Gradient Sobel Y";
                processedImage.Image = Project1g5.GetGradientY(Globals.newImage);
            }
        }

        private void gradientXYButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null && Globals.newImages == null)
            {
                MessageBox.Show("Please open a pcx file or play a video first.");
            }
            else if (Globals.newImages != null)
            {
                var gradientXYImages = new List<Bitmap>();

                foreach (var image in Globals.newImages)
                    gradientXYImages.Add(Project1g5.GetGradientXY(image));

                Globals.playImages = gradientXYImages;
                initializeTimer();
            }
            else
            {
                histogram.Series.Clear();
                label2.Text = "Gradient Sobel XY";
                processedImage.Image = Project1g5.GetGradientXY(Globals.newImage);
            }
        }

        // Project 2 Guides 1 & 2
        private void imgDegSlider_Scroll(object sender, EventArgs e)
        {
            if (imgDeg.Text == "Salt and Pepper Noise")
            {
                noiseLevel.Location = new Point(843, 191);
                noiseLevel.Text = "Noise Probability: " + imgDegSlider.Value.ToString() + "%";
            }
            else if (imgDeg.Text == "Gaussian Noise")
            {
                noiseLevel.Location = new Point(834, 191);
                noiseLevel.Text = "Standard Deviation: " + (5 * imgDegSlider.Value).ToString();
            }
            else if (imgDeg.Text == "Rayleigh Noise")
            {
                noiseLevel.Location = new Point(840, 191);
                noiseLevel.Text = "Scale Parameter: " + (10 * imgDegSlider.Value).ToString();
            }
            else
                noiseLevel.Text = imgDegSlider.Value.ToString();
        }

        private void imgDeg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ogImage.Image != null)
                project2Reset();

            if (Globals.noise)
            {
                Globals.noise = false;
                return;
            }

            histogram.Series.Clear(); // Clears histogram
            imgRes.SelectedItem = null;
            label1.Text = "Original Image";
            ogImage.Image = Globals.newImage;

            if (ogImage.Image == null && Globals.newImages == null)
            {
                MessageBox.Show("Please open a pcx file or play a video first.");
                Globals.noise = true;
                imgDeg.SelectedItem = null;
            }
            else if (Globals.newImages != null)
            {
                var degImages = new List<Bitmap>();

                foreach (var image in Globals.newImages)
                    degImages.Add(Project2.DegradeImage(image,imgDegSlider.Value, imgDeg.Text));

                vidLabel.Text = "Degraded with " + imgDeg.Text;
                Globals.playImages = degImages;
                initializeTimer();
            }
            else
            {
                histogram.Series.Add("Pixels"); // Re-initializes Pixels series for chart
                Bitmap result = Project2.DegradeImage(Globals.newImage, imgDegSlider.Value, imgDeg.Text);
                int[] intensity = Project1g3.GetHist(result);
                for (int x = 0; x < 256; x++)
                {
                    histogram.Series["Pixels"].Points.AddXY(x, intensity[x]);
                }
                processedImage.Image = result;
            }

            if(imgDeg.Text == "Salt and Pepper Noise")
            {
                label2.Text = "Salt and Pepper Noise";
                noiseLevel.Location = new Point(843, 191);
                noiseLevel.Text = "Noise Probability: " + imgDegSlider.Value.ToString() + "%";
            }
            else if (imgDeg.Text == "Gaussian Noise")
            {
                label2.Text = "Gaussian Noise";
                noiseLevel.Location = new Point(834, 191);
                noiseLevel.Text = "Standard Deviation: " + (5*imgDegSlider.Value).ToString();
            }
            else if (imgDeg.Text == "Rayleigh Noise")
            {
                label2.Text = "Rayleigh Noise";
                noiseLevel.Location = new Point(840, 191);
                noiseLevel.Text = "Scale Parameter: " + (10 * imgDegSlider.Value).ToString();
            }
        }

        private void qSlider_Scroll(object sender, EventArgs e)
        {
            qIndex.Text = "Contraharmonic Q-index: "+qSlider.Value.ToString();
        }

        private void imgRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Globals.noise)
            {
                Globals.noise = false;
                return;
            }

            histogram.Series.Clear(); // Clears histogram
            Bitmap restored = (Bitmap)ogImage.Image;


            if (label1.Text.Contains("Degraded"))
            {
                project2Reset();

                if ((imgDeg.Text == "Gaussian Noise" || imgDeg.Text == "Salt and Pepper Noise") && qSlider.Value < 0 && imgRes.Text == "Contraharmonic")
                {
                    MessageBox.Show("Q < 0, unable to restore black noise.");
                    return;
                }
                else if ((imgDeg.Text == "Gaussian Noise" || imgDeg.Text == "Salt and Pepper Noise") && qSlider.Value > 0 && imgRes.Text == "Contraharmonic")
                {
                    MessageBox.Show("Q > 0, unable to restore white noise.");
                    return;
                }

                restored = Project2.RestoreImage((Bitmap)ogImage.Image, qSlider.Value, imgRes.Text);
                processedImage.Image = restored;
            }
            else if (vidLabel.Text.Contains("Degraded"))
            {
                if ((imgDeg.Text == "Gaussian Noise" || imgDeg.Text == "Salt and Pepper Noise") && qSlider.Value < 0 && imgRes.Text == "Contraharmonic")
                {
                    MessageBox.Show("Q < 0, unable to restore black noise.");
                    return;
                }
                else if ((imgDeg.Text == "Gaussian Noise" || imgDeg.Text == "Salt and Pepper Noise") && qSlider.Value > 0 && imgRes.Text == "Contraharmonic")
                {
                    MessageBox.Show("Q > 0, unable to restore white noise.");
                    return;
                }

                var resImages = new List<Bitmap>();
                foreach (var image in Globals.playImages)
                    resImages.Add(Project2.RestoreImage(image, qSlider.Value, imgRes.Text));

                Globals.playImages = resImages;
                vidLabel.Text = "Restored";
                initializeTimer();
            }
            else if (label2.Text.Contains("Noise"))
            {
                project2Reset();

                if (imgDeg.Text == "Pepper Noise" && qSlider.Value < 0)
                {
                    MessageBox.Show("Q < 0, unable to restore pepper noise.");
                    return;
                }
                else if (imgDeg.Text == "Salt Noise" && qSlider.Value > 0)
                {
                    MessageBox.Show("Q > 0, unable to restore salt noise.");
                    return;
                }

                label1.Text = "Degraded Image";
                ogImage.Image = processedImage.Image;
                restored = Project2.RestoreImage((Bitmap)ogImage.Image, qSlider.Value, imgRes.Text);
                processedImage.Image = restored;
                label2.Text = "Restored Image";
            }
            else
            {
                MessageBox.Show("Please open and degrade a pcx file or a video first.");
                Globals.noise = true;
                imgRes.SelectedItem = null;
            }
        }
        
        private void RLE_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null)
            {
                MessageBox.Show("Please open a pcx file first.");
                Globals.noise = true;
                imgDeg.SelectedItem = null;
            }
            else
            {
                setup("img");
                string inputFilePath = Globals.imgAddress;
                
                // Read PCX file
                byte[] pcxData = File.ReadAllBytes(inputFilePath);
                string pcxByteString = Project2.ByteArrayToBinaryString(pcxData);
                imgSize1.Text = "Image size (in binary): " + pcxByteString.Length.ToString();
                imgSize1.Visible = true;

                // Perform Run-Length Encoding
                byte[] RLEData = Project2.RunLengthEncode(Globals.imgAddress);
                processedImage.Image = Project2.RunLengthDecode(RLEData);
                label2.Text = "Processed Image";
                imgSize2.Text = "Image Size: " + RLEData.Length;
                imgSize2.Visible = true;

                float compressionRate = (float)pcxByteString.Length / RLEData.Length;
                MessageBox.Show("Compression Rate: " + compressionRate);
            }
        }

        private void Huffman_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null)
            {
                MessageBox.Show("Please open a pcx file first.");
                Globals.noise = true;
                imgDeg.SelectedItem = null;
            }
            else
            {
                setup("img");
                string inputFilePath = Globals.imgAddress;

                // Read PCX file
                byte[] pcxData = File.ReadAllBytes(inputFilePath);
                string pcxByteString = Project2.ByteArrayToBinaryString(pcxData);
                imgSize1.Text = "Image size (in binary): " + pcxByteString.Length.ToString();
                imgSize1.Visible = true;

                // Perform Huffman Encoding
                Project2.HuffmanTree tree = new Project2.HuffmanTree();
                Dictionary<byte?, int> frequencies = Project2.getFrequencies(pcxData);
                Project2.HuffmanNode huffmanTree = tree.BuildHuffmanTree(frequencies);
                Dictionary<byte?, string> huffmanCode = tree.GetHuffmanCode(huffmanTree);
                string encodedData = tree.EncodeImage(pcxData, huffmanCode);
                processedImage.Image = Project2.HuffmanDecode(huffmanTree, encodedData);
                label2.Text = "Processed Image";
                imgSize2.Text = "Image Size : " + encodedData.Length.ToString();
                imgSize2.Visible = true;

                float compressionRate = (float)pcxByteString.Length / encodedData.Length;
                MessageBox.Show("Compression Rate: " + compressionRate.ToString());
            }
        }

        private void project2Reset()
        {
            imgSize1.Visible = false;
            imgSize2.Visible = false;
        }

        private void setup(string check)
        {
            if (check == "img")
            {
                label1.Visible = true;
                ogImage.Visible = true;
                label2.Visible = true;
                processedImage.Visible = true;
                histogram.Visible = true;
                imageInfo.Visible = true;
                colorPalette.Visible = true;

                vidLabel.Visible = false;
                videoBox.Visible = false;
            }
            else if (check == "vid")
            {
                label1.Visible = false;
                ogImage.Visible = false;
                imgSize1.Visible = false;
                label2.Visible = false;
                processedImage.Visible = false;
                imgSize2.Visible = false;
                histogram.Visible = false;
                imageInfo.Visible = false;
                colorPalette.Visible = false;

                vidLabel.Visible = false;
                videoBox.Visible = true;
            }
        }

        private void videoPlayer_Click(object sender, EventArgs e)
        {
            setup("vid");
            string folderPath = @"C:\Acad Files\CMSC 162 Cinmayii\PCX Files\motion";
            Globals.playing = true;
            var images = new List<Bitmap>();
            // Check if the folder exists
            if (Directory.Exists(folderPath))
            {
                // Get all .tiff files in the folder
                var imagePaths = new List<string>(Directory.GetFiles(folderPath, "*.tiff"));
                foreach (var filePath in imagePaths)
                {
                    Bitmap img = new Bitmap(filePath);
                    images.Add(img);
                }
                Globals.newImages = images;
                Globals.playImages = images;
                if (Globals.newImages.Count == 0)
                    Console.WriteLine("No .tiff files found in the folder.");
            }
            else
            {
                Console.WriteLine("The specified folder does not exist.");
            }

            initializeTimer();
        }

        public void initializeTimer()
        {
            if(!Globals.timer.Enabled)
                Globals.timer.Tick += timerTick;
            Globals.timer.Interval = 500;
            Globals.timer.Start();
        }

        public void timerTick(object sender, EventArgs e)
        {
            if (Globals.playing && Globals.playImages.Count > 0)
            {
                videoBox.Image = Globals.playImages[Globals.frameIndex];
                Globals.frameIndex = (Globals.frameIndex + 1) % Globals.playImages.Count;
            }
        }

        private void pause_Click(object sender, EventArgs e)
        {
            if(Globals.playImages == null)
            {
                MessageBox.Show("Please open the video first.");
            }
            else
            {
                if (Globals.playing)
                    Globals.playing = !Globals.playing;
            }
        }

        private void play_Click(object sender, EventArgs e)
        {
            if (Globals.playImages == null)
            {
                MessageBox.Show("Please open the video first.");
            }
            else
            {
                if (!Globals.playing)
                    Globals.playing = !Globals.playing;
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (Globals.playImages == null)
            {
                MessageBox.Show("Please open the video first.");
            }
            else
            {
                if (Globals.playing)
                {
                    Globals.playing = !Globals.playing;
                    Globals.frameIndex--;
                }
                Globals.frameIndex--;
                if (Globals.frameIndex < 0)
                    Globals.frameIndex = Globals.playImages.Count - 1;
                videoBox.Image = Globals.playImages[Globals.frameIndex];
            }
        }

        private void forward_Click(object sender, EventArgs e)
        {
            if (Globals.playImages == null)
            {
                MessageBox.Show("Please open the video first.");
            }
            else
            {
                if (Globals.playing)
                {
                    Globals.playing = !Globals.playing;
                }
                Globals.frameIndex++;
                if (Globals.frameIndex == Globals.playImages.Count)
                    Globals.frameIndex = 0;
                videoBox.Image = Globals.playImages[Globals.frameIndex];
            }
        }

        private void opticalFlow_Click(object sender, EventArgs e)
        {
            if (Globals.newImages == null)
            {
                MessageBox.Show("Please open the video first.");
            }
            else
            {
                setup("vid");
                vidLabel.Visible = true;
                string folderPath = @"C:\Acad Files\CMSC 162 Cinmayii\PCX Files\motion";
                var imagePaths = new List<string>(Directory.GetFiles(folderPath, "*.tiff"));
                Globals.playImages = FinalProject.LucasKanade(imagePaths);
                Globals.frameIndex = 0;
                initializeTimer();
            }
        }
    }
}
