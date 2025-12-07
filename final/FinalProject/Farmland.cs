using System;

public class Farmland : Tile
{
    private static Random rng = new Random();

    private List<string> _plants = new List<string>
        {
            "carrot","potato","strawberry","squash","zucchini","pepper","tomato","blueberry","corn","peas"
        };

    private List<string> _conditions = new List<string>
        {
            "Super Fresh","Fresh","Fair","Normal","Slightly Bruised","Bruised","Squishy"
        };

    private List<string> _sizes = new List<string>
        {
            "Jumbo","Large","Normal-Large","Normal","Normal-Small","Small"
        };

    private int _status = 0;
    private string _plant;
    private string _rarity;
    private string _size;
    private string _condition;

    public Farmland(int x, int y) : base(x, y) { }

    public void Water()
    {
        if (_status == 1)
            _status = 2;
    }

    public void Plant(bool lucky)
    {
        if (_status != 0) return;

        if (lucky)
            Character.PlayerInventory.LuckySeeds--;
        else
            Character.PlayerInventory.Seeds--;

        _plant = _plants[rng.Next(_plants.Count)];
        _size = _sizes[rng.Next(_sizes.Count)];
        _condition = _conditions[rng.Next(_conditions.Count)];

        int roll = rng.Next(10000);

        if (lucky)
        {
            if (roll < 175) _rarity = "GOLD";
            else if (roll < 550) _rarity = "RED";
            else if (roll < 1625) _rarity = "PINK";
            else if (roll < 7000) _rarity = "PURPLE";
            else _rarity = "BLUE";
        }
        else
        {
            if (roll < 26) _rarity = "GOLD";
            else if (roll < 90) _rarity = "RED";
            else if (roll < 410) _rarity = "PINK";
            else if (roll < 1960) _rarity = "PURPLE";
            else _rarity = "BLUE";
        }

        _status = 1;
    }

    public void Harvest()
    {
        if (_status == 3)
        {
            Item item = new Item(_plant, _rarity, _size, _condition);
            Character.PlayerInventory.AddItem(item);
            _status = 0;
        }
    }

    public override void Display()
    {
        if (_status == 0)
            Console.Write("_");
        else if (_status < 3)
            Console.Write("^");
        else
        {
            Console.ForegroundColor = Item.ColorFromRarity(_rarity);
            Console.Write("*");
            Console.ResetColor();
        }
    }
}