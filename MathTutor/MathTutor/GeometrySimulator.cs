using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTutor
{
    public class GeometrySimulator
    {
        public void RunGeometry()
        {
            var rec1 = new Rectangle(new Point(2,6), new Point(6,6), new Point(6,3), new Point(2,3));
            var rec2 = new Rectangle(new Point(0,5), new Point(6,-4), new Point(0,-8), new Point(-6,1));
            var simulator = new GeoSimulator(new Rectangle[] { rec1,rec2 });
            Console.WriteLine("Вывод всех прямоугольников на плоскость:\n");
            simulator.PrintRectangles();
            Console.WriteLine("Вывод периметра и площади:\n");
            foreach (var rec in simulator.rectangles)
            {
                rec.PrintPS();
            }
            Console.WriteLine("Изменение прямоугольников по длине и ширине по 3 единицы соотвественно:\n");
            rec1.ChangeWH(3,3);

            simulator.PrintRectangles();

            /*Predicate<double> moreThen = (double x) => x >= 4;
            foreach (var rec in simulator.rectangles)
            {
                
            }
            var predArr = simulator.GetRectanglesPred(moreThen, rec1.centre.X);
            foreach (var item in predArr)
            {
                Console.WriteLine(item.centre.ToString());
            }*/
        }
    }
}
