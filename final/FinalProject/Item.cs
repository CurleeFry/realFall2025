using System;

public class Item
{
    public string Name { get; private set; }
    public string Rarity { get; private set; }
    public string Size { get; private set; }
    public string Condition { get; private set; }
    public int Value { get; private set; }

    public Item(string name, string rarity, string size, string condition)
    {
        Name = name;
        Rarity = rarity;
        Size = size;
        Condition = condition;

        Value = ComputeValue();
    }

    public static ConsoleColor ColorFromRarity(string rarity)
    {
        return rarity switch
        {
            "GOLD" => ConsoleColor.Yellow,
            "RED" => ConsoleColor.Red,
            "PINK" => ConsoleColor.Magenta,
            "PURPLE" => ConsoleColor.DarkMagenta,
            "BLUE" => ConsoleColor.Cyan,
            _ => ConsoleColor.White
        };
    }

    private int ComputeValue()
    {
        int baseValue = Name.ToLower() switch
        {
            "carrot" => 5,
            "potato" => 5,
            "strawberry" => 6,
            "squash" => 4,
            "zucchini" => 3,
            "pepper" => 4,
            "tomato" => 2,
            "blueberry" => 7,
            "corn" => 3,
            "peas" => 2,
            _ => 1
        };

        double rarityMult = Rarity.ToUpper() switch
        {
            "GOLD" => 80.0,
            "RED" => 20.0,
            "PINK" => 5.0,
            "PURPLE" => 1.5,
            "BLUE" => 1.0,
            _ => 1.0
        };

        double conditionMult = Condition switch
        {
            "Super Fresh" => 2.0,
            "Fresh" => 1.5,
            "Fair" => 1.2,
            "Normal" => 1.0,
            "Slightly Bruised" => 0.9,
            "Bruised" => 0.7,
            "Squishy" => 0.5,
            _ => 1.0
        };

        double sizeMult = Size switch
        {
            "Jumbo" => 2.0,
            "Large" => 1.5,
            "Normal-Large" => 1.2,
            "Normal" => 1.0,
            "Normal-Small" => 0.9,
            "Small" => 0.8,
            _ => 1.0
        };

        double raw = baseValue * rarityMult * conditionMult * sizeMult;
        return (int)Math.Ceiling(raw);
    }

    public void Display()
    {
        Console.ForegroundColor = ColorFromRarity(Rarity);
        Console.WriteLine($"{Name} ({Rarity}) size:{Size} condition:{Condition} value:{Value}");
        Console.ResetColor();
    }
}