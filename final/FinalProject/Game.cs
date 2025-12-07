public class Game
{
    private Map _map;


    public void Play()
    {
        Load();
        _map = new Map();
        Console.Clear();


        while (true)
        {
            _map.Display();
            var key = Console.ReadKey(true).Key;
            _map.Interact(key);
        }
    }

    public void Load()
    {
        Console.WriteLine("Load old character? (Y/N)");
        ConsoleKey key = Console.ReadKey(true).Key;


        if (key == ConsoleKey.Y)
        {
            Console.WriteLine("Enter player name:");
            string name = Console.ReadLine();


            if (File.Exists(name + ".txt"))
            {
                string[] lines = File.ReadAllLines(name + ".txt");
                Character.PlayerInventory = Inventory.FromCSV(lines);
            }
            else
            {
                Console.WriteLine("Save file not found. Starting new.");
                Character.PlayerInventory = new Inventory();
                Character.PlayerInventory.Seeds = 20;
            }
        }
        else
        {
            Character.PlayerInventory = new Inventory();
            Character.PlayerInventory.Seeds = 20;
        }
    }
}