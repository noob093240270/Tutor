using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTutor
{
    internal class Theorema
    {
        public string Condition {  get; set; }
        public string Conclusion { get; set; }
        public string Proof { get; set; }  
        public string Name { get; set; }
        public Theorema(string condition , string coclusion , string proof,string Name) 
        {
            this.Condition = condition;
            this.Conclusion = coclusion;
            this.Proof = proof;
            this.Name = Name;
        }
    }
}
