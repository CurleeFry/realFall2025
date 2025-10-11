using System;
using System.ComponentModel.Design;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
namespace Develop02;


// Hopefully it counts as enough, but for the innovation in my project I did some 
// formatting using the 2 functions below in the Program file, which allow me to
// add spaces and pauses to my code as I like without cluttering it up too much.





class Program
{
    static void Main(string[] args)
    {
        // Tools to hopefully polish up the program //
        static void Pass()
        {
            Console.Write("(Press any key to continue.)");
            Console.ReadKey();
            Console.WriteLine();
        }
        static void Spacer(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine();
            }
        }

        static void Run()
        {
            // Initiate Journal //
            Journal Journal = new Journal();
            //

            // initiate loop //
            string selection = "";
            while (selection != "Q")
            //
            {
                Spacer(6);
                // Make a fancy interface //
                Console.WriteLine("╔═══════════════════════════════════════════════╗");
                Console.WriteLine("║                                               ║");
                Console.WriteLine("║                   MY JOURNAL                  ║");
                Console.WriteLine("║                                               ║");
                Console.WriteLine("╠═══════════════════════════════════════════════╣");
                Console.WriteLine("║ (W) Write Entry                               ║");
                Console.WriteLine("║ (D) Display Journal                           ║");
                Console.WriteLine("║ (L) Load Journal from File                    ║");
                Console.WriteLine("║ (S) Save Journal to File                      ║");
                Console.WriteLine("║ (Q) Quit                                      ║");
                Console.WriteLine("╚═══════════════════════════════════════════════╝");
                Spacer(2);
                Console.Write("> ");

                // Read user input and initiate desired function //
                selection = Console.ReadLine().ToUpper();
                if (selection == "W")
                {
                    Journal.Write();
                    Pass();
                }
                else if (selection == "D")
                {
                    Journal.Display();
                    Pass();
                }
                else if (selection == "L")
                {
                    Journal.Load();
                    Pass();
                }
                else if (selection == "S")
                {
                    Journal.Save();
                    Pass();
                }
                else if (selection != "Q")
                {
                    Console.WriteLine("Please enter a valid option.");
                    Pass();
                }
            }
        }
        Run();
        Console.WriteLine("Thanks for using your Journal today.");
    }
}