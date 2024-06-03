using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTutor
{
    internal class Rectangle
    {

        private Point a; private Point b; private Point c; private Point d;

        public Point centre { get; set; }

        private Vector[] vectors;
        public Vector[] Vectors
        {
            get { return vectors; }
            set
            {
                if (vectors != null && vectors.Length == 4)
                {
                    if (Vector.CheckScalProd(vectors[0], vectors[3]) && Vector.CheckScalProd(vectors[1], vectors[2]) && vectors[0].Length == vectors[2].Length && vectors[1].Length == vectors[3].Length)
                    {
                        vectors = value;
                    }
                }
            }
        }

        public Rectangle(Point a, Point b, Point c, Point d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            var v1 = new Vector(a, b);
            var v2 = new Vector(b, c);
            var v3 = new Vector(c, d);
            var v4 = new Vector(d, a);
            vectors = new Vector[] {v1,v2,v3,v4 };
            this.centre = new Point((a.X+c.X)/2, (a.Y + c.Y) / 2);

        }

        // Определение площади и периметра прямоугольника

        public void PrintPS()
        {
            var p = vectors[0].Length * 2 + vectors[1].Length * 2;
            var s = vectors[0].Length * vectors[1].Length;
            Console.WriteLine($"Периметр: {p} \nПлощадь: {s}\n");
        }


        // Увеличение высоты и ширины прямоугольника на заданные коэффициенты

        public void ChangeWH(double changeHigth, double changeWidth)
        {
            foreach (var vector in vectors)
            {
                if (vector.x == 0)
                {
                    if (vector.y < 0) { vector.y -= changeHigth; continue; }
                    vector.x = 0;
                    vector.y += changeHigth;
                    //continue;
                }
                else if (vector.y == 0)
                {
                    if (vector.x < 0) { vector.x -= changeWidth; continue; }
                    vector.x += changeWidth;
                    vector.y = 0;
                    //continue;
                }
                
                //vector.x = double.Round(vector.x);
                
                //vector.y = double.Round(vector.y);
            }
            centre.X += changeWidth/2;
            centre.Y += changeHigth/2;

        }




    }
}
