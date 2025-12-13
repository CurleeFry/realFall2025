using System;
using System.Collections.Generic;
using System.IO;

public class Map
{
    private List<Tile> _tiles = new List<Tile>();
    private Character _character;

    public Map(Character character)
    {
        _character = character;

        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 20; x++)
            {
                if (x == 10 && y == 9)
                    _tiles.Add(new Gate(x, y));
                else if (x == 0 || x == 19 || y == 0 || y == 9)
                    _tiles.Add(new Fence(x, y));
                else if (x == 3 && y == 3)
                    _tiles.Add(new Tent(x, y));
                else
                    _tiles.Add(new Farmland(x, y));
            }
        }
    }

    public void Display()
    {
        Console.Clear();

        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 20; x++)
            {
                if (_character.Location(x, y))
                    _character.Display();
                else
                    GetTile(x, y).Display();
            }
            Console.WriteLine();
        }

        Console.WriteLine(
            "WASD Move | E Harvest | Q Water | 1 Seed | 2 Lucky | I Inventory | O Shop | ` Save"
        );
    }

    public bool IsPassable(int x, int y)
    {
        Tile t = GetTile(x, y);
        return t != null && t.CanPass;
    }

    public void Interact(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.W:
            case ConsoleKey.A:
            case ConsoleKey.S:
            case ConsoleKey.D:
                _character.Move(key, this);
                break;

            case ConsoleKey.Q:
                Water();
                break;

            case ConsoleKey.E:
                Harvest();
                break;

            case ConsoleKey.D1:
                PlantSeed();
                break;

            case ConsoleKey.D2:
                PlantLucky();
                break;

            case ConsoleKey.I:
                ViewInv();
                break;

            case ConsoleKey.O:
                Shop();
                break;

            case ConsoleKey.Spacebar:
                CheckInteractables();
                break;

            case ConsoleKey.Oem3: // `
                SaveGame();
                break;
        }
    }

    private void SaveGame()
    {
        string filename = _character.Name + ".txt";
        Character.PlayerInventory.SaveToFile(filename);

        Console.SetCursorPosition(0, 12);
        Console.WriteLine("Game saved.");
    }


    private Tile GetTile(int x, int y)
    {
        return _tiles.Find(t => t.X == x && t.Y == y);
    }

    private void Harvest()
    {
        var f = GetTile(_character.FacingX, _character.FacingY) as Farmland;
        if (f != null) f.Harvest();
    }

    private void Water()
    {
        var f = GetTile(_character.FacingX, _character.FacingY) as Farmland;
        if (f != null) f.Water();
    }

    private void PlantSeed()
    {
        var f = GetTile(_character.FacingX, _character.FacingY) as Farmland;
        if (f != null && Character.PlayerInventory.Seeds > 0)
            f.Plant(false);
    }

    private void PlantLucky()
    {
        var f = GetTile(_character.FacingX, _character.FacingY) as Farmland;
        if (f != null && Character.PlayerInventory.LuckySeeds > 0)
            f.Plant(true);
    }

    private void ViewInv()
    {
        Character.PlayerInventory.SeeInv();
    }

    private void CheckInteractables()
    {
        Tile t = GetTile(_character.FacingX, _character.FacingY);

        if (t is Tent tent)
            tent.Sleep(_character, _tiles);

        if (t is Gate gate)
            gate.Leave();
    }

    private void Shop()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== SHOP ===");
            Console.WriteLine($"Coins: {Character.PlayerInventory.Coins}\n");

            Console.WriteLine("1) Buy Seed (3 coins)");
            Console.WriteLine("2) Buy Lucky Seed (15 coins)");
            Console.WriteLine("3) Sell Items");
            Console.WriteLine("ESC) Exit");

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Escape)
                return;

            if (key == ConsoleKey.D1)
            {
                AttemptPurchase("Seed", 3);
            }
            else if (key == ConsoleKey.D2)
            {
                AttemptPurchase("LuckySeed", 15);
            }
            else if (key == ConsoleKey.D3)
            {
                Character.PlayerInventory.SellMenu();
            }
        }
    }
    private void AttemptPurchase(string item, int cost)
    {
        Console.Clear();

        if (Character.PlayerInventory.BuyItem(item, cost))
        {
            Console.WriteLine($"Purchased {item} for {cost} coins.");
        }
        else
        {
            Console.WriteLine("Not enough coins.");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);
    }


}
