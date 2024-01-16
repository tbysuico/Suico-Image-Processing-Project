using System.Drawing;

namespace Suico_Image_Processing_Project
{
    class Project1g3
    {
        public static Bitmap GetReds(Bitmap img)
        {
            Bitmap temp_image = new Bitmap(img);
            Bitmap redChannel = new Bitmap(temp_image);

            for (int x = 0; x < temp_image.Width; x++) // Iterates through all pixels of the image
            {
                for (int y = 0; y < temp_image.Height; y++)
                {
                    Color pixel = temp_image.GetPixel(x, y); // Takes the color of the pixel at the xth, yth coordinate

                    // Takes the relevant values of the pixel
                    int a = pixel.A;
                    int r = pixel.R;

                    redChannel.SetPixel(x, y, Color.FromArgb(a, r, 0, 0)); // Sets all other values to 0 except the relevant color
                }
            }

            return redChannel;
        }

        public static Bitmap GetGreens(Bitmap img)
        {
            Bitmap temp_image = new Bitmap(img);
            Bitmap greenChannel = new Bitmap(temp_image);

            for (int x = 0; x < temp_image.Width; x++) // Iterates through all pixels of the image
            {
                for (int y = 0; y < temp_image.Height; y++)
                {
                    Color pixel = temp_image.GetPixel(x, y); // Takes the color of the pixel at the xth, yth coordinate

                    // Takes the relevant values of the pixel
                    int a = pixel.A;
                    int g = pixel.G;

                    greenChannel.SetPixel(x, y, Color.FromArgb(a, 0, g, 0)); // Sets all other values to 0 except the relevant color
                }
            }

            return greenChannel;
        }

        public static Bitmap GetBlues(Bitmap img)
        {
            Bitmap temp_image = new Bitmap(img);
            Bitmap blueChannel = new Bitmap(temp_image);

            for (int x = 0; x < temp_image.Width; x++) // Iterates through all pixels of the image
            {
                for (int y = 0; y < temp_image.Height; y++)
                {
                    Color pixel = temp_image.GetPixel(x, y); // Takes the color of the pixel at the xth, yth coordinate

                    // Takes the relevant values of the pixel
                    int a = pixel.A;
                    int b = pixel.B;

                    blueChannel.SetPixel(x, y, Color.FromArgb(a, 0, 0, b)); // Sets all other values to 0 except the relevant color
                }
            }

            return blueChannel;
        }

        public static int[] GetHist(Bitmap img)
        {
            int[] intensity = new int[256];

            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    Color pixel = img.GetPixel(x, y);

                    int g = pixel.R;

                    intensity[g]++;

                }
            }

            return intensity;
        }
    }
}
