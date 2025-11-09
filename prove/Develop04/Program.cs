using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options");
            Console.WriteLine("  1 - Start Breathing Activity");
            Console.WriteLine("  2 - Start Reflecting Activity");
            Console.WriteLine("  3 - Start Listing Activity");
            Console.WriteLine("  4 - Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                BreathingActivity breathe = new();
                breathe.LoadActivity();
            }
            else if (choice == "2")
            {
                ReflectingActivity reflect = new();
                reflect.LoadActivity();
            }
            else if (choice == "3")
            {
                ListingActivity listing = new();
                listing.LoadActivity();
            }
            else if (choice == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Please select a valid option!");
                Activity loada = new();
                loada.LoadIcon(2);
                Console.Clear();
            }
        }
    }
}
