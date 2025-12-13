using System;
using System.IO;

public class Game
{
    private Map _map;

    public void Play()
    {
        Character player = LoadOrCreateCharacter();
        _map = new Map(player);

        Console.Clear();

        while (true)
        {
            _map.Display();
            var key = Console.ReadKey(true).Key;
            _map.Interact(key);
        }
    }

    private Character LoadOrCreateCharacter()
    {
        Console.WriteLine("Load old character? (Y/N)");
        ConsoleKey key = Console.ReadKey(true).Key;

        Console.WriteLine("Enter player name:");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name.");
            Environment.Exit(0);
        }

        Character player = new Character(name, 5, 5);
        string filename = name + ".txt";

        if (key == ConsoleKey.Y && File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            Character.PlayerInventory = Inventory.FromCSV(lines);
            Console.WriteLine("Character loaded.");
        }
        else
        {
            Character.PlayerInventory = new Inventory();
            Character.PlayerInventory.Seeds = 20;
            Console.WriteLine("New character created.");
        }

        Console.ReadKey();
        return player;
    }
}
