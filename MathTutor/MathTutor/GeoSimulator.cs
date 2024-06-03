using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTutor
{
    internal class GeoSimulator
    {
        private Point decCentre = new Point(0, 0);
        public Rectangle[] rectangles;

        public GeoSimulator(Rectangle[] rectangles)
        {
            this.rectangles = rectangles;
        }

        // Вывод на экран всех прямоугольников на плоскости

        public void PrintRectangles()
        {
            var k = 1;
            foreach (var rec in rectangles)
            {
                Console.WriteLine($"Координаты векторов прямоугольника №{k++}");
                foreach (var vector in rec.Vectors)
                {
                    Console.WriteLine($"({vector.x};{vector.y})");
                }
                Console.WriteLine($"Координаты центра: {rec.centre.ToString()}");;
            }
        }


        // Получение массива прямоугольников согласно заданному предикату
        /*
        public List<Rectangle> GetRectanglesPred(Predicate<double> pred, double n)
        {
            var ret = new List<Rectangle>();
            foreach (var rec in rectangles)
            {
                if (pred(n))
                {
                    ret.Add(rec);
                }
            }
            return ret;
        }*/


    }
}
