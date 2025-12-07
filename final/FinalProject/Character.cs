using System;

public class Character
{
    public int X { get; private set; }
    public int Y { get; private set; }

    private string _facing = "N";

    public static Inventory PlayerInventory;

    public int FacingX => _facing == "W" ? X - 1 : _facing == "E" ? X + 1 : X;
    public int FacingY => _facing == "N" ? Y - 1 : _facing == "S" ? Y + 1 : Y;

    public Character(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Move(ConsoleKey key)
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
            if (dir == "N") Y--;
            if (dir == "S") Y++;
            if (dir == "W") X--;
            if (dir == "E") X++;
        }
        else
        {
            _facing = dir;
        }
    }

    public bool Location(int x, int y)
    {
        return X == x && Y == y;
    }

    public void Display()
    {
        Console.Write("@");
    }
}