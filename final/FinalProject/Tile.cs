using System;

public class Tile
{
    public int X { get; protected set; }
    public int Y { get; protected set; }
    public bool CanPass { get; protected set; } = true;

    public Tile(int x, int y)
    {
        X = x;
        Y = y;
    }

    public virtual void Display()
    {
        Console.Write(".");
    }
}