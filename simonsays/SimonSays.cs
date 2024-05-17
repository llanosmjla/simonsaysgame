using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Colorful;
using Console = Colorful.Console;
using NUnit.Common;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Media;
using System.Threading;
using NUnit.Framework.Internal.Execution;
namespace simonsays
{
    internal class SimonSays
    {
        //valColors:
        string red = @"[000]";
        string green = @"[111]";
        string yellow = @"[222]";
        string blue = @"[333]";
        //colors
        string NL = Environment.NewLine; // shortcut
        string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
        string RED = Console.IsOutputRedirected ? "" : "\x1b[91m";
        string GREEN = Console.IsOutputRedirected ? "" : "\x1b[92m";
        string YELLOW = Console.IsOutputRedirected ? "" : "\x1b[93m";
        string BLUE = Console.IsOutputRedirected ? "" : "\x1b[94m";
        string MAGENTA = Console.IsOutputRedirected ? "" : "\x1b[95m";
        string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
        string GREY = Console.IsOutputRedirected ? "" : "\x1b[97m";
        string GOLD = Console.IsOutputRedirected ? "" : "\x1b[38;2;255;215;0m";
        string BOLD = Console.IsOutputRedirected ? "" : "\x1b[1m";
        string NOBOLD = Console.IsOutputRedirected ? "" : "\x1b[22m";
        string UNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[4m";
        string NOUNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[24m";
        string REVERSE = Console.IsOutputRedirected ? "" : "\x1b[7m";
        string NOREVERSE = Console.IsOutputRedirected ? "" : "\x1b[27m";
        //endColors

        public int round;
        public int userPosition;
        public int totalRounds;
        public List<int> sequence;
        public int speed;
        public bool blockedButton = true;
        public List<Button> buttons;
        public Verify verify;
        public SequenceGenerator sequenceGenerator;
        public Button button;
        public SimonSays(List<Button> buttons, int buttonStart, string round)
        {
            //VARIABLES 
            this.round = 0;
            this.userPosition = 0;
            this.totalRounds = 5;
            this.sequence = new List<int>();
            this.speed = 1000;
            this.blockedButton = true;
            this.buttons = buttons;

            this.sequenceGenerator = new SequenceGenerator(this);
            this.button = new Button(this);
        }

        public SimonSays()
        {
            this.round = 0;
            this.userPosition = 0;
            this.totalRounds = 5;
            this.sequence = new List<int>();
        }

        public void StartGame()
        {

            this.UpdateRound(0);
            this.userPosition = 0;
            this.sequence = this.sequenceGenerator.CreateSequence();
            this.ShowSequence();
            Console.WriteLine("Press Color Option", Color.Green);
            this.GetUserInput();

        }

        private void GetUserInput()
        {
            while (!this.button.blockedButton)
            {
                Console.WriteLine("Enter a number between 0 and 3");
                if (int.TryParse(Console.ReadLine(), out int buttonNumber) && buttonNumber >= 0 && buttonNumber < 4)
                {
                    this.button.ButtonClick(buttonNumber);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 3.");
                }
            }
        }


        public void UpdateRound(int value)
        {
            this.round = value;

        }



        /*public void buttonClick(int button)
        {
            if (!this.blockedButton)
            {
                //this.validateDateChosenColor(button);
                this.verify.ValidateDateChosenColor(button);
            }

        }*/

        public void IsGameOver()
        {
            if (this.round == this.totalRounds)
            {
                this.GameWon();
            }
            else
            {
                this.userPosition = 0;
                this.ShowSequence();
            }
        }

        public void ShowSequence()
        {
            this.button.blockedButton = true;
            Console.Clear();
            Console.WriteLine("Round" + this.round, Color.Green);
            Console.WriteLine(@$"  {RED}{red}{NORMAL}  {GREEN}{green}{NORMAL}  {YELLOW}{yellow}{NORMAL}  {BLUE}{blue}{NORMAL}  ");
            Thread.Sleep(2100);
            Console.Clear();
            Console.WriteLine("********* Starting sequence *************", Color.Green);
            Thread.Sleep(1000);
            Console.Clear();
            // for (int i = 0; i <= this.round; i++)
            for (int i = 0; i <= this.round; i++)
            {

                int item = this.sequence[i];
                //Console.WriteLine("Sequence: " + item);
                this.ToggleButtonStyle(item);
                this.DisableUserInput();

                Thread.Sleep((int)this.speed);
            }
            Console.WriteLine("Round: " + this.round, Color.AliceBlue);
            Console.WriteLine(@$"  {RED}{red}{NORMAL}  {GREEN}{green}{NORMAL}  {YELLOW}{yellow}{NORMAL}  {BLUE}{blue}{NORMAL}  ");
            this.button.blockedButton = false;


        }

        public void ToggleButtonStyle(int item)
        {
            if (item == 0)
            {
                Console.WriteLine(@$"  {GREY}{red}{NORMAL}  {GREEN}{green}{NORMAL}  {YELLOW}{yellow}{NORMAL}  {BLUE}{blue}{NORMAL}  ");
                Console.Beep(500, this.speed);
                Console.Clear();

            }
            else if (item == 1)
            {

                Console.WriteLine(@$"  {RED}{red}{NORMAL}  {GREY}{green}{NORMAL}  {YELLOW}{yellow}{NORMAL}  {BLUE}{blue}{NORMAL}  ");
                Console.Beep(600, this.speed);
                Console.Clear();

            }
            else if (item == 2)
            {

                Console.WriteLine(@$"  {RED}{red}{NORMAL}  {GREEN}{green}{NORMAL}  {GREY}{yellow}{NORMAL}  {BLUE}{blue}{NORMAL}  ");
                Console.Beep(700, this.speed);
                Console.Clear();

            }
            else if (item == 3)
            {

                Console.WriteLine(@$"  {RED}{red}{NORMAL}  {GREEN}{green}{NORMAL}  {YELLOW}{yellow}{NORMAL}  {GREY}{blue}{NORMAL}  ");
                Console.Beep(800, this.speed);
                Console.Clear();


            }
        }

        public void GameLost()
        {
            Console.Clear();
            Console.WriteLine("You lost", Color.Red);
            Console.Beep(200, 1000);
            Console.ReadKey();
            Console.Clear();
            this.UpdateRound(0);
            Game game = new Game();
            game.run();

        }

        public void DisableUserInput()
        {
            // Lanzar una tarea que capture y descarte todas las teclas presionadas
            Thread inputThread = new Thread(() =>
            {
                while (true)
                {
                    // Captura y descarta cualquier tecla presionada
                    Console.ReadKey(true);
                }
            });
            inputThread.IsBackground = true;
            inputThread.Start();
        }

        public void GameWon()
        {
            Console.Clear();
            string win = @"     )                                 ____________ 
  ( /(           (  (                 |   /   /   / 
  )\())     (    )\))(   '            |  /|  /|  /  
 ((_)\ (   ))\  ((_)()\ ) (   (       | / | / | /   
__ ((_))\ /((_) _(())\_)())\  )\ )    |/  |/  |/    
\ \ / ((_|_))(  \ \((_)/ ((_)_(_/(   (   (   (      
 \ V / _ \ || |  \ \/\/ / _ \ ' \))  )\  )\  )\     
  |_|\___/\_,_|   \_/\_/\___/_||_|  ((_)((_)((_) ";
            Console.WriteLine(@$"{GOLD}{win}{NORMAL}");
            Console.Beep(1000, 300);
            this.PlayChampionSound();
            Console.ReadKey();
            this.UpdateRound(0);
            Console.Clear();
            Game game = new Game();
            game.run();
        }

        public void PlayChampionSound()
        {
            // Array of frequencies for the champion sound
            int[] frequencies = { 523, 587, 659, 784, 880 };
            int duration = 200; // Duration of each tone in milliseconds

            foreach (int freq in frequencies)
            {
                Console.Beep(freq, duration);
            }

            Console.Beep(440, 500);
        }
    }
}
