using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Petrofsky.Photography.LUTGenerator.Graphics
{
    /// <summary>
    /// An image consisting of square tiles rather than pixels.  Currently only supports 24-bit RGB.
    /// </summary>
    public class TiledImage
    {
        /// <summary>
        /// Create a new instance with black tiles.
        /// </summary>
        /// <param name="tileSize">Length of each side of a tile.</param>
        /// <param name="columns">Number of tiles left-right.</param>
        /// <param name="rows">Number of tiles up-down.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public TiledImage(int tileSize, int columns, int rows)
        {
            Validation.CheckInteger("blockSize", tileSize, 1);
            Validation.CheckInteger("columns", columns, 1);
            Validation.CheckInteger("rows", rows, 1);

            image = new Bitmap(columns *tileSize, rows * tileSize, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Width = columns;
            Height = rows;
            TileSize = tileSize;

            Reset();
        }

        /// <summary>
        /// Load a tiled image with a known number of tiles on the x-y axis from disk.
        /// The tiles don't have to be uniform, in order to support altered references.
        /// @todo Check file type and pixel format.
        /// @todo Deal with possible memory leaks from not disposing images on error (not just in this method).
        /// </summary>
        /// <param name="filename">The file to load.</param>
        /// <param name="columns">Number of tiles left-right.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public TiledImage(string filename, int columns)
        {
            Validation.CheckString("filename", filename);
            Validation.CheckInteger("columnWidth", columns, 1);

            try
            {
                Image image = Bitmap.FromFile(filename);
                this.image = new Bitmap(image);

                if (this.image.Width % columns != 0)
                    throw new ArgumentException("Image width is not divisible by " + columns.ToString() + ".", "columns");
                TileSize = this.image.Width / columns;
                Width = this.image.Width / TileSize;

                if (this.image.Height % TileSize != 0)
                    throw new ArgumentException("Image height is not divisible by " + TileSize.ToString() + ".", "Tile Size");
                Height = this.image.Height / TileSize;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Bad image file: " + e.Message, e);
            }
        }

        /// <summary>
        /// Reset all tiles to black.
        /// </summary>
        /// <exception cref="System.InvalidOperationException"></exception>
        public void Reset()
        {
            Reset(Color.Black);
        }

        /// <summary>
        /// Reset all tiles to a color.
        /// </summary>
        /// <param name="color">The color to use.</param>
        /// <exception cref="System.InvalidOperationException"></exception>
        public void Reset(Color color)
        {
            image.Fill(color);
        }

        /// <summary>
        /// Set a tile to a color.
        /// </summary>
        /// <param name="x">The 0-based tile index left-right.</param>
        /// <param name="y">The 0 -based tile index top-bottom.</param>
        /// <param name="color">The new color for the tile.</param>
        /// <exception cref="System.ArgumentOufOfRangeException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public void SetTile(int x, int y, Color color)
        {
            Validation.CheckInteger("x", x, 0, Width-1);
            Validation.CheckInteger("y", y, 0, Height - 1);

            image.FillRectangle(color, x * TileSize, y * TileSize, TileSize, TileSize);
        }

        /// <summary>
        /// Get the average color of a tile.
        /// </summary>
        /// <param name="x">The 0-based tile index left-right.</param>
        /// <param name="y">The 0 -based tile index top-bottom.</param>
        /// <returns>The average color.</returns>
        /// <exception cref="System.ArgumentOufOfRangeException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public Color GetTile(int x, int y)
        {
            Validation.CheckInteger("x", x, 0, Width - 1);
            Validation.CheckInteger("y", y, 0, Height - 1);

            return image.GetAverage(x * TileSize, y * TileSize, TileSize, TileSize);
        }

        /// <summary>
        /// Save the image to disk.
        /// </summary>
        /// <param name="filename">The filename to use.</param>
        /// <param name="format">The format for the file.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref=" System.Runtime.InteropServices.ExternalException"></exception>
        public void Save(string filename, System.Drawing.Imaging.ImageFormat format)
        {
            image.Save(filename,format);
        }

        /// <summary>
        /// Width of the image in tiles.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Height of the image in tiles.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Size of an edge of each tile in pixels.
        /// </summary>
        public int TileSize { get; private set; }

        #region Private Data
            private Bitmap image;
        #endregion
    }
}
