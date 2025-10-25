using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // My creativity I added was a startup menu that allows you to pick between 3 different scriptures to learn, 
        // and then once you run through the base program of memorizing that scripture it returns you to the menu to 
        // try again, try another scripture or just quit. It's nice because it allows for more than just 3.
        bool running = true;

        // Different scripture options
        List<Scripture> scriptures = new List<Scripture>()
        {
            new Scripture(new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),

            new Scripture(new Reference("Mosiah", 24, 14),
                "And I will also ease the burdens which are put upon your shoulders, that even you cannot feel them upon your backs, even while you are in bondage; and this will I do that ye may stand as witnesses for me hereafter, and that ye may know of a surety that I, the Lord God, do visit my people in their afflictions."),

            new Scripture(new Reference("2 Nephi", 2, 25),
                "Adam fell that men might be; and men are, that they might have joy.")
        };

        // Menu
        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== SCRIPTURE MEMORIZATION ===\n");
            Console.WriteLine("Select a scripture to memorize:");
            Console.WriteLine("1. John 3:16");
            Console.WriteLine("2. Mosiah 24:14");
            Console.WriteLine("3. 2 Nephi 2:25");
            Console.WriteLine("\nType 'quit' to exit.");
            Console.Write("\nYour choice: ");

            string choice = Console.ReadLine()?.Trim().ToLower();

            if (choice == "quit")
            {
                running = false;
                break;
            }

            int index = -1;

            switch (choice)
            {
                case "1":
                case "john":
                    index = 0;
                    break;
                case "2":
                case "mosiah":
                    index = 1;
                    break;
                case "3":
                case "nephi":
                    index = 2;
                    break;
                default:
                    Console.WriteLine("\nInvalid selection. Press Enter to try again...");
                    Console.ReadLine();
                    continue;
            }

            // Run memorization for the chosen scripture
            StartMemorization(scriptures[index]);
        }

        Console.WriteLine("\nPractice makes perfect! ");
    }

    // Memorization feature
    static void StartMemorization(Scripture scripture)
    {
        // refresh/reset words to unhidden
        Scripture s = new Scripture(scripture.GetReference(), scripture.GetOriginalText());

        while (true)
        {
            Console.Clear();
            s.Display();

            if (s.AllHidden())
            {
                Console.WriteLine("\nAll words are now hidden!");
                Console.WriteLine("\nPress Enter to return to the main menu.");
                Console.ReadLine();
                break;
            }

            Console.WriteLine("\nPress Enter to hide 3 more words, or type 'quit' to return to the menu.");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "quit")
                break;

            s.HideRandom(3);
        }
    }
}

