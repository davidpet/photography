using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Petrofsky.Photography.LUTGenerator.Graphics
{
    /// <summary>
    /// @todo cleanup and document
    /// </summary>
    class LookupTable
    {
        public LookupTable(string title, int dimension, int maximum)
        {
            Title = title;
            Dimension = dimension;
            Maximum = maximum;

            red = new float[dimension, dimension, dimension];
            green = new float[dimension, dimension, dimension];
            blue = new float[dimension, dimension, dimension];
        }

        public void AddSample(int redIndex, int greenIndex, int blueIndex, int redValue, int greenValue, int blueValue)
        {
            //@todo validation

            red[redIndex, greenIndex, blueIndex] = ((float)redValue / Maximum);
            green[redIndex, greenIndex, blueIndex] = ((float)greenValue / Maximum);
            blue[redIndex, greenIndex, blueIndex] = ((float)blueValue / Maximum);
        }

        public void Save(string filename)
        {
            //@todo validatoin

            System.IO.StreamWriter writer = new System.IO.StreamWriter(filename, false, Encoding.ASCII);

            writer.WriteLine("TITLE " + Title);
            writer.WriteLine("");
            writer.WriteLine("LUT_3D_SIZE " + Dimension.ToString());
            writer.WriteLine("DOMAIN_MIN 0.0 0.0 0.0");
            writer.WriteLine("DOMAIN_MAX 1.0 1.0 1.0");
            writer.WriteLine("");

            for (int b = 0; b < Dimension; b++)
                for (int g = 0; g < Dimension; g++)
                    for (int r = 0; r < Dimension; r++)
                    {
                        writer.Write(string.Format("{0:0.00000}", red[r, g, b]));
                        writer.Write("\t");
                        writer.Write(string.Format("{0:0.00000}", green[r, g, b]));
                        writer.Write("\t");
                        writer.Write(string.Format("{0:0.00000}", blue[r, g, b]));
                        writer.WriteLine("");
                    }

            writer.Flush();
            writer.Close();
        }

        public string Title { get; private set; }

        public int Dimension { get; private set; }

        public int Maximum { get; private set; }

        private float[, ,] red;
        private float[,,] green;
        private float[,,] blue;
    }
}
