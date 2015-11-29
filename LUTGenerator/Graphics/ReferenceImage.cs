using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Petrofsky.Photography.LUTGenerator.Graphics
{
    /// <summary>
    /// Reference image representing color blocks for all the lattice points for a 3D LUT.
    /// Only supports 8-bit without color profile currently due to GDI+ limitations.
    /// Since the generated samples are linear with respect to the RGB components, they can be assigned any color profile and will act as if they are native to that profile.
    /// @todo Consider inheriting this from TiledImage and creating the image somewhere other than the constructor.
    /// @todo Implement IDispoable and provide proper resource releasing.
    /// </summary>
    public class ReferenceImage
    {
        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="dimension">Number of lattice points per dimension in the cube representing the color space.  Minimum is 2.  Maximum is 255.</param>
        /// <param name="blockSize">Length in pixels of 1 side of the sample block for each color in the reference file.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public ReferenceImage(int dimension, int blockSize)
        {
            Validation.CheckInteger("dimension", dimension, 2, 255);
            Validation.CheckInteger("blockSize", blockSize, 1);

            Dimension = dimension;
            BlockSize = blockSize;
            this.latticeCoefficient = (float)255 / (dimension - 1);

            int blocks = dimension*dimension*dimension;  //probably faster than System.Math.Pow
            int rows = (int)Math.Ceiling((float)blocks / 8);

            image = new TiledImage(blockSize, 8, rows);

            generateSamples();
        }

        /// <summary>
        /// Load a reference image from disk.
        /// </summary>
        /// <param name="filename">Name of the image file to load.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public ReferenceImage(string filename)
        {
            Validation.CheckString("filename", filename);

            image = new TiledImage(filename,8);
            BlockSize = image.TileSize;

            int totalTiles = image.Width * image.Height;
            Dimension = (int)Math.Floor(Math.Pow(totalTiles, (double)1 / 3));
            latticeCoefficient = (float)255 / (Dimension - 1);
        }

        /// <summary>
        /// Save the image into an 8-bit tiff file.
        /// </summary>
        /// <param name="filename">The tiff file to create/overwrite.</param>
        public void Save(string filename)
        {
            image.Save(filename, System.Drawing.Imaging.ImageFormat.Tiff);
        }

        /// <summary>
        /// Convert lattice indices to coordinates within the tiled image (internal helper only).
        /// WARNING: No validation is done to keep the overhead down.
        /// </summary>
        /// <param name="redIndex">Red lattice index.</param>
        /// <param name="greenIndex">Green lattice index.</param>
        /// <param name="blueIndex">Blue lattice index.</param>
        /// <returns>Tuple(tile x, tile y)</returns>
        private Tuple<int, int> getTileCoordinates(int redIndex, int greenIndex, int blueIndex)
        {
            int block = blueIndex * Dimension*Dimension + greenIndex * Dimension + redIndex;
            int row, col;

            row = Math.DivRem(block, 8, out col);

            return new Tuple<int, int>(col,row);
        }

        /// <summary>
        /// Read the average color of a sample block.
        /// </summary>
        /// <param name="redIndex">Red lattice index.</param>
        /// <param name="greenIndex">Green lattice index.</param>
        /// <param name="blueIndex">Blue lattice index.</param>
        /// <returns>The average color of the sample block.</returns>
        /// <exception cref="System.ArgumentOufOfRangeException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public Color GetSample(int redIndex, int greenIndex, int blueIndex)
        {
            Validation.CheckInteger("redIndex", redIndex, 0, Dimension);
            Validation.CheckInteger("greenIndex", greenIndex, 0, Dimension);
            Validation.CheckInteger("blueIndex", blueIndex, 0, Dimension);

            var ret = getTileCoordinates(redIndex, greenIndex, blueIndex);
            return image.GetTile(ret.Item1, ret.Item2);
        }

        /// <summary>
        /// Set the color of a sample block.
        /// </summary>
        /// <param name="redIndex">Red lattice index.</param>
        /// <param name="greenIndex">Green lattice index.</param>
        /// <param name="blueIndex">Blue lattice index.</param>
        /// <param name="color">The color to set.</param>
        /// <exception cref="System.ArgumentOufOfRangeException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public void SetSample(int redIndex, int greenIndex, int blueIndex, Color color)
        {
            Validation.CheckInteger("redIndex", redIndex, 0, Dimension);
            Validation.CheckInteger("greenIndex", greenIndex, 0, Dimension);
            Validation.CheckInteger("blueIndex", blueIndex, 0, Dimension);

            setSample(redIndex, greenIndex, blueIndex, color);
        }

        /// <summary>
        /// Set the color of a sample block (non-validated for internal use).
        /// </summary>
        /// <param name="redIndex">Red lattice index.</param>
        /// <param name="greenIndex">Green lattice index.</param>
        /// <param name="blueIndex">Blue lattice index.</param>
        /// <param name="color">The color to set.</param>
        /// <exception cref="System.ArgumentOufOfRangeException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public void setSample(int redIndex, int greenIndex, int blueIndex, Color color)
        {
            var ret = getTileCoordinates(redIndex, greenIndex, blueIndex);
            image.SetTile(ret.Item1, ret.Item2, color);
        }

        /// <summary>
        /// Calculate a single channel value based on the parameters of the lattice.
        /// WARNING: Not validated since it's private and will be called a lot.
        /// </summary>
        /// <param name="latticeIndex">The lattice point to calculate.</param>
        /// <returns>The channel value.</returns>
        private int calculateChannelValue(int latticeIndex)
        {
            return (int)Math.Round(latticeCoefficient * latticeIndex);
        }

        /// <summary>
        /// Calculate a color based on RGB lattice indices (0 to dimension-1).
        /// WARNING: Not validated since it's private an will be called a lot.
        /// </summary>
        /// <param name="redIndex">Red lattice index.</param>
        /// <param name="greenIndex">Green lattice index.</param>
        /// <param name="blueIndex">Blue lattice index.</param>
        /// <returns>The color value.</returns>
        private Color calculateColor(int redIndex, int greenIndex, int blueIndex)
        {
            return Color.FromArgb(calculateChannelValue(redIndex), calculateChannelValue(greenIndex), calculateChannelValue(blueIndex));
        }

        /// <summary>
        /// Render the samples in the tile image representing the lattice points.
        /// </summary>
        /// <exception cref="System.InvalidOperationException"></exception>
        private void generateSamples()
        {
            for (int b = 0; b < Dimension; b++)
                for (int g = 0; g < Dimension; g++)
                    for (int r = 0; r < Dimension; r++)
                    {
                        Color color = calculateColor(r, g, b);
                        setSample(r, g, b, color);
                    }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// @todo clean this up (coded at 3 AM after hours of coding) [maybe access the lut class directly in gui]
        public void CreateLUT(string filename, IFilter filter=null)
        {
            LookupTable table = new LookupTable(System.IO.Path.GetFileName(filename),Dimension, 255);

            for (int b = 0; b < Dimension; b++)
                for (int g = 0; g < Dimension; g++)
                    for (int r = 0; r < Dimension; r++)
                    {
                        Color color = GetSample(r, g, b);
                        if (filter != null)
                            color = filter.Filter(color);
                        table.AddSample(r, g, b, color.R, color.G, color.B);    ///@todo array indexing operator
                    }

            table.Save(filename);
        }

        /// <summary>
        /// Number of lattice points per dimension in the cube representing the color space.
        /// </summary>
        public int Dimension { get; private set; } //2 <= dimension <= 255

        /// <summary>
        /// Length in pixels of 1 side of the sample block for each color in the reference file.
        /// </summary>
        public int BlockSize { get; private set; }

        #region Private Data
            private float latticeCoefficient;

            private TiledImage image;
        #endregion
    }
}
