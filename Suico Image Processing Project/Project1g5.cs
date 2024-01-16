using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Data;

namespace Suico_Image_Processing_Project
{
    class Project1g5
    {
        public static Bitmap GetAverage(Bitmap img)
        {
            Bitmap temp_image = new Bitmap(img);
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

            return avg;
        }

        public static Bitmap GetMedian(Bitmap img)
        {
            Bitmap temp_image = new Bitmap(img);
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

            return median;
        }

        public static Bitmap GetHighpass(Bitmap img)
        {
            Bitmap temp_image = new Bitmap(img);
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
            return highpass;
        }

        public static Bitmap Unsharpen(Bitmap img)
        {
            Bitmap temp_image = new Bitmap(img);
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

            return unsharpen;
        }

        public static Bitmap GetHighboost(Bitmap img)
        {
            Bitmap temp_image = new Bitmap(img);
            Bitmap grayscale = Project1g4.GetGrayscale(temp_image);
            Bitmap highboost = new Bitmap(temp_image);
            Color c1, c2, c3, c4, c5, c6, c7, c8, c9, hbPixel;

            int boostFactor = 2, ogPixel, newPixel, edges, corners, center;

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

            return highboost;
        }

        public static Bitmap GetGradientX(Bitmap img)
        {
            Bitmap temp_image = new Bitmap(img);
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

            return gradientX;
        }
        
        public static Bitmap GetGradientY(Bitmap img)
        {
            Bitmap temp_image = new Bitmap(img);
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

            return gradientY;
        }

        public static Bitmap GetGradientXY(Bitmap img)
        {
            Bitmap temp_image = new Bitmap(img);
            Bitmap grayscale = new Bitmap(temp_image);
            Bitmap gradientXY = new Bitmap(temp_image);
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
                    gradientXY.SetPixel(x, y, gradientPixel);
                }
            }

            return gradientXY;
        }
    }
}
