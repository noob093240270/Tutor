using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTutor
{
    public class TheoryMemorizing
    {
        /// <summary>
        /// Запускает тренировку "Зубрёжка теории".
        /// </summary>
        public void Workout()
        {
            Simulator simulator = new Simulator();

            simulator.LoadFormulasFromFile("PartC/formulas.txt");

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nМеню \"Зазубривания теории\":");
                Console.WriteLine("1. Начать тренировку ->");
                Console.WriteLine("2. Посмотреть статистику неправильных ответов ->");
                Console.WriteLine("3. Вывести формулу с наиболее короткой записью и теорему с самым длинным доказательством ->");
                Console.WriteLine("4. Выйти из тренажёра :((..");
                Console.Write("Введите номер вашего ответа: ");

                string? choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        simulator.Training();
                        break;
                    case "2":
                        Console.WriteLine("Какое количество последних тренировок учитывать?");
                        int quantityOfTrainings = int.Parse(Console.ReadLine());
                        simulator.DisplayIncorrectAnswersStatistics(quantityOfTrainings);
                        break;
                    case "3":
                        simulator.DisplayShortFormulaAndLongProof();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Такого варианта ответа нет. Попробуйте ещё раз:");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
