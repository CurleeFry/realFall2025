using System;

public class Character
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public string Name { get; private set; }

    private string _facing = "N";

    public static Inventory PlayerInventory;

    public int FacingX => _facing == "W" ? X - 1 : _facing == "E" ? X + 1 : X;
    public int FacingY => _facing == "N" ? Y - 1 : _facing == "S" ? Y + 1 : Y;

    public Character(string name, int x, int y)
    {
        Name = name;
        X = x;
        Y = y;
    }

    public void Move(ConsoleKey key, Map map)
    {
        string dir = key switch
        {
            ConsoleKey.W => "N",
            ConsoleKey.S => "S",
            ConsoleKey.A => "W",
            ConsoleKey.D => "E",
            _ => _facing
        };

        if (dir == _facing)
        {
            int newX = X;
            int newY = Y;

            if (dir == "N") newY--;
            if (dir == "S") newY++;
            if (dir == "W") newX--;
            if (dir == "E") newX++;

            if (map.IsPassable(newX, newY))
            {
                X = newX;
                Y = newY;
            }
        }
        else
        {
            _facing = dir;
        }
    }

    public bool Location(int x, int y) => X == x && Y == y;

    public void Display()
    {
        Console.Write("@");
    }
}
