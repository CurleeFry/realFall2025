using System;
using System.Collections.Generic;
using System.IO;

public class Inventory
{
    public List<Item> Items = new List<Item>();
    public int LuckySeeds;
    public int Seeds;
    public int Coins;

    public void AddItem(Item i)
    {
        Items.Add(i);
    }

    public bool BuyItem(string type, int cost)
    {
        if (Coins < cost) return false;

        Coins -= cost;

        if (type == "Seed") Seeds++;
        if (type == "LuckySeed") LuckySeeds++;

        return true;
    }

    public void SellMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== SELL ITEMS ===");
            Console.WriteLine($"Coins: {Coins}\n");

            if (Items.Count == 0)
            {
                Console.WriteLine("You have nothing to sell.");
                Console.WriteLine("\nPress any key to return.");
                Console.ReadKey(true);
                return;
            }

            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"[{i:D2}] {Items[i].Name} ({Items[i].Rarity}) - {Items[i].Value} coins");
            }

            Console.WriteLine("\nEnter item number to sell (00–99)");
            Console.WriteLine("ESC to return");

            string input = ReadNumberOrEscape();
            if (input == null)
                return;

            if (!int.TryParse(input, out int index) || index < 0 || index >= Items.Count)
            {
                Console.WriteLine("Invalid selection.");
                Pause();
                continue;
            }

            Item item = Items[index];

            if (IsHighRarity(item))
            {
                Console.WriteLine($"\n⚠ WARNING: {item.Rarity} item!");
                Console.WriteLine($"Sell {item.Name} for {item.Value} coins? (Y/N)");

                var confirm = Console.ReadKey(true).Key;
                if (confirm != ConsoleKey.Y)
                    continue;
            }

            Coins += item.Value;
            Items.RemoveAt(index);

            Console.WriteLine("\nItem sold.");
            Pause();
        }
    }

    private string ReadNumberOrEscape()
    {
        string buffer = "";

        while (true)
        {
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
                return null;

            if (key.Key == ConsoleKey.Enter)
                return buffer;

            if (char.IsDigit(key.KeyChar) && buffer.Length < 2)
            {
                buffer += key.KeyChar;
                Console.Write(key.KeyChar);
            }
        }
    }
    private bool IsHighRarity(Item item)
    {
        return item.Rarity == "PINK"
            || item.Rarity == "RED"
            || item.Rarity == "GOLD";
    }

    private void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);
    }


    public void SeeInv()
    {
        Console.Clear();
        Console.WriteLine($"Coins: {Coins}");
        Console.WriteLine($"Seeds: {Seeds}");
        Console.WriteLine($"Lucky Seeds: {LuckySeeds}\n");

        foreach (var i in Items)
            i.Display();

        Console.WriteLine("\nPress ESC to exit inventory.");
        while (Console.ReadKey(true).Key != ConsoleKey.Escape) { }
    }

    public void SaveToFile(string filename)
    {
        List<string> lines = new List<string>();

        // Header line: coins,seeds,luckySeeds
        lines.Add($"{Coins},{Seeds},{LuckySeeds}");

        // Each item: name,rarity,size,condition
        foreach (var item in Items)
        {
            lines.Add($"{item.Name},{item.Rarity},{item.Size},{item.Condition}");
        }

        File.WriteAllLines(filename, lines);
    }

    public static Inventory FromCSV(string[] lines)
    {
        Inventory inv = new Inventory();

        if (lines.Length == 0)
            return inv;

        // First line = inventory stats
        var header = lines[0].Split(',');
        inv.Coins = int.Parse(header[0]);
        inv.Seeds = int.Parse(header[1]);
        inv.LuckySeeds = int.Parse(header[2]);

        // Remaining lines = items
        for (int i = 1; i < lines.Length; i++)
        {
            var parts = lines[i].Split(',');
            if (parts.Length == 4)
            {
                inv.Items.Add(new Item(
                    parts[0],
                    parts[1],
                    parts[2],
                    parts[3]
                ));
            }
        }

        return inv;
    }
}
