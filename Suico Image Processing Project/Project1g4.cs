﻿using System;
using System.Drawing;

namespace Suico_Image_Processing_Project
{
    class Project1g4
    {
        public static Bitmap GetGrayscale(Bitmap img)
        {
            Bitmap temp_image = new Bitmap(img);
            Bitmap gray = new Bitmap(temp_image);

            for (int x = 0; x < temp_image.Width; x++)
            {
                for (int y = 0; y < temp_image.Height; y++)
                {
                    Color pixel = temp_image.GetPixel(x, y);

                    int r = pixel.R;
                    int g = pixel.G;
                    int b = pixel.B;
                    int s = (r + g + b) / 3;

                    gray.SetPixel(x, y, Color.FromArgb(s, s, s));
                }
            }

            return gray;
        }

        public static Bitmap GetNegative(Bitmap img)
        {
            Bitmap temp_image = new Bitmap(img);
            Bitmap negative = new Bitmap(temp_image);

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
            return negative;
        }

        public static Bitmap GetBW(Bitmap img, int slider_value)
        {
            Bitmap temp_image = new Bitmap(img);
            Bitmap bw = new Bitmap(temp_image);

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

                    if (intensity >= slider_value) // If intensity is higher than threshold
                    {
                        bw.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        bw.SetPixel(x, y, Color.Black);
                    }
                }
            }
            return bw;
        }

        public static Bitmap GetGamma(Bitmap img, int slider_value)
        {
            Bitmap temp_image = new Bitmap(img);
            Bitmap gamma_image = new Bitmap(temp_image);

            for (int x = 0; x < temp_image.Width; x++)
            {
                for (int y = 0; y < temp_image.Height; y++)
                {
                    Color pixel = temp_image.GetPixel(x, y);

                    // Perform gamma transformation on each value
                    int r = (int)(Math.Pow(pixel.R / 255.0, slider_value) * 255.0);
                    int g = (int)(Math.Pow(pixel.G / 255.0, slider_value) * 255.0);
                    int b = (int)(Math.Pow(pixel.B / 255.0, slider_value) * 255.0);

                    // Ensure values are within valid range (0-255)
                    r = Math.Max(0, Math.Min(255, r));
                    g = Math.Max(0, Math.Min(255, g));
                    b = Math.Max(0, Math.Min(255, b));

                    Color newPixel = Color.FromArgb(r, g, b);
                    gamma_image.SetPixel(x, y, newPixel);
                }
            }
            return gamma_image;
        }
    }
}
