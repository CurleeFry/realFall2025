class Costume
{
    // attributes
    public string outfit = "";
    public string footwear = "";
    public string tools = "";
    public string size = "";

    // behaviors
    public void Display()
    {
        Console.WriteLine($"outfit: {outfit}");
        Console.WriteLine($"footwear: {footwear}");
        Console.WriteLine($"tool: {tools}");
    }
}