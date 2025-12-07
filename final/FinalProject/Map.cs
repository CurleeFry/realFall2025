using System;

public class Map
{
    private List<Tile> _tiles = new List<Tile>();
    private Character _character;

    public Map()
    {
        _character = new Character(5, 5);

        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 20; x++)
            {
                if (x == 0 || x == 19 || y == 0 || y == 9)
                    _tiles.Add(new Fence(x, y));
                else if (x == 10 && y == 9)
                    _tiles.Add(new Gate(x, y));
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

        Console.WriteLine("WASD = Move • E = Harvest • Q = Water • 1 = Plant Seed • 2 = Plant Lucky • I = Inventory • O = Shop");
    }

    public void Interact(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.W:
            case ConsoleKey.A:
            case ConsoleKey.S:
            case ConsoleKey.D:
                _character.Move(key);
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
        }
    }

    public void Shop()
    {
        Console.Clear();
        Console.WriteLine("SHOP");
        Console.WriteLine("1) Buy Seed (3 coins)");
        Console.WriteLine("2) Buy Lucky Seed (15 coins)");
        Console.WriteLine("3) Sell Items");
        Console.WriteLine("ESC) Exit");

        while (true)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Escape) return;

            if (key == ConsoleKey.D1)
            {
                if (Character.PlayerInventory.BuyItem("Seed", 3))
                    Console.WriteLine("Bought a seed.");
            }
            else if (key == ConsoleKey.D2)
            {
                if (Character.PlayerInventory.BuyItem("LuckySeed", 15))
                    Console.WriteLine("Bought a lucky seed.");
            }
            else if (key == ConsoleKey.D3)
            {
                Character.PlayerInventory.SellMenu();
            }
        }
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
}