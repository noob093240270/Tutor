using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTutor
{
    internal class GenerateVariants
    {
        private List<Task> bank = new List<Task>();
        public GenerateVariants()
        {
            bank = new List<Task>();
        }
        public List<List<Task>> Variants(int tasks , int variants)
        {
            if(tasks > this.bank.Count)
            {
                throw new ArgumentException("Количество заданых вопросов больше чем имеется в банке!");
            }
            List<List<Task>> vars = new List<List<Task>>();
            Random r = new Random();
            for(int i = 0; i < variants; i++)
            {
                List<Task> variant = new List<Task>();
                while(variant.Count <  tasks)
                {
                    int rt = r.Next(this.bank.Count );
                    Task task = bank[rt];
                    if (!variant.Contains(task))
                    {
                        variant.Add(task);
                    }
                }
                vars.Add(variant);
            }
            return vars;
        }
        public void InitBank(string fn)
        {
            using(StreamReader sr = new StreamReader(fn))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] part = line.Split(new char[] {';'});
                    string question = part[0];
                    string ans = part[1];
                    this.bank.Add(new Task(question,ans));
                }
            }
        }
        public void SaveVars(List<List<Task>> vars)
        {
            for(int i = 0; i<vars.Count; i++)
            {
                using(StreamWriter sw = new StreamWriter("Variant " + i + ".txt"))
                {
                    foreach(Task task in vars[i])
                    {
                        sw.WriteLine(task.Question+";"+task.Answer);
                    }
                }
            }
        }
        public void CheckAnswer(List<Task> variant)
        {
            Dictionary<string,string> answer = new Dictionary<string,string>();
            foreach(Task task in variant)
            {
                int c = 0;
                Console.WriteLine("Вопрос : " + task.Question);
                Console.WriteLine("Введите ответ на вопрос : ");
                while(c < 2)
                {
                    string ans = Console.ReadLine();
                    if (ans == task.Answer)
                    {
                        c = 2;
                        Console.WriteLine("Ответ учтен.");
                        answer.Add("Вопрос " + task.Question, "Ваш ответ " + ans + " оказался верным!" );
                    }
                    else
                    {
                        if (c < 1)
                        {
                            Console.WriteLine("Ответ не верный,воспользуйтесь подсказкой : ");
                            Console.WriteLine(task.GetHelp());
                        }
                        else
                        {
                            Console.WriteLine("Ответ учтен.");
                            answer.Add("Вопрос " + task.Question, "Ваш ответ " + ans + " оказался неверным! Правильный ответ : "+ task.Answer);
                        }
                        c++;
                    }
                }
                Console.WriteLine();
            }
            foreach(var res in answer)
            {
                Console.WriteLine(res.Key);
                Console.WriteLine(res.Value);
                Console.WriteLine();
            }
        }
    }
}
