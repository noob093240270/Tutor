using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MathTutor
{
    public class RunMathTutor
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Рады приветствовать вас в программу по обучению математике \"MathHelp\"!");
            Console.WriteLine("\"MathHelp\": математика - это клёво!\n");
            Console.WriteLine("Введите ваше имя: ");
            string? userName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(userName))
                Console.WriteLine("Введите имя ещё раз:");
            Console.WriteLine($"\nПриятно познакомиться, {userName}!\n\n");
            
            GeometrySimulator geometrySimulator = new GeometrySimulator();
            StartTest startTest = new StartTest();
            TheoryMemorizing coach = new TheoryMemorizing();

            while (true) 
            {
                Console.WriteLine($"Вот чем вы можете здесь заняться, {userName}:\n");
                Console.WriteLine("Меню");
                Console.WriteLine("1. Симулятор геометрии ->");
                Console.WriteLine("2. Проверка знаний ->");
                Console.WriteLine("3. Зазубривание теории ->");
                Console.WriteLine("4. Выход( ->\n");

                Console.WriteLine($"Введите номер варианта вашего ответа:");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        geometrySimulator.RunGeometry();  
                        break;
                    case "2":
                        startTest.RunTest();
                        break;
                    case "3":
                        coach.Workout();
                        break;
                    case "4":
                        Console.WriteLine($"Возвращайтесь сюда скорее, {userName}!");
                        return;
                    default:
                        Console.WriteLine("Такого пункта меню нет, или мы плохо искали :((... Введите ещё раз:");
                        break;
                }
            }
            
        }
    }
}
