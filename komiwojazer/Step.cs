using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace komiwojazer
{
    class Step
    {
        public double GetLength(Point sourcePoint, Point destPoint)
        {
            return Math.Sqrt(Math.Pow(sourcePoint.x- destPoint.x, 2) +Math.Pow(sourcePoint.y- destPoint.y, 2));
        }
    }
}
