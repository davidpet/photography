using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Petrofsky.Photography.LUTGenerator.Graphics
{
    public interface IFilter
    {
        System.Drawing.Color Filter(System.Drawing.Color color);
    }
}
