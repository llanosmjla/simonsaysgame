using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simonsays
{
    internal class SequenceGenerator
    {
        SimonSays simonSays;
        public SequenceGenerator(SimonSays simonSays)
        {
            this.simonSays = simonSays;
        }

        public List<int> CreateSequence()
        {
            return Enumerable.Range(0, this.simonSays.totalRounds).Select(x => this.GetRandomColor()).ToList();
        }

        public int GetRandomColor()
        {
            Random rand = new Random();
            return rand.Next(0, 4);
        }
    }
}
