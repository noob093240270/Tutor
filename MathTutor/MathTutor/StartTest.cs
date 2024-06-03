
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTutor
{
    public class StartTest
    {
        public void RunTest() 
        {
            var Generate1 = new GenerateVariants();
            bool exit = false;
            while(!exit)
            {
                Console.WriteLine("Меню \"Проверка Знаний\"");
                Console.WriteLine("1. Загрузить банк заданий ->");
                Console.WriteLine("2. Сохранить варианты в файл ->");
                Console.WriteLine("3. Сгенерировать вариант ->");
                Console.WriteLine("4. Начать проверку->");
                Console.WriteLine("5. Выйти из тренажёра D:(((");
                Console.Write("Введите номер вашего ответа:");
                string? choice = Console.ReadLine();
                List<List<Task>> vars = new List<List<Task>>();
                switch (choice)
                {

                    case "1":
                        Console.WriteLine("Введите название файла :");
                        string s1 = Console.ReadLine();
                        Generate1.InitBank(s1);
                        break;
                    case "2":
                        Generate1.SaveVars(vars);
                        break;
                    case "3":
                        Console.WriteLine("Введите количество заданий и вариантов :");
                        string tc1 = Console.ReadLine();
                        string vc1 = Console.ReadLine();
                        vars = Generate1.Variants(int.Parse(tc1), int.Parse(vc1));
                        break;
                    case "4":
                        Console.WriteLine($"Введите вариант,который хотите проверить ,доступно {vars.Count} вариантов :");
                        string s4 = Console.ReadLine();
                        Generate1.CheckAnswer(vars[int.Parse(s4)-1]);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Такого варианта ответа нет. Попробуйте ещё раз:");
                        break;
                }
            }
            
            
        }
    }
}
