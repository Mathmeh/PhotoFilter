using System.ComponentModel;
using System.Drawing;
using static System.Math;

namespace PhotoFilter
{
    public class CPUConvolution
    {
        public static Bitmap Apply(Bitmap image, float[,] kernel, double div)
        {

            int filterWidth = kernel.GetLength(0);
            int filterHeight = kernel.GetLength(1);
            int width = image.Width;
            int height = image.Height;

            //create custom bitmap in order to make faster set and getpixel 
            var customBitmap = new DirectBitmap(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    customBitmap.SetPixel(x, y, image.GetPixel(x, y));
                }
            }

            float[,] filter = kernel;


            double bias = 0.0;

            Color[,] result = new Color[image.Width, image.Height];

            // Fill the color array with the new  color values.
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;

                    for (int filterX = 0; filterX < filterWidth; filterX++)
                    {
                        for (int filterY = 0; filterY < filterHeight; filterY++)
                        {
                            int imageX = (x - filterWidth / 2 + filterX + width) % width;
                            int imageY = (y - filterHeight / 2 + filterY + height) % height;

                            red += customBitmap.GetPixel(imageX, imageY).R * filter[filterY, filterX];
                            green += customBitmap.GetPixel(imageX, imageY).G * filter[filterY, filterX];
                            blue += customBitmap.GetPixel(imageX, imageY).B * filter[filterY, filterX];
                        }
                    }

                    int r = Min(Max((int)(div * red), 0), 255);
                    int g = Min(Max((int)(div * green), 0), 255);
                    int b = Min(Max((int)(div * blue), 0), 255);

                    result[x, y] = Color.FromArgb(r, g, b);
                }
            }

            Bitmap resultBMP = new Bitmap(width, height);
            // Update the image with the sharpened pixels.
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    resultBMP.SetPixel(x, y, result[x, y]);
                }
            }

            return resultBMP;
        }

        private static Bitmap ByteToImage(byte[] byteArray)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));

            Bitmap bitmap1 = (Bitmap)tc.ConvertFrom(byteArray);
            return bitmap1;
        }

    }
}