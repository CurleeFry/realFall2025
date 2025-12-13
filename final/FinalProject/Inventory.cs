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
        Console.Clear();
        Console.WriteLine("SELL ITEMS");
        Console.WriteLine("Select index to sell, ESC to exit");

        for (int i = 0; i < Items.Count; i++)
        {
            Console.WriteLine($"[{i}] {Items[i].Name} ({Items[i].Value} coins)");
        }

        while (true)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Escape) return;

            if (char.IsDigit((char)key))
            {
                int idx = (int)char.GetNumericValue((char)key);
                if (idx >= 0 && idx < Items.Count)
                {
                    Coins += Items[idx].Value;
                    Items.RemoveAt(idx);
                    return;
                }
            }
        }
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

    // ===============================
    // ✅ SAVE SYSTEM
    // ===============================

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
