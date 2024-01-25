using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

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
            }
        }

        //  Project 1 Guide 3
        private void redButton_Click(object sender, EventArgs e) // Function for Red Channel button
        {
            if (ogImage.Image == null) // Checks if there is an available image to process
            {
                MessageBox.Show("Please open a pcx file first.");
            }
            else
            {
                project1Reset();
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

            if (ogImage.Image == null) // Check
            {
                MessageBox.Show("Please open a pcx file first.");
            }
            else
            {
                project1Reset();
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

            if (ogImage.Image == null)
            {
                MessageBox.Show("Please open a pcx file first.");
            }
            else
            {
                project1Reset();
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
            if (ogImage.Image == null)
            {
                MessageBox.Show("Please open a pcx file first.");
            }
            else
            {
                project1Reset();
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
            if (ogImage.Image == null)
            {
                MessageBox.Show("Please open a pcx file first.");
            }
            else
            {
                project1Reset();
                histogram.Series.Clear();
                processedImage.Image = Project1g4.GetNegative(Globals.newImage);
                label2.Text = "Negative";
            }
        }

        private void bwButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null)
            {
                MessageBox.Show("Please open a pcx file first.");
            }
            else
            {
                project1Reset();
                histogram.Series.Clear();
                processedImage.Image = Project1g4.GetBW(Globals.newImage,bwSlider.Value);
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
            if (ogImage.Image == null)
            {
                MessageBox.Show("Please open a pcx file first.");
            }
            else
            {
                project1Reset();
                histogram.Series.Clear();
                label2.Text = "Gamma Transformation";
                processedImage.Image = Project1g4.GetGamma(Globals.newImage, gammaSlider.Value);
            }
        }
        
        //  Project 1 Guide 5
        private void avgButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null)
            {
                MessageBox.Show("Please open a pcx file first.");
            }
            else
            {
                project1Reset();
                histogram.Series.Clear();
                label2.Text = "Averaged";
                processedImage.Image = Project1g5.GetAverage(Globals.newImage);
            }
        }

        private void medianButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null)
            {
                MessageBox.Show("Please open a pcx file first.");
            }
            else
            {
                project1Reset();
                histogram.Series.Clear();
                label2.Text = "Median";
                processedImage.Image = Project1g5.GetMedian(Globals.newImage);
            }
        }

        private void highpassButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null)
            {
                MessageBox.Show("Please open a pcx file first.");
            }
            else
            {
                project1Reset();
                histogram.Series.Clear();
                label2.Text = "Highpass";
                processedImage.Image = Project1g5.GetHighpass(Globals.newImage);
            }
        }

        private void unsharpenButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null)
            {
                string errormessage = "Please open a pcx file first.";
                MessageBox.Show(errormessage);
            }
            else
            {
                project1Reset();
                histogram.Series.Clear();
                label2.Text = "Unsharpened";
                processedImage.Image = Project1g5.Unsharpen(Globals.newImage);
            }
        }

        private void highboostButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null)
            {
                string errormessage = "Please open a pcx file first.";
                MessageBox.Show(errormessage);
            }
            else
            {
                project1Reset();
                histogram.Series.Clear();
                label2.Text = "Highboost";
                processedImage.Image = Project1g5.GetHighboost(Globals.newImage);
            }
        }

        private void gradientXButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null)
            {
                string errormessage = "Please open a pcx file first.";
                MessageBox.Show(errormessage);
            }
            else
            {
                project1Reset();
                histogram.Series.Clear();
                label2.Text = "Gradient Sobel X";
                processedImage.Image = Project1g5.GetGradientX(Globals.newImage);
            }
        }

        private void gradientYButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null)
            {
                string errormessage = "Please open a pcx file first.";
                MessageBox.Show(errormessage);
            }
            else
            {
                project1Reset();
                histogram.Series.Clear();
                label2.Text = "Gradient Sobel Y";
                processedImage.Image = Project1g5.GetGradientY(Globals.newImage);
            }
        }

        private void gradientXYButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null)
            {
                string errormessage = "Please open a pcx file first.";
                MessageBox.Show(errormessage);
            }
            else
            {
                project1Reset();
                histogram.Series.Clear();
                label2.Text = "Gradient Sobel XY";
                processedImage.Image = Project1g5.GetGradientXY(Globals.newImage);
            }
        }

        // Project 2 Guides 1 & 2
        private void imgDegSlider_Scroll(object sender, EventArgs e)
        {
            noiseLevel.Text = "Noise Level: "+imgDegSlider.Value.ToString()+"%";
        }

        private void imgDeg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Globals.noise)
            {
                Globals.noise = false;
                return;
            }

            imgRes.SelectedItem = null;
            label1.Text = "Original Image";
            ogImage.Image = Globals.newImage;

            if (ogImage.Image == null)
            {
                MessageBox.Show("Please open a pcx file first.");
                Globals.noise = true;
                imgDeg.SelectedItem = null;
            }
            else if (imgDeg.Text == "Salt Noise")
            {
                Bitmap result = Project2.DegradeImage(Globals.newImage, imgDegSlider.Value, imgDeg.Text);
                processedImage.Image = result;
                label2.Text = "Salt Noise";
            }
            else if (imgDeg.Text == "Pepper Noise")
            {
                Bitmap result = Project2.DegradeImage(Globals.newImage, imgDegSlider.Value, imgDeg.Text);
                processedImage.Image = result;
                label2.Text = "Pepper Noise";
            }
            else if (imgDeg.Text == "Salt and Pepper Noise")
            {
                Bitmap result = Project2.DegradeImage(Globals.newImage, imgDegSlider.Value, imgDeg.Text);
                processedImage.Image = result;
                label2.Text = "Salt and Pepper Noise";
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
                if ((imgDeg.Text == "Pepper Noise" || imgDeg.Text == "Salt and Pepper Noise") && qSlider.Value < 0 && imgRes.Text == "Contraharmonic")
                {
                    MessageBox.Show("Q < 0, unable to restore pepper noise.");
                    return;
                }
                else if ((imgDeg.Text == "Salt Noise" || imgDeg.Text == "Salt and Pepper Noise") && qSlider.Value > 0 && imgRes.Text == "Contraharmonic")
                {
                    MessageBox.Show("Q > 0, unable to restore salt noise.");
                    return;
                }

                restored = Project2.RestoreImage((Bitmap)ogImage.Image, qSlider.Value, imgRes.Text);
                processedImage.Image = restored;
            }
            else if (label2.Text.Contains("Noise"))
            {
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
                MessageBox.Show("Please open and degrade a pcx file first.");
                Globals.noise = true;
                imgRes.SelectedItem = null;
            }
        }

        private void project1Reset()
        {
            label1.Text = "Original Image";
            ogImage.Image = Globals.newImage;
            nullProject2ui();
            Globals.noise = false;
            histogram.Series.Clear(); // Clears histogram
            histogram.Series.Add("Pixels"); // Re-initializes Pixels series for chart
            imgSize1.Visible = false;
            imgSize2.Visible = false;
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
    }
}
