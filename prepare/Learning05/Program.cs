using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square first = new Square("Purple", 7);
        shapes.Add(first);

        Rectangle second = new Rectangle("Green", 3, 4);
        shapes.Add(second);

        Circle third = new Circle("Black", 50);
        shapes.Add(third);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();
            Console.WriteLine($"Your {color} {s.ToString()} has an area of {area}.");
        }
    }
}