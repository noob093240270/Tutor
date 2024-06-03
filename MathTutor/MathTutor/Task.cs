using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTutor
{
    internal class Task
    {
        public string Question {  get; set; }
        public string Answer { get; set; }

        public Task(string quest , string ans)
        {
            this.Question = quest;
            this.Answer = ans;
        }
        public string GetHelp()
        {
            return "Ответ начинается с : " + this.Answer[0];
        }
    }
}
