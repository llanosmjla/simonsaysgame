using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simonsays;

namespace simonsays
{
    internal class Verify
    {
        public SimonSays simonSays;
        public int item { get; set; }
        public Button button;
        public Verify(SimonSays simonSays)
        {
            this.simonSays = simonSays;
        }

        public Verify(Button button)
        {
            this.button = button;
        }
        public void ValidateDateChosenColor(int item)
        {
            
            if (this.simonSays.sequence[this.simonSays.userPosition] == item)
            {
                if (simonSays.round == simonSays.userPosition)
                {
                    simonSays.round++;
                    simonSays.speed = (int)(simonSays.speed / 1.02);
                    simonSays.IsGameOver();
                }
                else
                {
                    simonSays.userPosition++;
                }
            }
            else
            {
                simonSays.GameLost();
            }

        }
    }
}
