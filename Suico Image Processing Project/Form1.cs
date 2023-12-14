using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Suico_Image_Processing_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog(); // Opens file dialog
            openFile.Filter = "(*.pcx)| *.pcx"; // File filter for .pcx files
            if (DialogResult.OK == openFile.ShowDialog())
            {
                processImage(openFile.FileName);  // Function call for processing image of bitmap
            }
            processedImage.Image = null; // Clears the processed image box
            histogram.Series.Clear(); // Clears histogram
            histogram.Series.Add("Pixels"); // Re-initializes Pixels series for chart
        }

        public void processImage(string bmp) // Function for processing data of bitmap
        {
            int byteReader = 0; // Initialization of bytereader
            List<int> colorpalette = new List<int>(); //Initialization of colorpalette bytes
            Stream bmpByte = File.OpenRead(bmp); // Stream class for sequence of bytes from System IO
            string nl = Environment.NewLine; // Initialization of newline character
            byteReader = bmpByte.ReadByte(); // Byte reader reads first byte

            //Output the info related to the PCX file
            string info = "Manufacturer: Zshoft.pcx (" + byteReader + ")" + nl;
            byteReader = bmpByte.ReadByte();
            info += "Version: " + byteReader + nl;
            byteReader = bmpByte.ReadByte();
            info += "Encoding: " + byteReader + nl;
            byteReader = bmpByte.ReadByte();
            info += "Bits per Pixel: " + byteReader + nl;
            info += "Image Dimensions: ";
            for (int x = 0; x < 4; x++) // Cycle through the relevant bytes for image dimensions
            {
                byteReader = bmpByte.ReadByte() + bmpByte.ReadByte();
                if (x <= 2)
                {
                    info += byteReader + " ";
                }
                else
                {
                    info += byteReader + nl;
                }
            }

            byteReader = bmpByte.ReadByte() + bmpByte.ReadByte();
            info += "HDPI: " + byteReader + nl;
            byteReader = bmpByte.ReadByte() + bmpByte.ReadByte();
            info += "VDPI: " + byteReader + nl;

            for (int x = 0; x < 48; x++) // Cycle through the relevant bytes of color palette
            {
                byteReader = bmpByte.ReadByte();
                colorpalette.Add(byteReader);
            }
            byteReader = bmpByte.ReadByte(); // Reserved byte

            byteReader = bmpByte.ReadByte();
            info += "Number of Color Planes: " + byteReader + nl;
            byteReader = bmpByte.ReadByte() + bmpByte.ReadByte() << 8;
            info += "Bytes per Line: " + byteReader + nl;
            byteReader = bmpByte.ReadByte() + bmpByte.ReadByte();
            info += "Palette Information: " + byteReader + nl;
            byteReader = bmpByte.ReadByte() + bmpByte.ReadByte();
            info += "Horizontal Screen Size: " + byteReader + nl;
            byteReader = bmpByte.ReadByte() + bmpByte.ReadByte();
            info += "Vertical Screen Size:" + byteReader + nl + nl +
                "Color Palette: ";

            imageInfo.Text = info;

            byte[] readPCX = File.ReadAllBytes(bmp); // Seeking to the end of fie
            Bitmap temp_colorPalette = new Bitmap(colorPalette.Width, colorPalette.Height); // Bitmap to hold the colors of color palette


            List<Color> colors = new List<Color>(); // List of colors from image

            // Initialize coordinates of rectangle to fill
            int imgX = 0;
            int imgY = 0;

            for (int x = readPCX.Length - 768; x < readPCX.Length; x += 3) // Count back 768 to take colors (769 results in out of bounds error)
            {
                colors.Add(Color.FromArgb(readPCX[x], readPCX[x + 1], readPCX[x + 2]));
            }

            using (Graphics G = Graphics.FromImage(temp_colorPalette)) // Using Graphics class to create a canvas for color palette
            {
                foreach (Color pixel in colors)
                {
                    try
                    {
                        SolidBrush SB = new SolidBrush(pixel); // Create instance of brush to be used to paint color
                        G.FillRectangle(SB, imgX, imgY, 5, 5);
                        if (imgX == colorPalette.Width - 5)
                        {
                            imgX = 0;
                            imgY += 5;
                        }
                        else
                        {
                            imgX += 5;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception: " + ex.Message);
                    }
                }
            }
            colorPalette.Image = temp_colorPalette;

            // Initialize vars for constructing image
            Bitmap temp_image = new Bitmap(256, 256);
            Color[] image_colors = new Color[256 * 256];
            List<byte> pixels = new List<byte>();
            int index = 128;
            byte byteDuplicator = 0;
            byte prefix = 0;

            while (index < readPCX.Length) // Iterating through relevant bytes for RLE
            {
                byte reader = readPCX[index++]; // Read next byte in sequence

                if ((reader & 0xC0) == 0xC0) // Check if 2-bit
                {
                    byteDuplicator = readPCX[index++]; // Duplicates byte
                    prefix = (byte)(reader & 0x3F); // Gets the first 2 relevant bytes
                }
                else // Check if 1-bit
                {
                    byteDuplicator = reader; // Duplicates byte
                    prefix = 1;
                }
                for (int x = 0; x < prefix; x++)
                {
                    pixels.Add(byteDuplicator); // Adds byte to pixel list
                }
            }

            for(int i = 0; i < 256 * 256; i++)
            {
                image_colors[i] = colors[pixels[i]]; // Setting each color for each pixel in image
                int y = i / 256; // y-coordinate
                int x = i - (256 * y); // x-coordinate
                temp_image.SetPixel(x, y, image_colors[i]); // Constructing image using acquired variables for RLE
            }

            ogImage.Image = temp_image;
        }

        private void redButton_Click(object sender, EventArgs e) // Function for Red Channel button
        {
            histogram.Series.Clear(); // Clears histogram
            histogram.Series.Add("Pixels"); // Re-initializes Pixels series for chart

            if (ogImage.Image == null) // Checks if there is an available image to process
            {
                string errorMessage = "Please open a pcx file first.";
                MessageBox.Show(errorMessage);
            }
            else
            {
                Bitmap temp_image = (Bitmap)ogImage.Image;
                Bitmap redChannel = new Bitmap(temp_image);
                int[] intensity = new int[256];

                for (int x = 0; x < temp_image.Width; x++) // Iterates through all pixels of the image
                {
                    for (int y = 0; y < temp_image.Height; y++)
                    {
                        Color pixel = temp_image.GetPixel(x, y); // Takes the color of the pixel at the xth, yth coordinate

                        // Takes the relevant values of the pixel
                        int a = pixel.A;
                        int r = pixel.R;
                        intensity[r]++;

                        redChannel.SetPixel(x, y, Color.FromArgb(a, r, 0, 0)); // Sets all other values to 0 except the relevant color
                    }
                }
                processedImage.Image = redChannel;
                label2.Text = "Red Channel";

                for (int x = 0; x < 256; x++)
                {
                    histogram.Series["Pixels"].Points.AddXY(x, intensity[x]);
                }
            }
        }

        private void greenButton_Click(object sender, EventArgs e) // Function for Green Channel button
        {
            histogram.Series.Clear(); // Clears histogram
            histogram.Series.Add("Pixels"); // Re-initializes Pixels series for chart

            if (ogImage.Image == null) // Check
            {
                string errorMessage = "Please open a pcx file first.";
                MessageBox.Show(errorMessage);
            }
            else
            {
                Bitmap temp_image = (Bitmap)ogImage.Image;
                Bitmap greenChannel = new Bitmap(temp_image);
                int[] intensity = new int[256];

                for (int x = 0; x < temp_image.Width; x++)
                {
                    for (int y = 0; y < temp_image.Height; y++)
                    {
                        Color pixel = temp_image.GetPixel(x, y);

                        int a = pixel.A;
                        int g = pixel.G;
                        intensity[g]++;


                        greenChannel.SetPixel(x, y, Color.FromArgb(a, 0, g, 0));
                    }
                }
                processedImage.Image = greenChannel;
                label2.Text = "Green Channel";

                for (int x = 0; x < 256; x++)
                {
                    histogram.Series["Pixels"].Points.AddXY(x, intensity[x]);
                }
            }
        }

        private void blueButton_Click(object sender, EventArgs e) // Function for Blue Channel button
        {
            histogram.Series.Clear(); // Clears histogram
            histogram.Series.Add("Pixels"); // Re-initializes Pixels series for chart

            if (ogImage.Image == null)
            {
                string errorMessage = "Please open a pcx file first.";
                MessageBox.Show(errorMessage);
            }
            else
            {
                Bitmap temp_image = (Bitmap)ogImage.Image;
                Bitmap blueChannel = new Bitmap(temp_image);
                int[] intensity = new int[256];

                for (int x = 0; x < temp_image.Width; x++)
                {
                    for (int y = 0; y < temp_image.Height; y++)
                    {
                        Color pixel = temp_image.GetPixel(x, y);

                        int a = pixel.A;
                        int b = pixel.B;
                        intensity[b]++;


                        blueChannel.SetPixel(x, y, Color.FromArgb(a, 0, 0, b));
                    }
                }
                processedImage.Image = blueChannel;
                label2.Text = "Blue Channel";

                for (int x = 0; x < 256; x++)
                {
                    histogram.Series["Pixels"].Points.AddXY(x, intensity[x]);
                }
            }
        }

        private void grayButton_Click(object sender, EventArgs e)
        {
            histogram.Series.Clear(); // Clears histogram
            histogram.Series.Add("Pixels"); // Re-initializes Pixels series for chart
            if (ogImage.Image == null)
            {
                string errorMessage = "Please open a pcx file first.";
                MessageBox.Show(errorMessage);
            }
            else
            {
                Bitmap temp_image = (Bitmap)ogImage.Image;
                Bitmap grayscale = new Bitmap(temp_image);
                int[] intensity = new int[256];

                for (int x = 0; x < temp_image.Width; x++)
                {
                    for (int y = 0; y < temp_image.Height; y++)
                    {
                        Color pixel = temp_image.GetPixel(x, y);

                        int a = pixel.A;
                        int r = pixel.R;
                        int g = pixel.G;
                        int b = pixel.B;
                        int s = (r + g + b) / 3;

                        intensity[s]++;

                        grayscale.SetPixel(x, y, Color.FromArgb(a, s, s, s));
                    }
                }
                processedImage.Image = grayscale;
                label2.Text = "Grayscale";

                for (int x = 0; x < 256; x++)
                {
                    histogram.Series["Pixels"].Points.AddXY(x, intensity[x]);
                }
            }
        }

        private void negativeButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null)
            {
                string errorMessage = "Please open a pcx file first.";
                MessageBox.Show(errorMessage);
            }
            else
            {
                Bitmap temp_image = (Bitmap)ogImage.Image;
                Bitmap negative = new Bitmap(temp_image);
                int[] intensity = new int[256];
                histogram.Series.Clear();

                for (int x = 0; x < temp_image.Width; x++)
                {
                    for (int y = 0; y < temp_image.Height; y++)
                    {
                        Color pixel = temp_image.GetPixel(x, y);

                        int a = pixel.A;
                        int r = 255 - pixel.R;
                        int g = 255 - pixel.G;
                        int b = 255 - pixel.B;


                        negative.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    }
                }
                processedImage.Image = negative;
                label2.Text = "Negative";
            }
        }

        private void bwButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null)
            {
                string errorMessage = "Please open a pcx file first.";
                MessageBox.Show(errorMessage);
            }
            else
            {
                Bitmap temp_image = (Bitmap)ogImage.Image;
                Bitmap bw = new Bitmap(temp_image);
                histogram.Series.Clear();

                for (int x = 0; x < temp_image.Width; x++)
                {
                    for (int y = 0; y < temp_image.Height; y++)
                    {
                        Color pixel = temp_image.GetPixel(x, y);

                        int a = pixel.A;
                        int r = pixel.R;
                        int g = pixel.G;
                        int b = pixel.B;
                        int intensity = (r + g + b);

                        if(intensity >= bwSlider.Value) // If intensity is higher than threshold
                        {
                            bw.SetPixel(x, y, Color.White);
                        }
                        else
                        {
                            bw.SetPixel(x, y, Color.Black);
                        }
                    }
                }
                processedImage.Image = bw;
                label2.Text = "Black/White Thresholding";
            }
        }

        private void bwSlider_Scroll(object sender, EventArgs e)
        {
            bwLabel.Text = bwSlider.Value.ToString();
        }

        private void gammaSlider_Scroll(object sender, EventArgs e)
        {
            gammaLabel.Text = gammaSlider.Value.ToString();
        }

        private void gammaButton_Click(object sender, EventArgs e)
        {
            if (ogImage.Image == null)
            {
                string errorMessage = "Please open a pcx file first.";
                MessageBox.Show(errorMessage);
            }
            else
            {
                Bitmap temp_image = (Bitmap)ogImage.Image;
                Bitmap gamma_image = new Bitmap(temp_image);
                histogram.Series.Clear();

                for (int x = 0; x < temp_image.Width; x++)
                {
                    for (int y = 0; y < temp_image.Height; y++)
                    {
                        Color pixel = temp_image.GetPixel(x, y);

                        int a = pixel.A;
                        int r = pixel.R;
                        int g = pixel.G;
                        int b = pixel.B;
                        int s = (r + g + b) / 3;

                        int gamma = (int)Math.Pow(s, gammaSlider.Value); // Formula for gamma transformation
                        gamma = Math.Max(0, Math.Min(255, gamma));

                        Color newPixel = Color.FromArgb(r, g, b);
                        gamma_image.SetPixel(x, y, Color.FromArgb(a, gamma, gamma, gamma));
                    }
                }
                processedImage.Image = gamma_image;
                label2.Text = "Gamma Transformation";
            }
        }

        private void avgButton_Click(object sender, EventArgs e)
        {
            histogram.Series.Clear(); // Clears histogram
            if (ogImage.Image == null)
            {
                string errormessage = "Please open a pcx file first.";
                MessageBox.Show(errormessage);
            }
            else
            {
                Bitmap temp_image = (Bitmap)ogImage.Image;
                Bitmap avg = new Bitmap(temp_image);

                for (int x = 0; x < temp_image.Width - 1; x++)
                {
                    for (int y = 0; y < temp_image.Height - 1; y++)
                    {
                        int redSum = 0, greenSum = 0, blueSum = 0;
                        int divisor = 0;

                        for (int a = x; a <= x + 1; a++)
                        {
                            for (int b = y; b <= y + 1; b++)
                            {
                                divisor++;
                                Color pixel = temp_image.GetPixel(a, b);
                                redSum = redSum + pixel.R;
                                greenSum = greenSum + pixel.G;
                                blueSum = blueSum + pixel.B;
                            }

                            // Proceed to average values
                            int avgRed = redSum / divisor;
                            int avgGreen = greenSum / divisor;
                            int avgBlue = blueSum / divisor;
                            Color avgPixel = Color.FromArgb(avgRed, avgGreen, avgBlue);
                            avg.SetPixel(x, y, avgPixel);
                        }
                    }
                }
                processedImage.Image = avg;
                label2.Text = "Averaged";
            }
        }

        private void medianButton_Click(object sender, EventArgs e)
        {
            histogram.Series.Clear(); // Clears histogram

            if (ogImage.Image == null)
            {
                string errormessage = "Please open a pcx file first.";
                MessageBox.Show(errormessage);
            }
            else
            {
                Bitmap temp_image = (Bitmap)ogImage.Image;
                Bitmap median = new Bitmap(temp_image);

                for (int x = 0; x < temp_image.Width - 2; x++)
                {
                    for (int y = 0; y < temp_image.Height - 2; y++)
                    {
                        List<int> redValues = new List<int>();
                        List<int> greenValues = new List<int>();
                        List<int> blueValues = new List<int>();

                        for (int a = x; a <= x + 2; a++)
                        {
                            for (int b = y; b <= y + 2; b++)
                            {
                                Color pixel = temp_image.GetPixel(a, b);
                                redValues.Add(pixel.R);
                                greenValues.Add(pixel.G);
                                blueValues.Add(pixel.B);
                            }

                            // Proceed to take median of values
                            int newRed = redValues.OrderBy(val => val).ElementAt(redValues.Count / 2);
                            int newGreen = greenValues.OrderBy(val => val).ElementAt(greenValues.Count / 2);
                            int newBlue = blueValues.OrderBy(val => val).ElementAt(blueValues.Count / 2);

                            Color medianPixel = Color.FromArgb(newRed, newGreen, newBlue);
                            median.SetPixel(x, y, medianPixel);
                        }
                    }
                }
                processedImage.Image = median;
                label2.Text = "Median";
            }
        }

        private void highpassButton_Click(object sender, EventArgs e)
        {
            histogram.Series.Clear(); // Clears histogram

            if (ogImage.Image == null)
            {
                string errormessage = "Please open a pcx file first.";
                MessageBox.Show(errormessage);
            }
            else
            {
                Bitmap temp_image = (Bitmap)ogImage.Image;
                Bitmap highpass = new Bitmap(temp_image);
                Color c2, c4, c5, c6, c8;
                for (int x = 0; x < temp_image.Width - 3; x++)
                {
                    for (int y = 0; y < temp_image.Height - 3; y++)
                    {
                        c2 = temp_image.GetPixel(x + 1, y);
                        c4 = temp_image.GetPixel(x, y + 1);
                        c5 = temp_image.GetPixel(x + 1, y + 1);
                        c6 = temp_image.GetPixel(x + 2, y + 1);
                        c8 = temp_image.GetPixel(x + 1, y + 2);

                        //Laplacian filter used is 0, -1, 0, -1, 4, -1, 0, -1, 0
                        int newRed = c2.R * (-1) + c4.R * (-1) + c5.R * (4) + c6.R * (-1) + c8.R * (-1);
                        int newGreen = c2.G * (-1) + c4.G * (-1) + c5.G * (4) + c6.G * (-1) + c8.G * (-1);
                        int newBlue = c2.B * (-1) + c4.B * (-1) + c5.B * (4) + c6.B * (-1) + c8.B * (-1);

                        newRed = Math.Max(0, Math.Min(255, newRed));
                        newGreen = Math.Max(0, Math.Min(255, newGreen));
                        newBlue = Math.Max(0, Math.Min(255, newBlue));

                        Color newPixel = Color.FromArgb(newRed, newBlue, newGreen);
                        highpass.SetPixel(x, y, newPixel);
                    }
                }
                processedImage.Image = highpass;
                label2.Text = "Highpass";
            }
        }

        private void unsharpenButton_Click(object sender, EventArgs e)
        {
            histogram.Series.Clear(); // Clears histogram

            if (ogImage.Image == null)
            {
                string errormessage = "Please open a pcx file first.";
                MessageBox.Show(errormessage);
            }
            else
            {
                Bitmap temp_image = (Bitmap)ogImage.Image;
                Bitmap unsharpen = new Bitmap(temp_image);
                Bitmap avg = new Bitmap(temp_image);
                Bitmap mask = new Bitmap(temp_image);
                Color ogPixel, avgPixel, maskPixel, newPixel;
                int avgRed, avgGreen, avgBlue, newRed, newGreen, newBlue;

                // First, take blurred (averaged) bitmap
                for (int x = 0; x < temp_image.Width - 2; x++)
                {
                    for (int y = 0; y < temp_image.Height - 2; y++)
                    {
                        int redSum = 0, greenSum = 0, blueSum = 0;
                        int divisor = 0;

                        for (int a = x; a <= x + 2; a++)
                        {
                            for (int b = y; b <= y + 2; b++)
                            {
                                divisor++;
                                Color pixel = temp_image.GetPixel(a, b);
                                redSum = redSum + pixel.R;
                                greenSum = greenSum + pixel.G;
                                blueSum = blueSum + pixel.B;
                            }

                            avgRed = redSum / divisor;
                            avgGreen = greenSum / divisor;
                            avgBlue = blueSum / divisor;
                            avgPixel = Color.FromArgb(avgRed, avgGreen, avgBlue);
                            avg.SetPixel(x, y, avgPixel);
                        }
                    }
                }

                // Then subtract averaged from original to get mask
                for (int x = 0; x < temp_image.Width; x++)
                {
                    for (int y = 0; y < temp_image.Height; y++)
                    {
                        ogPixel = temp_image.GetPixel(x, y);
                        avgPixel = avg.GetPixel(x, y);

                        newRed = Math.Max(0, Math.Min(255, (ogPixel.R - avgPixel.R)));
                        newGreen = Math.Max(0, Math.Min(255, (ogPixel.G - avgPixel.G)));
                        newBlue = Math.Max(0, Math.Min(255, (ogPixel.B - avgPixel.B)));

                        newPixel = Color.FromArgb(newRed, newBlue, newGreen);
                        mask.SetPixel(x, y, newPixel);
                    }
                }

                // Finally, add back to original image
                for (int x = 0; x < temp_image.Width; x++)
                {
                    for (int y = 0; y < temp_image.Height; y++)
                    {
                        ogPixel = temp_image.GetPixel(x, y);
                        maskPixel = mask.GetPixel(x, y);

                        newRed = Math.Max(0, Math.Min(255, (ogPixel.R + maskPixel.R)));
                        newGreen = Math.Max(0, Math.Min(255, (ogPixel.G + maskPixel.G)));
                        newBlue = Math.Max(0, Math.Min(255, (ogPixel.B + maskPixel.B)));

                        newPixel = Color.FromArgb(newRed, newBlue, newGreen);
                        unsharpen.SetPixel(x, y, newPixel);
                    }
                }

                processedImage.Image = unsharpen;
                label2.Text = "Unsharpened";
            }
        }

        private void highboostButton_Click(object sender, EventArgs e)
        {
            histogram.Series.Clear(); // Clears histogram

            if (ogImage.Image == null)
            {
                string errormessage = "Please open a pcx file first.";
                MessageBox.Show(errormessage);
            }
            else
            {
                Bitmap temp_image = (Bitmap)ogImage.Image;
                Bitmap grayscale = new Bitmap(temp_image);
                Bitmap highboost = new Bitmap(temp_image);
                Color c1, c2, c3, c4, c5, c6, c7, c8, c9, hbPixel;
                int a, r, g, b, s;
                int boostFactor = 3, ogPixel, newPixel, edges, corners, center;

                // Create Grayscale image
                for (int x = 0; x < temp_image.Width; x++)
                {
                    for (int y = 0; y < temp_image.Height; y++)
                    {
                        Color pixel = temp_image.GetPixel(x, y);

                        a = pixel.A;
                        r = pixel.R;
                        g = pixel.G;
                        b = pixel.B;
                        s = (r + g + b) / 3;

                        grayscale.SetPixel(x, y, Color.FromArgb(a, s, s, s));
                    }
                }


                for (int x = 0; x < temp_image.Width - 3; x++)
                {
                    for (int y = 0; y < temp_image.Height - 3; y++)
                    {
                        ogPixel = 0;

                        c1 = grayscale.GetPixel(x, y);
                        c2 = grayscale.GetPixel(x + 1, y);
                        c3 = grayscale.GetPixel(x + 2, y);
                        c4 = grayscale.GetPixel(x, y + 1);
                        c5 = grayscale.GetPixel(x + 1, y + 1);
                        c6 = grayscale.GetPixel(x + 2, y + 1);
                        c7 = grayscale.GetPixel(x, y + 2);
                        c8 = grayscale.GetPixel(x + 1, y + 2);
                        c9 = grayscale.GetPixel(x + 2, y + 2);

                        // Highboost filter used is 0, -1, 0, -1, boostFactor + 6, -1, 0, -1, 0
                        edges = (c2.R + c4.R + c6.R + c8.R) * (-1);
                        corners = (c1.R + c3.R + c7.R + c9.R) * 0;
                        center = (boostFactor + 6) * c5.R;
                        newPixel = ogPixel + edges + corners + center;
                        newPixel = Math.Max(0, Math.Min(255, newPixel));

                        hbPixel = Color.FromArgb(newPixel, newPixel, newPixel);
                        highboost.SetPixel(x, y, hbPixel);
                    }
                }
                processedImage.Image = highboost;
                label2.Text = "Highboost";
            }
        }

        private void gradientXButton_Click(object sender, EventArgs e)
        {
            histogram.Series.Clear(); // Clears histogram

            if (ogImage.Image == null)
            {
                string errormessage = "Please open a pcx file first.";
                MessageBox.Show(errormessage);
            }
            else
            {
                Bitmap temp_image = (Bitmap)ogImage.Image;
                Bitmap grayscale = new Bitmap(temp_image);
                Bitmap gradientX = new Bitmap(temp_image);
                Color c1, c2, c3, c4, c5, c6, c7, c8, c9, gradientXPixel;
                int a, r, g, b, s, xValue;

                // First, create grayscale of image
                for (int x = 0; x < temp_image.Width; x++)
                {
                    for (int y = 0; y < temp_image.Height; y++)
                    {
                        Color pixel = temp_image.GetPixel(x, y);

                        a = pixel.A;
                        r = pixel.R;
                        g = pixel.G;
                        b = pixel.B;
                        s = (r + g + b) / 3;

                        grayscale.SetPixel(x, y, Color.FromArgb(a, s, s, s));
                    }
                }

                // Then take relevant pixels
                for (int x = 0; x < temp_image.Width - 3; x++)
                {
                    for (int y = 0; y < temp_image.Height - 3; y++)
                    {
                        c1 = grayscale.GetPixel(x, y);
                        c2 = grayscale.GetPixel(x + 1, y);
                        c3 = grayscale.GetPixel(x + 2, y);
                        c4 = grayscale.GetPixel(x, y + 1);
                        c5 = grayscale.GetPixel(x + 1, y + 1);
                        c6 = grayscale.GetPixel(x + 2, y + 1);
                        c7 = grayscale.GetPixel(x, y + 2);
                        c8 = grayscale.GetPixel(x + 1, y + 2);
                        c9 = grayscale.GetPixel(x + 2, y + 2);

                        // Apply Sobel x filter using -1, 0, 1, -2, 0, 2, -1, 0, -1
                        xValue = (c1.R * -1) + (c2.R * 0) + (c3.R * 1)
                            + (c4.R * -2) + (c5.R * 0) + (c6.R * 2)
                            + (c7.R * -1) + (c8.R * 0) + (c9.R * 1);
                        xValue = Math.Max(0, Math.Min(255, xValue));

                        gradientXPixel = Color.FromArgb(xValue, xValue, xValue);
                        gradientX.SetPixel(x, y, gradientXPixel);
                    }
                }
                processedImage.Image = gradientX;
                label2.Text = "Gradient Sobel X";
            }
        }

        private void gradientYButton_Click(object sender, EventArgs e)
        {
            histogram.Series.Clear(); // Clears histogram

            if (ogImage.Image == null)
            {
                string errormessage = "Please open a pcx file first.";
                MessageBox.Show(errormessage);
            }
            else
            {
                Bitmap temp_image = (Bitmap)ogImage.Image;
                Bitmap grayscale = new Bitmap(temp_image);
                Bitmap gradientY = new Bitmap(temp_image);
                Color c1, c2, c3, c4, c5, c6, c7, c8, c9, gradientYPixel;
                int a, r, g, b, s, yValue;

                // First, create grayscale of image
                for (int x = 0; x < temp_image.Width; x++)
                {
                    for (int y = 0; y < temp_image.Height; y++)
                    {
                        Color pixel = temp_image.GetPixel(x, y);

                        a = pixel.A;
                        r = pixel.R;
                        g = pixel.G;
                        b = pixel.B;
                        s = (r + g + b) / 3;

                        grayscale.SetPixel(x, y, Color.FromArgb(a, s, s, s));
                    }
                }

                // Then take relevant pixels
                for (int x = 0; x < temp_image.Width - 3; x++)
                {
                    for (int y = 0; y < temp_image.Height - 3; y++)
                    {
                        c1 = grayscale.GetPixel(x, y);
                        c2 = grayscale.GetPixel(x + 1, y);
                        c3 = grayscale.GetPixel(x + 2, y);
                        c4 = grayscale.GetPixel(x, y + 1);
                        c5 = grayscale.GetPixel(x + 1, y + 1);
                        c6 = grayscale.GetPixel(x + 2, y + 1);
                        c7 = grayscale.GetPixel(x, y + 2);
                        c8 = grayscale.GetPixel(x + 1, y + 2);
                        c9 = grayscale.GetPixel(x + 2, y + 2);

                        // Sobel y filter using -1, -2, -1, 0, 0, 0, 1, 2, 1
                        yValue = (c1.R * -1) + (c2.R * -2) + (c3.R * -1)
                            + (c4.R * 0) + (c5.R * 0) + (c6.R * 0)
                            + (c7.R * 1) + (c8.R * 2) + (c9.R * 1);
                        yValue = Math.Max(0, Math.Min(255, yValue));

                        gradientYPixel = Color.FromArgb(yValue, yValue, yValue);
                        gradientY.SetPixel(x, y, gradientYPixel);
                    }
                }
                processedImage.Image = gradientY;
                label2.Text = "Gradient Sobel Y";
            }
        }

        private void gradientXYButton_Click(object sender, EventArgs e)
        {
            histogram.Series.Clear(); // Clears histogram

            if (ogImage.Image == null)
            {
                string errormessage = "Please open a pcx file first.";
                MessageBox.Show(errormessage);
            }
            else
            {
                Bitmap temp_image = (Bitmap)ogImage.Image;
                Bitmap grayscale = new Bitmap(temp_image);
                Bitmap gradient = new Bitmap(temp_image);
                Color c1, c2, c3, c4, c5, c6, c7, c8, c9, gradientPixel;
                int a, r, g, b, s, xValue, yValue, sobel;

                // First, create grayscale of image
                for (int x = 0; x < temp_image.Width; x++)
                {
                    for (int y = 0; y < temp_image.Height; y++)
                    {
                        Color pixel = temp_image.GetPixel(x, y);

                        a = pixel.A;
                        r = pixel.R;
                        g = pixel.G;
                        b = pixel.B;
                        s = (r + g + b) / 3;

                        grayscale.SetPixel(x, y, Color.FromArgb(a, s, s, s));
                    }
                }

                // Then take relevant pixels
                for (int x = 0; x < temp_image.Width - 3; x++)
                {
                    for (int y = 0; y < temp_image.Height - 3; y++)
                    {
                        c1 = grayscale.GetPixel(x, y);
                        c2 = grayscale.GetPixel(x + 1, y);
                        c3 = grayscale.GetPixel(x + 2, y);
                        c4 = grayscale.GetPixel(x, y + 1);
                        c5 = grayscale.GetPixel(x + 1, y + 1);
                        c6 = grayscale.GetPixel(x + 2, y + 1);
                        c7 = grayscale.GetPixel(x, y + 2);
                        c8 = grayscale.GetPixel(x + 1, y + 2);
                        c9 = grayscale.GetPixel(x + 2, y + 2);

                        // Sobel x filter using -1, 0, 1, -2, 0, 2, -1, 0, -1
                        xValue = (c1.R * -1) + (c2.R * 0) + (c3.R * 1)
                            + (c4.R * -2) + (c5.R * 0) + (c6.R * 2)
                            + (c7.R * -1) + (c8.R * 0) + (c9.R * 1);
                        xValue = Math.Max(0, Math.Min(255, xValue));

                        // Sobel y filter using -1, -2, -1, 0, 0, 0, 1, 2, 1
                        yValue = (c1.R * -1) + (c2.R * -2) + (c3.R * -1)
                            + (c4.R * 0) + (c5.R * 0) + (c6.R * 0)
                            + (c7.R * 1) + (c8.R * 2) + (c9.R * 1);
                        yValue = Math.Max(0, Math.Min(255, yValue));

                        // Get Sobel xy by square root of x^2 and y^2
                        sobel = (int)Math.Sqrt(Math.Pow(xValue, 2) + Math.Pow(yValue, 2));
                        sobel = Math.Max(0, Math.Min(255, sobel));


                        gradientPixel = Color.FromArgb(sobel, sobel, sobel);
                        gradient.SetPixel(x, y, gradientPixel);
                    }
                }
                processedImage.Image = gradient;
                label2.Text = "Gradient Sobel XY";
            }
        }
    }
}
