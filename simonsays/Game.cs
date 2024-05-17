using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;

namespace simonsays
{
    internal class Game
    {
        Button btnRed = new Button(0);
        Button btnGreen = new Button(1);
        Button btnYellow = new Button(2);
        Button btnBlue = new Button(3);
        public string round { get; set; }
        public int buttonStart { get; set; }
        public List<Button> buttons = new List<Button>();

        public void run()
        {
            buttons.Add(btnRed);
            buttons.Add(btnGreen);
            buttons.Add(btnYellow);
            buttons.Add(btnBlue);

            round = "Round: ";
            buttonStart = 0;
            SimonSays simonSays = new SimonSays(buttons, buttonStart, round);
            while (true)
            {
                Console.Clear();
                Console.WriteLine('\n');
                WriteLogo();
                Console.WriteLine("Welcome to Simon Says Clasic", Color.Green);
                this.SubMenu();
                Console.WriteLine("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        WriteLogo();
                        Console.WriteLine('\n');
                        Console.WriteLine("Press any key to start the game", Color.Green);
                        Console.ReadKey();
                        simonSays.StartGame();
                        break;
                    case "2":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice", Color.Red);
                        break;
                }
            }   
        }

        public void SubMenu()
        {
            Console.WriteLine("1. Start Game");
            Console.WriteLine("3. Exit");
        }

        public static void WriteLogo()
        {
            string logo = @"  
 (                         (                  
 )\ )                      )\ )               
(()/((     )              (()/(    ) (        
 /(_))\   (     (   (      /(_))( /( )\ ) (   
(_))((_)  )\  ' )\  )\ )  (_))  )(_)|()/( )\  
/ __|(_)_((_)) ((_)_(_/(  / __|((_)_ )(_)|(_) 
\__ \| | '  \() _ \ ' \)) \__ \/ _` | || (_-< 
|___/|_|_|_|_|\___/_||_|  |___/\__,_|\_, /__/ 
                                     |__/ 

             ";

            Console.WriteLine(logo, Color.DarkBlue);
        }
    }
}
