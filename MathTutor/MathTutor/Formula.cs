using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTutor
{
    public class Formula
    {
        public string Name { get; set; }
        public string CorrectAnswer { get; set; }

        public Formula(string name, string correctAnswer)
        {
            Name = name;
            CorrectAnswer = correctAnswer;
        }
    }
}
