using simonsays.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simonsays
{
    internal class GameRunner : IRunner
    {
        public void run()
        {
            Game game = new Game();
            game.run();

        }
    }
}
