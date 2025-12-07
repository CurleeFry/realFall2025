using System;

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
        {
            i.Display();
        }

        Console.WriteLine("\nPress ESC to exit inventory.");
        while (Console.ReadKey(true).Key != ConsoleKey.Escape) { }
    }

    public static Inventory FromCSV(string[] lines)
    {
        Inventory inv = new Inventory();

        foreach (string line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length < 5) continue;

            inv.Items.Add(new Item(parts[0], parts[1], parts[2], parts[3]));
            inv.Coins = int.Parse(parts[4]);
        }

        return inv;
    }
}