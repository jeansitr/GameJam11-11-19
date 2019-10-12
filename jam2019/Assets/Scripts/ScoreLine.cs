using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class ScoreLine
    {
        public string Name { get; set; }
        public double Score { get; set; }

        public ScoreLine(string name, double score)
        {
            Name = name;
            Score = score;
        }
    }
}
