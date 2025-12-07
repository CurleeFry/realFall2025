using System;

public class Fence : Tile
{
    public Fence(int x, int y) : base(x, y)
    {
        CanPass = false;
    }

    public override void Display()
    {
        Console.Write("#");
    }
}