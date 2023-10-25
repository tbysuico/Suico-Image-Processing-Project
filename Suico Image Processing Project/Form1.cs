﻿using System;
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
            Bitmap temp_image = (Bitmap)ogImage.Image;
            Bitmap redChannel = new Bitmap(256, 256);
            histogram.Series.Clear(); // Clears histogram
            histogram.Series.Add("Pixels"); // Re-initializes Pixels series for chart
            int[] intensity = new int[256];

            if (ogImage.Image != null) // Checks if there is an available image to process
            {
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

                for (int x = 0; x < 256; x++)
                {
                    histogram.Series["Pixels"].Points.AddXY(x, intensity[x]);
                }
            }
            else // Prints error message if there is no image available to process
            {
                string errorMessage = "Please open a pcx file first.";
                MessageBox.Show(errorMessage);
            }
        }

        private void greenButton_Click(object sender, EventArgs e) // Function for Green Channel button
        {
            Bitmap temp_image = (Bitmap)ogImage.Image;
            Bitmap greenChannel = new Bitmap(256, 256);
            histogram.Series.Clear(); // Clears histogram
            histogram.Series.Add("Pixels"); // Re-initializes Pixels series for chart
            int[] intensity = new int[256];

            if (ogImage.Image != null) // Check
            {
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

                for (int x = 0; x < 256; x++)
                {
                    histogram.Series["Pixels"].Points.AddXY(x, intensity[x]);
                }
            }
            else
            {
                string errorMessage = "Please open a pcx file first.";
                MessageBox.Show(errorMessage);
            }
        }

        private void blueButton_Click(object sender, EventArgs e) // Function for Blue Channel button
        {
            Bitmap temp_image = (Bitmap)ogImage.Image;
            Bitmap blueChannel = new Bitmap(256, 256);
            histogram.Series.Clear(); // Clears histogram
            histogram.Series.Add("Pixels"); // Re-initializes Pixels series for chart
            int[] intensity = new int[256];

            if (ogImage.Image != null)
            {
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

                for (int x = 0; x < 256; x++)
                {
                    histogram.Series["Pixels"].Points.AddXY(x, intensity[x]);
                }
            }
            else
            {
                string errorMessage = "Please open a pcx file first.";
                MessageBox.Show(errorMessage);
            }
        }
    }
}
