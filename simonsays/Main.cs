using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using simonsays;
using simonsays.interfaces;
using Console = Colorful.Console;

class Program
{
    public static void Main()
    {
        
        do
        {
            //Console.Clear();
            writeSimon();
            menu();
            Console.Write("Enter your choice: ", Color.DimGray);
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                case "2":
                    IRunner runner = RunnerFactory.getRunner(choice);
                    runner.run();
                    //Console.ReadKey();
                    break;
                case "3":
                    Console.Clear();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice", Color.Red);
                    break;
            }
        } while (true);
    }

    public static void menu()
    {
        Console.WriteLine("Main Menu", Color.Red);
        Console.WriteLine("-------------------------", Color.Red);
        Console.WriteLine("1. Simon Says Game Clasic", Color.DimGray);
        Console.WriteLine("2. Stop Game", Color.DimGray);
        Console.WriteLine("3. Clear Console", Color.ForestGreen);
        Console.WriteLine("4. Exit", Color.DarkRed);
    }
    

    public static void writeSimon()
    {
        string simon = @" (                         (                                            
 )\ )                      )\ )                (                        
(()/((     )              (()/(    ) (         )\ )      )    )     (   
 /(_))\   (     (   (      /(_))( /( )\ ) (   (()/(   ( /(   (     ))\  
(_))((_)  )\  ' )\  )\ )  (_))  )(_)|()/( )\   /(_))_ )(_))  )\  '/((_) 
/ __|(_)_((_)) ((_)_(_/(  / __|((_)_ )(_)|(_) (_)) __((_)_ _((_))(_))   
\__ \| | '  \() _ \ ' \)) \__ \/ _` | || (_-<   | (_ / _` | '  \() -_)  
|___/|_|_|_|_|\___/_||_|  |___/\__,_|\_, /__/    \___\__,_|_|_|_|\___|  
                                     |__/                               ";

        Console.WriteLine(simon, Color.DarkRed);
    }
}
