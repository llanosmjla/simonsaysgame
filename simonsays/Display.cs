using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simonsays
{
    internal class Display
    {
        public string round { get; set; }
        public int commandStart { get; set; }

        public Display(int commandStart, string round)
        {
            this.commandStart = commandStart;
            this.round = round;
        }
    }
}
