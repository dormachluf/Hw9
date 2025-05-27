using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw9
{
    internal class Social : AppSystem , Iapp
    {

        bool is_corp;
        int score;
        public Social(bool is_corp,int score,string name, float price) : base(name, price)
        {
            this.is_corp = is_corp;
            Score = score;

        }
        public void AddVat(double tax)
        {
            Price *= (float)tax;
        }

        public override string AppSystemPurpose()
        {
            return "Far away and talking close";

        }
        public int Score
        {
            get => score;
            set {
                if (Score > 5 && Score < 1)
                    throw new ArgumentException("score has to be between 1 and 5.");
                score = value;
            }
        }
    }
    
}
