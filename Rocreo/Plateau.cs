using System;
using System.Collections.Generic;
using System.Drawing;

namespace Recreo
{
    public class Plateau
    {
        public Point UpperRight { get; }
        public Point LowerLeft { get; }

        public Plateau(List<int> coordinate)
        {
            if (coordinate.Count != 2)
              throw new ArgumentException("Plateau's coordinates is not in the correct format.");
            UpperRight = new Point(coordinate[0], coordinate[1]);
            LowerLeft = new Point(0,0);
        }
    }
}