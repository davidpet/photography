using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Petrofsky.Photography.LUTGenerator.Graphics
{
    /// <summary>
    /// Extensions for System.Drawing.Image that get rid of the nastiness of having to create a Graphics object.
    /// @todo Possibly move these to Bitmap instead.
    /// </summary>
    public static class ImageExtensions
    {
        /// <summary>
        /// Fill a rectangle within the image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="color">The color with which to fill the rectangle.</param>
        /// <param name="x">X-coordinate of rectangle origin.</param>
        /// <param name="y">Y-Coordinate of rectangle origin.</param>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public static void FillRectangle(this Image image, Color color, int x, int y, int width, int height)
        {
            Validation.CheckObject("image", image);
            //Validation.CheckInteger("x", x, 0, image.Width - 1);
            //Validation.CheckInteger("y", y, 0, image.Height - 1);
            //Validation.CheckInteger("width", width, 0, image.Width - 1 - x);
            //Validation.CheckInteger("height", height, 0, image.Height - 1 - y);

            System.Drawing.Graphics graphics;
            try
            {
                graphics = System.Drawing.Graphics.FromImage(image);
            }
            catch (System.Exception e)
            {
                throw new InvalidOperationException("Error obtaining graphics handle: " + e.Message, e);
            }

            graphics.FillRectangle(new SolidBrush(color), x, y, width, height);

            graphics.Dispose();
        }

        /// <summary>
        /// Fill the whole image with a color.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="color">The color with which to fill the image.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public static void Fill(this Image image, Color color)
        {
            image.FillRectangle(color, 0, 0, image.Width, image.Height);
        }

        /// <summary>
        /// Get the average color of a rectangle within an image (must be in bounds).  Image must be a Bitmap due to weird GDI+ abstraction (sorry...I don't like it either).
        /// WARNING: Assumes 24-bit RGB pixels.
        /// </summary>
        /// <param name="image">The image (must be castable to Bitmap).</param>
        /// <param name="x">X-coordinate of rectangle origin.</param>
        /// <param name="y">Y-coordinate of rectangle origin.</param>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// @todo Figure out why the faster code doesn't work and replace the slower code
        public static Color GetAverage(this Image image, int x, int y, int width, int height)
        {
            Validation.CheckObject("image", image);
            Validation.CheckInteger("x", x, 0, image.Width - 1);
            Validation.CheckInteger("y", y, 0, image.Height - 1);
            Validation.CheckInteger("width", width, 0, image.Width - x);
            Validation.CheckInteger("height", height, 0, image.Height - y);
            
            if (!(image is Bitmap))
                throw new ArgumentException("Image must be castable to System.Drawing.Bitmap.", "image");
            Bitmap bitmap = (Bitmap)image;
            /*
            //obtain a copy of the pixels
            byte[] buffer;
            try
            {
                BitmapData data = bitmap.LockBits(new Rectangle(x, y, width, height), System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                int bytes = width*3*height*3;
                buffer = new byte[bytes];
                IntPtr ptr = data.Scan0;

                System.Runtime.InteropServices.Marshal.Copy(data.Scan0, buffer, 0, bytes);
                bitmap.UnlockBits(data);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("An error occurred obtaining pixel data: " + e.Message, e);
            }

            //calculate the average
            return Color.FromArgb(calculateAverage(buffer, 2), calculateAverage(buffer, 1), calculateAverage(buffer, 0));
             */  
            long redSum = 0;
            long greenSum = 0;
            long blueSum = 0;
            
            for (int i = x; i < x+width; i++)
                for (int j = y; j < y + width; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    redSum += color.R;
                    greenSum += color.G;
                    blueSum += color.B;
                }

            return Color.FromArgb((int)Math.Round((float)redSum / (width * height)), (int)Math.Round((float)greenSum / (width * height)), (int)Math.Round((float)blueSum / (width * height)));
        }

        /// <summary>
        /// Calculate average value of a channel within a buffer of pixels.  Helper method for GetAverage().
        /// WARNING: Does not perform validation.
        /// </summary>
        /// <param name="buffer">Buffer of bytes (1 byte per subpixel).</param>
        /// <param name="offset">Offset of channel to calculate (assumed to be 3 channels).</param>
        /// <returns>The average value.</returns>
        private static int calculateAverage(byte[] buffer, int offset)
        {
            long sum = 0;

            for (int i = offset; i < buffer.Length; i += 3)
                sum += buffer[i];

            return (int)Math.Round((float)sum / (buffer.Length / 3));
        }
    }
}
