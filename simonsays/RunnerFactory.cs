using simonsays.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simonsays
{
    internal class RunnerFactory
    {
        public static IRunner getRunner(string choiceID)
        {
            switch (choiceID)
            {
                case "1":
                    return new GameRunner();
                default:
                    return new NullRunner();
            }

        }
    }
}
