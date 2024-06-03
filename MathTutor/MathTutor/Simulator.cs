using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MathTutor
{
    public class Simulator
    {
        private Dictionary<string, List<Formula>> _formulaBank;
        private Dictionary<string, int> _incorrectAnswers;
        private Dictionary<string, int> _correctAnswers;

        //поля для теорем
        private Dictionary<string,List<Theorema>> _theoremBank;


        /// <summary>
        /// Конструктор класса. Создаёт обхъект класса Simulator без каких либо входных параметров.
        /// </summary>
        public Simulator() 
        {
            _formulaBank = new Dictionary<string, List<Formula>>();
            _incorrectAnswers = new Dictionary<string, int>();
            _correctAnswers = new Dictionary<string, int>();
            _theoremBank = new Dictionary<string, List<Theorema>>();
        }

        /// <summary>
        /// Отдельный метод для добавления формул к определённой теме.
        /// </summary>
        /// <param name="topic">Тема формулы.</param>
        /// <param name="formula">Сама формула (в виде объекта соответствующего класса).</param>
        private void AddFormula(string topic, Formula formula)
        {
            if (!_formulaBank.ContainsKey(topic))
            {
                _formulaBank[topic] = new List<Formula>();
                _correctAnswers[topic] = 0;
                _incorrectAnswers[topic] = 0;
            }
            _formulaBank[topic].Add(formula);
        }

        private void AddTheorem(string topic,Theorema theorem) 
        { 
            if(!_theoremBank.ContainsKey(topic))
            {
                _theoremBank[topic] = new List<Theorema>();

            }
            _theoremBank[(topic)].Add(theorem);
        }

        /// <summary>
        /// Метод для загрузки формул из файлов.
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        public void LoadFormulasFromFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] words = line.Split(',');
                    string topic = words[0];
                    string name = words[1];
                    string correctAnswer = words[2];

                    AddFormula(topic, new Formula(name, correctAnswer));
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не был найден(.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Во время загрузки формул из файла произошла непредвиденная ошибка {0}", ex.Message);
            }
        }

        //Метод для загрузки теорем из файлов
        public void LoadTheoremFromFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] words = line.Split(',');
                    string topic = words[0];
                    string name = words[1];
                    string cond = words[2];
                    string conc = words[3];
                    string proof= words[4];

                    AddTheorem(topic, new Theorema(cond,conc,proof,name));
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не был найден(.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Во время загрузки формул из файла произошла непредвиденная ошибка {0}", ex.Message);
            }
        }

        /// <summary>
        /// Класс для тренировки.
        /// </summary>
        /// <param name="topic">Тема для тренировки.</param>
        public void Training()
        {
            Console.WriteLine("Добро пожаловать в Тренажёр формул!");
            Console.WriteLine("Выберите что вы хотите вспомнить теоремы или формулы(1,2):");
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    foreach (string topic in _formulaBank.Keys)
                        Console.WriteLine(topic);

                    Console.WriteLine("Введите выбранную тему (или \"Выход\", если хотите закончить тренировку):");
                    string? selectedTopic = Console.ReadLine();

                    if (selectedTopic.ToLower().Trim() == "выход")
                    {
                        Console.WriteLine("Мы будем вас ждать, возвращайтесь скорее!!");

                    }

                    if (!_formulaBank.ContainsKey(selectedTopic))
                    {
                        Console.WriteLine("Тема не найдена.");
                        return;
                    }

                    List<Formula> formulas = _formulaBank[selectedTopic];
                    bool EverythingWasMemorized = false;

                    Random rand = new Random();

                    while (!EverythingWasMemorized)
                    {
                        foreach (Formula formula in formulas)
                        {
                            Console.WriteLine("Название формулы: {0}.", formula.Name);
                            Console.WriteLine("Запишите формулу на черновике.");
                            Console.WriteLine("Когда будете готовы, нажмите \"Enter\".");
                            Console.WriteLine("...");
                            Console.ReadKey();
                            Console.WriteLine();
                            Console.WriteLine("Правильный ответ: {0}", formula.CorrectAnswer);
                            Console.WriteLine("Верно ли вы всё записали?");
                            Console.WriteLine("(Да/Нет): ");
                            Console.WriteLine();
                            string? answer = Console.ReadLine().ToLower().Trim();

                            if (answer == "нет")
                            {
                                if (!_correctAnswers.ContainsKey(selectedTopic))
                                    _incorrectAnswers[selectedTopic] = 0;
                                _incorrectAnswers[selectedTopic]++;

                                Console.WriteLine("Ничего страшного, мы ещё вернёмся к этой формуле позже.");
                            }
                            else if (answer == "да")
                            {
                                if (!_correctAnswers.ContainsKey(selectedTopic))
                                    _correctAnswers[selectedTopic] = 0;
                                _correctAnswers[selectedTopic]++;

                                Console.WriteLine("Здорово! Тогда движемся дальше!!");
                            }
                            else
                            {
                                Console.WriteLine("Странно, но такого ответа нет(... Продолжим дальше!");
                                continue;
                            }
                        }

                        if (_incorrectAnswers.Any(key => formulas.Any(formula => formula.Name == key.Key && key.Value > 0)))
                        {
                            Console.WriteLine("Давайте попробуем ещё раз, чтобы точно запомнить все формулы!");
                            _incorrectAnswers.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Вы всё запомнили! Вы молодец!!");
                            EverythingWasMemorized = true;
                        }
                    }
                    break;
                case "2":
                    foreach (string topic in _theoremBank.Keys)
                        Console.WriteLine(topic);
                    Console.WriteLine("Введите выбранную тему (или \"Выход\", если хотите закончить тренировку):");
                    string? selectedtheoremTopic = Console.ReadLine();

                    if (selectedtheoremTopic.ToLower().Trim() == "выход")
                    {
                        Console.WriteLine("Мы будем вас ждать, возвращайтесь скорее!!");
                    }
                    if (!_theoremBank.ContainsKey(selectedtheoremTopic))
                    {
                        Console.WriteLine("Тема не найдена.");
                        return;
                    }
                    List<Theorema> theorems = _theoremBank[selectedtheoremTopic];
                    foreach (var theorem in theorems)
                    {
                        Console.WriteLine($"Название теоремы : {theorem.Name} ");
                        Console.WriteLine($"Введите услолвие теоремы : ");
                        string cond = Console.ReadLine();
                        if (theorem.Condition != cond)
                        {
                            Console.WriteLine("Условие теоремы не верно!");
                        }
                        else
                        {
                            Console.WriteLine($"Введите заключение теоремы : ");
                            string conc = Console.ReadLine();
                            if(theorem.Conclusion != conc)
                            {
                                Console.WriteLine("Заключение теоремы не верно!");
                            }
                            else
                            {
                                Console.WriteLine($"Введите доказательство теоремы : ");
                                string proof = Console.ReadLine();
                                if (theorem.Proof != proof)
                                {
                                    Console.WriteLine("Доказательство теоремы не верно!");
                                }
                                else
                                {
                                    Console.WriteLine($"Вы успешно вспомнили теорему {theorem.Name}");
                                }
                            }
                        }
                    }
                    

                        break;
                default:
                    Console.WriteLine("Такого варианта ответа нет. Попробуйте ещё раз:");
                    break;
            }
            
        }


        public void DisplayShortFormulaAndLongProof()
        {
            Formula shortestFormula = null;
            Theorema longestProofTheorem = null;

            foreach (var topic in _formulaBank.Values)
            {
                foreach (var formula in topic)
                {
                    if (shortestFormula == null || formula.CorrectAnswer.Length < shortestFormula.CorrectAnswer.Length)
                    {
                        shortestFormula = formula;
                    }
                }
            }
            foreach (var topic in _theoremBank.Values)
            {
                foreach (var theorem in topic)
                {
                    if (longestProofTheorem == null || theorem.Proof.Length > longestProofTheorem.Proof.Length)
                    {
                        longestProofTheorem = theorem;
                    }
                }
            }

            if (shortestFormula != null)
            {
                Console.WriteLine("Формула с самой короткой записью : ");
                Console.WriteLine($"Название : {shortestFormula.Name}");
                Console.WriteLine($"Запись : {shortestFormula.CorrectAnswer}");
            }
            else
            {
                Console.WriteLine("Нет формул в банке");
            }

            if (longestProofTheorem != null)
            {
                Console.WriteLine("Теорема с самым длинным доказательством:");
                Console.WriteLine($"Название: {longestProofTheorem.Name}");
                Console.WriteLine($"Условие: {longestProofTheorem.Condition}");
                Console.WriteLine($"Заключение: {longestProofTheorem.Conclusion}");
                Console.WriteLine($"Доказательство: {longestProofTheorem.Proof}");
            }
            else
            {
                Console.WriteLine("Нет теорем в банке");
            }
        }
        /// <summary>
        /// Выводит статистку неправильных ответов за квведённое пользователем 
        /// </summary>
        /// <param name="numberOfTrainings"></param>
        public void DisplayIncorrectAnswersStatistics(int numberOfTrainings)
        {
            Console.WriteLine("Статистика неправильных ответов");
            foreach (var topic in _incorrectAnswers)
            {
                if (numberOfTrainings > 0)
                {
                    double errorRate = topic.Value / numberOfTrainings * 100;
                    Console.WriteLine($"Тема: {topic.Key}, Количество неверных ответов: {topic.Value}, Процент ошибок: {errorRate}%");
                }
                else
                {
                    Console.WriteLine($"Тема: {topic.Key}, Количество неверных ответов: {topic.Value}, Процент ошибок: 0%");
                }
            }
        }
    }
}