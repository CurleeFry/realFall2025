using System;

public class Tent : Tile
{
    public Tent(int x, int y) : base(x, y)
    {
        CanPass = false;
    }

    public override void Display()
    {
        Console.Write("T");
    }

    public void Sleep(Character c, List<Tile> tiles)
    {
        Console.Clear();
        Console.WriteLine("Sleeping...");
        System.Threading.Thread.Sleep(1000);

        foreach (var t in tiles)
        {
            if (t is Farmland f)
            {
                var statusField = typeof(Farmland).GetField("_status", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                int s = (int)statusField.GetValue(f);
                if (s == 2)
                    statusField.SetValue(f, 3);
            }
        }
    }
}