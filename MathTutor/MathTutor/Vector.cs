using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTutor
{
    internal class Vector
    {

        public double x;
        public double y;

        public double Length
        {
            get
            {
                return Math.Sqrt(x * x + y * y);
            }
        }

        public Vector(Point p1, Point p2)
        {
            x = p2.X - p1.X;
            y = p2.Y - p1.Y;
        }


        static public bool CheckScalProd(Vector v1, Vector v2)
        {
            return (v1.x + v2.x) + (v1.y + v2.y) == 0;
        }
    }
}
