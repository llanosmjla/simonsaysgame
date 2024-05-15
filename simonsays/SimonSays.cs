using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simonsays
{
    internal class SimonSays
    {
        // Create the method for generating the random sequence of colors

        public void GenerateRandomSequence()
        {
            // Create a list of colors
            List<string> colors = new List<string> { "red", "blue", "green", "yellow" };

            // Create a random object
            Random random = new Random();

            // Create a list of random colors
            List<string> randomColors = new List<string>();

            // Loop through the colors list
            for (int i = 0; i < 4; i++)
            {
                // Get a random number
                int randomNumber = random.Next(0, 4);

                // Get the color at the random number
                string color = colors[randomNumber];

                // Add the color to the random colors list
                randomColors.Add(color);
            }

            // Print the random colors
            Console.WriteLine("Random Colors: " + string.Join(", ", randomColors));
        }
    }
}
