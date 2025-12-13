using System;

public class Gate : Tile
{
    public Gate(int x, int y) : base(x, y)
    {
        CanPass = false;
    }

    public override void Display()
    {
        Console.Write("=");
    }

    public void Leave()
    {
        Console.Clear();
        Console.WriteLine("You leave the farm. Game Over.");
        Environment.Exit(0);
    }
}