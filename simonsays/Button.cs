using simonsays.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simonsays
{
    internal class Button
    {
        public int numberColor { get; set; }
        public bool blockedButton { get; set; }
        public Verify verify;
        public SimonSays simonSays;
       


        public Button(SimonSays simonSays)
        {
            this.blockedButton = true;
            this.verify = new Verify(simonSays);
            this.simonSays = simonSays;
        }

        public Button(int color)
        {
            this.numberColor = color;
            this.blockedButton = true;
        }

        public void ButtonClick(int button)
        {
            if (!this.blockedButton)
            {
                //this.validateDateChosenColor(button);
                this.verify.ValidateDateChosenColor(button);
            }

        }

    }
}
