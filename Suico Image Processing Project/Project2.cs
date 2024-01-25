using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Suico_Image_Processing_Project
{
    class Project2
    {
        public static Bitmap DegradeImage(Bitmap img, int slider_value, string check)
        {
            Bitmap gray = Project1g4.GetGrayscale(img);
            double proba = (double)slider_value / 100;
            double threshold = 1 - proba;
            int numPixels = (int)(proba * gray.Width * gray.Height);
            Random rnd = new Random();
            int[] intensity = new int[256];

            if (check == "Salt Noise")
            {
                for (int x = 0; x < gray.Width; x++)
                {
                    for (int y = 0; y < gray.Height; y++)
                    {
                        if (rnd.NextDouble() > threshold)
                            gray.SetPixel(x, y, Color.White);
                    }
                }
            }
            else if (check == "Pepper Noise")
            {
                for (int x = 0; x < gray.Width; x++)
                {
                    for (int y = 0; y < gray.Height; y++)
                    {
                        if (rnd.NextDouble() > threshold)
                            gray.SetPixel(x, y, Color.Black);
                    }
                }
            }
            else if (check == "Salt and Pepper Noise")
            {
                for (int x = 0; x < gray.Width; x++)
                {
                    for (int y = 0; y < gray.Height; y++)
                    {
                        double num = Math.Round(rnd.NextDouble(), 2);
                        if (num < proba)
                            gray.SetPixel(x, y, Color.Black);
                        else if (num > threshold)
                            gray.SetPixel(x, y, Color.White);
                    }
                }
            }

            return gray;
        }

        public static Bitmap RestoreImage(Bitmap img, int q, string check)
        {
            Bitmap temp_img = new Bitmap(img);
            Bitmap restored = new Bitmap(temp_img);

            if (check == "Median")
            {
                restored = Project1g5.GetMedian(img);
            }
            else if (check == "Geometric Mean")
            {
                for (int x = 0; x < temp_img.Width - 2; x++)
                {
                    for (int y = 0; y < temp_img.Height - 2; y++)
                    {
                        double product = 1;
                        double root = 0;

                        for (int i = x; i <= x + 2; i++)
                        {
                            for (int j = y; j <= y + 2; j++)
                            {
                                Color pixel = temp_img.GetPixel(i, j);
                                product *= pixel.R;
                                root++;
                            }
                        }

                        int result = (int)(Math.Pow(product, 1 / root));

                        // Proceed to average values
                        restored.SetPixel(x, y, Color.FromArgb(result, result, result));
                    }
                }
            }
            else if (check == "Contraharmonic")
            {
                for (int x = 0; x < img.Height - 2; x++)
                {
                    for (int y = 0; y < img.Width - 2; y++)
                    {
                        double numerator = 0.00;
                        double denominator = 0.00;

                        for (int i = x; i <= x + 2; i++)
                        {
                            for (int j = y; j <= y + 2; j++)
                            {
                                Color pixel = temp_img.GetPixel(i, j);
                                int intensity = pixel.R;
                                numerator += Math.Pow(intensity, q + 1);
                                denominator += Math.Pow(intensity, q);
                            }
                        }

                        int newValue = (int)Math.Round(numerator / denominator);

                        restored.SetPixel(x, y, Color.FromArgb(newValue, newValue, newValue));
                    }
                }
            }

            return restored;
        }

        public static byte[] RunLengthEncode(string inputData)
        {
            byte[] readPCX = File.ReadAllBytes(inputData); // Seeking to the end of file
            using (MemoryStream compressedStream = new MemoryStream())
            {
                int runLength = 1;
                for (int i = 0; i < readPCX.Length - 1; i++)
                {
                    if (readPCX[i] == readPCX[i + 1])
                    {
                        runLength++;
                    }
                    else
                    {
                        compressedStream.WriteByte((byte)runLength);
                        compressedStream.WriteByte(readPCX[i]);

                        runLength = 1;
                    }
                }
                // Write the last run
                compressedStream.WriteByte((byte)runLength);
                compressedStream.WriteByte(readPCX[readPCX.Length - 1]);

                return compressedStream.ToArray();
            }
        }

        public static Bitmap RunLengthDecode(byte[] imgData)
        {
            List<byte> decoded = new List<byte>();
            int decodeIndex = 0;
            int multiplicand = 0;

            for (int i = 0; i < imgData.Length; i++)
            {
                if (i % 2 == 0)
                {
                    multiplicand = (int)imgData[i];
                }
                else
                {
                    for (int j = 0; j < multiplicand; j++)
                    {
                        decoded.Add(imgData[i]);
                        decodeIndex++;
                    }
                }
            }
            List<Color> colors = new List<Color>(); // List of colors from image

            for (int x = decoded.Count - 768; x < decoded.Count; x += 3) // Count back 768 to take colors (769 results in out of bounds error)
            {
                colors.Add(Color.FromArgb(decoded[x], decoded[x + 1], decoded[x + 2]));
            }
            // Initialize vars for constructing image
            Bitmap decodedImg = new Bitmap(256, 256);
            Color[] image_colors = new Color[256 * 256];
            List<byte> pixels = new List<byte>();
            int index = 128;
            byte byteDuplicator = 0;
            byte prefix = 0;

            while (index < decoded.Count) // Iterating through relevant bytes for RLE
            {
                byte reader = decoded[index++]; // Read next byte in sequence
                if ((reader & 0xC0) == 0xC0 && index < decoded.Count) // Check if 2-bit
                {
                    byteDuplicator = decoded[index++]; // Duplicates byte
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

            for (int i = 0; i < 256 * 256; i++)
            {
                image_colors[i] = colors[pixels[i]]; // Setting each color for each pixel in image
                int y = i / 256; // y-coordinate
                int x = i - (256 * y); // x-coordinate
                decodedImg.SetPixel(x, y, image_colors[i]); // Constructing image using acquired variables for RLE
            }

            return decodedImg;
        }

        public class HuffmanNode
        {
            public byte? Bytecode { get; set; }
            public int Frequency { get; set; }
            public HuffmanNode Left { get; set; }
            public HuffmanNode Right { get; set; }

            public HuffmanNode(byte? value, int frequency, HuffmanNode left = null, HuffmanNode right = null)
            {
                Bytecode = value;
                Frequency = frequency;
                Left = left;
                Right = right;
            }
        }

        public class MinHeap
        {
            private List<HuffmanNode> tree;

            public MinHeap()
            {
                tree = new List<HuffmanNode>();
            }

            public int Count => tree.Count;

            public void Add(HuffmanNode node)
            {
                tree.Add(node);
                tree.Sort((x, y) => x.Frequency.CompareTo(y.Frequency));
            }

            public HuffmanNode ExtractMin()
            {
                if (tree.Count == 0)
                    throw new InvalidOperationException("MinHeap is empty.");

                if(tree.Count == 1)
                {
                    HuffmanNode root = tree[0];
                    tree.Remove(tree[0]);
                    return root;
                }

                HuffmanNode minNode = tree[0];
                tree.RemoveAt(0);

                return minNode;
            }

            public bool IsEmpty()
            {
                return tree.Count == 0;
            }
        }

        public class HuffmanTree
        {
            public HuffmanNode BuildHuffmanTree(Dictionary<byte?, int> frequencies)
            {
                var minHeap = new MinHeap();

                foreach (var node in frequencies)
                {
                    minHeap.Add(new HuffmanNode(node.Key, node.Value));
                }

                while (minHeap.Count > 1)
                {
                    var left = minHeap.ExtractMin();
                    var right = minHeap.ExtractMin();
                    var merged = new HuffmanNode(null, left.Frequency + right.Frequency, left, right);

                    minHeap.Add(merged);
                }
                return minHeap.ExtractMin();
            }

            public void TraverseTree(HuffmanNode node, string code, Dictionary<byte?, string> codeTable)
            {
                // check if leaf node
                if (node.Left == null && node.Right == null)
                {
                    codeTable[node.Bytecode] = code;
                    return;
                }

                if (node.Left != null)
                    TraverseTree(node.Left, code + "0", codeTable);
                if (node.Right != null)
                    TraverseTree(node.Right, code + "1", codeTable);
            }

            public Dictionary<byte?, string> GetHuffmanCode(HuffmanNode root)
            {
                var codeTable = new Dictionary<byte?, string>();
                TraverseTree(root, "", codeTable);
                return codeTable;
            }

            public string EncodeImage(byte[] imgData, Dictionary<byte?, string> codeTable)
            {
                StringBuilder encodedData = new StringBuilder();
                foreach(byte index in imgData)
                {
                     encodedData.Append(codeTable[index]);
                }
                return encodedData.ToString();
            }
        }

        public static Dictionary<byte?, int> getFrequencies(byte[] imgData)
        {
            var frequencies = new Dictionary<byte?, int>();
            foreach(byte data in imgData)
            {
                if (!frequencies.ContainsKey(data))
                    frequencies[data] = 0;
                frequencies[data]++;
            }
            return frequencies;
        }

        public static string HuffmanEncode (string inputData)
        {
            var readPCX = File.ReadAllBytes(inputData); // Seeking to the end of file
            var tree = new HuffmanTree();
            var frequencies = getFrequencies(readPCX);

            var huffmanTree = tree.BuildHuffmanTree(frequencies);
            var huffmanCode = tree.GetHuffmanCode(huffmanTree);
            string encodedData = tree.EncodeImage(readPCX, huffmanCode);
            
            return encodedData;
        }

        public static Bitmap HuffmanDecode(HuffmanNode root, string encodedData)
        {
            List<byte> decoded = new List<byte>();
            HuffmanNode current = root;

            foreach (var bit in encodedData)
            {
                if (bit == '0')
                    current = current.Left;
                else if (bit == '1')
                    current = current.Right;

                if (current.Bytecode.HasValue)
                {
                    decoded.Add((byte)current.Bytecode);
                    current = root;
                }
            }

            List<Color> colors = new List<Color>(); // List of colors from image

            for (int x = decoded.Count - 768; x < decoded.Count; x += 3) // Count back 768 to take colors (769 results in out of bounds error)
            {
                colors.Add(Color.FromArgb(decoded[x], decoded[x + 1], decoded[x + 2]));
            }
            // Initialize vars for constructing image
            Bitmap decodedImg = new Bitmap(256, 256);
            Color[] image_colors = new Color[256 * 256];
            List<byte> pixels = new List<byte>();
            int index = 128;
            byte byteDuplicator = 0;
            byte prefix = 0;

            while (index < decoded.Count) // Iterating through relevant bytes
            {
                byte reader = decoded[index++]; // Read next byte in sequence
                if ((reader & 0xC0) == 0xC0 && index < decoded.Count) // Check if 2-bit
                {
                    byteDuplicator = decoded[index++]; // Duplicates byte
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

            for (int i = 0; i < 256 * 256; i++)
            {
                image_colors[i] = colors[pixels[i]]; // Setting each color for each pixel in image
                int y = i / 256; // y-coordinate
                int x = i - (256 * y); // x-coordinate
                decodedImg.SetPixel(x, y, image_colors[i]); // Constructing image using acquired variables for RLE
            }

            return decodedImg;
        }

        public static string ByteArrayToBinaryString(byte[] byteArray)
        {
            StringBuilder binaryStringBuilder = new StringBuilder();

            foreach (byte b in byteArray)
            {
                // Convert each byte to a binary string with leading zeros
                string binaryString = Convert.ToString(b, 2).PadLeft(8, '0');
                binaryStringBuilder.Append(binaryString);
            }

            return binaryStringBuilder.ToString();
        }
    }

}
