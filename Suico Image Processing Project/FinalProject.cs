using System.Collections.Generic;
using System.Drawing;
using System;
using System.Drawing.Imaging;
using System.Linq;

namespace Suico_Image_Processing_Project
{
    class FinalProject
    {
        public static List<Bitmap> LucasKanade(List<string> imagePaths)
        {
            var Frames = new List<Bitmap>();
            var processFrames = new List<Bitmap>();

            // Load frames
            foreach (var address in imagePaths)
                Frames.Add(new Bitmap(address));

            int windowSize = 5;

            for (int i = 1; i < Frames.Count; i++)
            {
                float[,] opticalFlowU, opticalFlowV;

                ComputeLucasKanade(Frames[i], Frames[i - 1], windowSize, out opticalFlowU, out opticalFlowV);

                // Create a new Bitmap to visualize the optical flow
                var processBmp = new Bitmap(Frames[0]);
                // Normalize the optical flow values for visualization
                float maxFlow = Math.Max(opticalFlowU.Cast<float>().Max(), opticalFlowV.Cast<float>().Max());
                float scale = 255.0f / maxFlow;
                for (int x = 0; x < processBmp.Width; x++)
                {
                    for (int y = 0; y < processBmp.Height; y++)
                    {
                        // Scale the optical flow values to the range [0, 255]
                        int red = (int)(opticalFlowU[x, y] * scale);
                        int green = (int)(opticalFlowV[x, y] * scale);
                        if (red < 0)
                            red = 0;
                        if (green < 0)
                            green = 0;
                        // Encode the flow vectors as colors in the output image
                        Color flowColor = Color.FromArgb(red, green, 0);
                        processBmp.SetPixel(x, y, flowColor);
                    }
                }

                processFrames.Add(processBmp);
            }


            return processFrames;
        }

        static void ComputeLucasKanade(Bitmap frame1, Bitmap frame2, int windowSize, out float[,] opticalFlowU, out float[,] opticalFlowV)
        {
            var width = frame1.Width;
            var height = frame1.Height;

            float[,] image1 = new float[width, height];
            float[,] image2 = new float[width, height];

            for (int y = 0; y < frame1.Height; y++)
            {
                for (int x = 0; x < frame1.Width; x++)
                {
                    image1[x, y] = frame1.GetPixel(x, y).R / 255.0f;
                    image2[x, y] = frame2.GetPixel(x, y).R / 255.0f;
                }
            }

            opticalFlowU = new float[frame1.Width, frame1.Height];
            opticalFlowV = new float[frame1.Width, frame1.Height];

            float[,] iX = ComputeImageGradientX(image1);
            float[,] iY = ComputeImageGradientY(image1);
            float[,] iT = ComputeTemporalGradient(image1, image2);

            // Compute optical flow for each pixel
            for (int y = windowSize; y < height - windowSize; y++)
            {
                for (int x = windowSize; x < width - windowSize; x++)
                {
                    // Extract local image regions
                    float[,] IxLocal = ExtractWindow(iX, x, y, windowSize);
                    float[,] IyLocal = ExtractWindow(iY, x, y, windowSize);
                    float[,] ItLocal = ExtractWindow(iT, x, y, windowSize);

                    // Compute Lucas-Kanade optical flow equations
                    float[,] A = ComputeA(IxLocal, IyLocal);
                    float[,] b = ComputeB(IxLocal, IyLocal, ItLocal);

                    // Solve linear equations for optical flow (Ax = b)
                    SolveLinearEquation(A, b, out float u, out float v);

                    // Assign optical flow values to the result arrays
                    opticalFlowU[x, y] = u;
                    opticalFlowV[x, y] = v;
                }
            }

        }

        static float[,] ComputeImageGradientX(float[,] image)
        {
            // Compute the gradient of the image in the x-direction
            int width = image.GetLength(0);
            int height = image.GetLength(1);

            float[,] gradientX = new float[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    gradientX[x, y] = (image[x + 1, y] - image[x - 1, y]) / 2.0f;
                }
            }

            return gradientX;
        }
        static float[,] ComputeImageGradientY(float[,] image)
        {
            // Compute the gradient of the image in the y-direction
            int width = image.GetLength(0);
            int height = image.GetLength(1);

            float[,] gradientY = new float[width, height];

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    gradientY[x, y] = (image[x, y + 1] - image[x, y - 1]) / 2.0f;
                }
            }

            return gradientY;
        }
        static float[,] ComputeTemporalGradient(float[,] image1, float[,] image2)
        {
            // Compute the temporal gradient between two consecutive frames
            int width = image1.GetLength(0);
            int height = image1.GetLength(1);

            float[,] temporalGradient = new float[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    temporalGradient[x, y] = image2[x, y] - image1[x, y];
                }
            }

            return temporalGradient;
        }

        static float[,] ExtractWindow(float[,] input, int centerX, int centerY, int windowSize)
        {
            // Extract a local window from the input array
            int width = input.GetLength(0);
            int height = input.GetLength(1);

            int windowRadius = windowSize / 2;

            float[,] window = new float[windowSize, windowSize];

            for (int y = 0; y < windowSize; y++)
            {
                for (int x = 0; x < windowSize; x++)
                {
                    int px = centerX - windowRadius + x;
                    int py = centerY - windowRadius + y;

                    // Ensure the coordinates are within bounds
                    px = Math.Max(0, Math.Min(width - 1, px));
                    py = Math.Max(0, Math.Min(height - 1, py));

                    window[x, y] = input[px, py];
                }
            }

            return window;
        }

        static float[,] ComputeA(float[,] Ix, float[,] Iy)
        {
            // Compute the matrix A for Lucas-Kanade optical flow equations
            int windowSize = Ix.GetLength(0);

            float[,] A = new float[2, 2];

            for (int y = 0; y < windowSize; y++)
            {
                for (int x = 0; x < windowSize; x++)
                {
                    A[0, 0] += Ix[x, y] * Ix[x, y];
                    A[0, 1] += Ix[x, y] * Iy[x, y];
                    A[1, 0] += Ix[x, y] * Iy[x, y];
                    A[1, 1] += Iy[x, y] * Iy[x, y];
                }
            }

            return A;
        }

        static float[,] ComputeB(float[,] Ix, float[,] Iy, float[,] It)
        {
            // Compute the vector b for Lucas-Kanade optical flow equations
            int windowSize = Ix.GetLength(0);

            float[,] B = new float[2, 1];

            for (int y = 0; y < windowSize; y++)
            {
                for (int x = 0; x < windowSize; x++)
                {
                    B[0, 0] += -Ix[x, y] * It[x, y];
                    B[1, 0] += -Iy[x, y] * It[x, y];
                }
            }

            return B;
        }

        static void SolveLinearEquation(float[,] A, float[,] b, out float x, out float y)
        {
            // Solve a 2x2 linear equation system Ax = b
            float detA = A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];

            if (Math.Abs(detA) < 1e-5)
            {
                // Handle singular or nearly singular matrix
                x = 0.0f;
                y = 0.0f;
            }
            else
            {
                x = (A[1, 1] * b[0, 0] - A[0, 1] * b[1, 0]) / detA;
                y = (A[0, 0] * b[1, 0] - A[1, 0] * b[0, 0]) / detA;
            }
        }
    }
}
