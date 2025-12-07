// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Game game = new Game();
//         game.Play();
//     }
// }
// using System;

// public class Game
// {
//     private Map _map;


//     public void Play()
//     {
//         Load();
//         _map = new Map();
//         Console.Clear();


//         while (true)
//         {
//             _map.Display();
//             var key = Console.ReadKey(true).Key;
//             _map.Interact(key);
//         }
//     }

//     public void Load()
//     {
//         Console.WriteLine("Load old character? (Y/N)");
//         ConsoleKey key = Console.ReadKey(true).Key;


//         if (key == ConsoleKey.Y)
//         {
//             Console.WriteLine("Enter player name:");
//             string name = Console.ReadLine();


//             if (File.Exists(name + ".txt"))
//             {
//                 string[] lines = File.ReadAllLines(name + ".txt");
//                 Character.PlayerInventory = Inventory.FromCSV(lines);
//             }
//             else
//             {
//                 Console.WriteLine("Save file not found. Starting new.");
//                 Character.PlayerInventory = new Inventory();
//                 Character.PlayerInventory.Seeds = 5;
//             }
//         }
//         else
//         {
//             Character.PlayerInventory = new Inventory();
//             Character.PlayerInventory.Seeds = 5;
//         }
//     }
// }
// using System;

// public class Map
// {
//     private List<Tile> _tiles = new List<Tile>();
//     private Character _character;

//     public Map()
//     {
//         _character = new Character(5, 5);

//         // Simple hardcoded map for now
//         for (int y = 0; y < 10; y++)
//         {
//             for (int x = 0; x < 20; x++)
//             {
//                 if (x == 0 || x == 19 || y == 0 || y == 9)
//                     _tiles.Add(new Fence(x, y));
//                 else if (x == 10 && y == 9)
//                     _tiles.Add(new Gate(x, y));
//                 else if (x == 3 && y == 3)
//                     _tiles.Add(new Tent(x, y));
//                 else
//                     _tiles.Add(new Farmland(x, y));
//             }
//         }
//     }

//     public void Display()
//     {
//         Console.Clear();

//         for (int y = 0; y < 10; y++)
//         {
//             for (int x = 0; x < 20; x++)
//             {
//                 if (_character.Location(x, y))
//                     _character.Display();
//                 else
//                     GetTile(x, y).Display();
//             }
//             Console.WriteLine();
//         }

//         Console.WriteLine("WASD = Move • E = Harvest • Q = Water • 1 = Plant Seed • 2 = Plant Lucky • I = Inventory • O = Shop");
//     }

//     public void Interact(ConsoleKey key)
//     {
//         switch (key)
//         {
//             case ConsoleKey.W:
//             case ConsoleKey.A:
//             case ConsoleKey.S:
//             case ConsoleKey.D:
//                 _character.Move(key);
//                 break;

//             case ConsoleKey.Q:
//                 Water();
//                 break;

//             case ConsoleKey.E:
//                 Harvest();
//                 break;

//             case ConsoleKey.D1:
//                 PlantSeed();
//                 break;

//             case ConsoleKey.D2:
//                 PlantLucky();
//                 break;

//             case ConsoleKey.I:
//                 ViewInv();
//                 break;

//             case ConsoleKey.O:
//                 Shop();
//                 break;

//             case ConsoleKey.Spacebar:
//                 CheckInteractables();
//                 break;
//         }
//     }

//     public void Shop()
//     {
//         Console.Clear();
//         Console.WriteLine("SHOP");
//         Console.WriteLine("1) Buy Seed (5 coins)");
//         Console.WriteLine("2) Buy Lucky Seed (30 coins)");
//         Console.WriteLine("3) Sell Items");
//         Console.WriteLine("ESC) Exit");

//         while (true)
//         {
//             var key = Console.ReadKey(true).Key;
//             if (key == ConsoleKey.Escape) return;

//             if (key == ConsoleKey.D1)
//             {
//                 if (Character.PlayerInventory.BuyItem("Seed", 5))
//                     Console.WriteLine("Bought a seed.");
//             }
//             else if (key == ConsoleKey.D2)
//             {
//                 if (Character.PlayerInventory.BuyItem("LuckySeed", 30))
//                     Console.WriteLine("Bought a lucky seed.");
//             }
//             else if (key == ConsoleKey.D3)
//             {
//                 Character.PlayerInventory.SellMenu();
//             }
//         }
//     }

//     private Tile GetTile(int x, int y)
//     {
//         return _tiles.Find(t => t.X == x && t.Y == y);
//     }

//     private void Harvest()
//     {
//         var f = GetTile(_character.FacingX, _character.FacingY) as Farmland;
//         if (f != null) f.Harvest();
//     }

//     private void Water()
//     {
//         var f = GetTile(_character.FacingX, _character.FacingY) as Farmland;
//         if (f != null) f.Water();
//     }

//     private void PlantSeed()
//     {
//         var f = GetTile(_character.FacingX, _character.FacingY) as Farmland;
//         if (f != null && Character.PlayerInventory.Seeds > 0)
//             f.Plant(false);
//     }

//     private void PlantLucky()
//     {
//         var f = GetTile(_character.FacingX, _character.FacingY) as Farmland;
//         if (f != null && Character.PlayerInventory.LuckySeeds > 0)
//             f.Plant(true);
//     }

//     private void ViewInv()
//     {
//         Character.PlayerInventory.SeeInv();
//     }

//     private void CheckInteractables()
//     {
//         Tile t = GetTile(_character.FacingX, _character.FacingY);

//         if (t is Tent tent)
//             tent.Sleep(_character, _tiles);

//         if (t is Gate gate)
//             gate.Leave();
//     }
// }
// using System;

// public class Tile
// {
//     public int X { get; protected set; }
//     public int Y { get; protected set; }
//     public bool CanPass { get; protected set; } = true;

//     public Tile(int x, int y)
//     {
//         X = x;
//         Y = y;
//     }

//     public virtual void Display()
//     {
//         Console.Write(".");
//     }
// }
// using System;

// public class Farmland : Tile
// {
//     private static Random rng = new Random();

//     private List<string> _plants = new List<string>
//         {
//             "carrot","potato","strawberry","squash","zucchini","pepper","tomato","blueberry","corn","peas"
//         };

//     private List<string> _conditions = new List<string>
//         {
//             "Super Fresh","Fresh","Fair","Normal","Slightly Bruised","Bruised","Squishy"
//         };

//     private List<string> _sizes = new List<string>
//         {
//             "Jumbo","Large","Normal-Large","Normal","Normal-Small","Small"
//         };

//     private int _status = 0;
//     private string _plant;
//     private string _rarity;
//     private string _size;
//     private string _condition;

//     public Farmland(int x, int y) : base(x, y) { }

//     public void Water()
//     {
//         if (_status == 1)
//             _status = 2;
//     }

//     public void Plant(bool lucky)
//     {
//         if (_status != 0) return;

//         if (lucky)
//             Character.PlayerInventory.LuckySeeds--;
//         else
//             Character.PlayerInventory.Seeds--;

//         _plant = _plants[rng.Next(_plants.Count)];
//         _size = _sizes[rng.Next(_sizes.Count)];
//         _condition = _conditions[rng.Next(_conditions.Count)];

//         int roll = rng.Next(10000);

//         if (lucky)
//         {
//             if (roll < 175) _rarity = "GOLD";
//             else if (roll < 550) _rarity = "RED";
//             else if (roll < 1625) _rarity = "PINK";
//             else if (roll < 7000) _rarity = "PURPLE";
//             else _rarity = "BLUE";
//         }
//         else
//         {
//             if (roll < 26) _rarity = "GOLD";
//             else if (roll < 90) _rarity = "RED";
//             else if (roll < 410) _rarity = "PINK";
//             else if (roll < 1960) _rarity = "PURPLE";
//             else _rarity = "BLUE";
//         }

//         _status = 1;
//     }

//     public void Harvest()
//     {
//         if (_status == 3)
//         {
//             Item item = new Item(_plant, _rarity, _size, _condition);
//             Character.PlayerInventory.AddItem(item);
//             _status = 0;
//         }
//     }

//     public override void Display()
//     {
//         if (_status == 0)
//             Console.Write("_");
//         else if (_status < 3)
//             Console.Write("^");
//         else
//         {
//             Console.ForegroundColor = Item.ColorFromRarity(_rarity);
//             Console.Write("*");
//             Console.ResetColor();
//         }
//     }
// }
// using System;

// public class Fence : Tile
// {
//     public Fence(int x, int y) : base(x, y)
//     {
//         CanPass = false;
//     }

//     public override void Display()
//     {
//         Console.Write("#");
//     }
// }
// using System;

// public class Gate : Tile
// {
//     public Gate(int x, int y) : base(x, y)
//     {
//         CanPass = false;
//     }

//     public override void Display()
//     {
//         Console.Write("G");
//     }

//     public void Leave()
//     {
//         Console.Clear();
//         Console.WriteLine("You leave the farm. Game Over.");
//         Environment.Exit(0);
//     }
// }
// using System;

// public class Tent : Tile
// {
//     public Tent(int x, int y) : base(x, y)
//     {
//         CanPass = false;
//     }

//     public override void Display()
//     {
//         Console.Write("T");
//     }

//     public void Sleep(Character c, List<Tile> tiles)
//     {
//         Console.Clear();
//         Console.WriteLine("Sleeping...");
//         System.Threading.Thread.Sleep(1000);

//         foreach (var t in tiles)
//         {
//             if (t is Farmland f)
//             {
//                 var statusField = typeof(Farmland).GetField("_status", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
//                 int s = (int)statusField.GetValue(f);
//                 if (s == 2)
//                     statusField.SetValue(f, 3);
//             }
//         }
//     }
// }
// using System;

// public class Character
// {
//     public int X { get; private set; }
//     public int Y { get; private set; }

//     private string _facing = "N";

//     public static Inventory PlayerInventory;

//     public int FacingX => _facing == "W" ? X - 1 : _facing == "E" ? X + 1 : X;
//     public int FacingY => _facing == "N" ? Y - 1 : _facing == "S" ? Y + 1 : Y;

//     public Character(int x, int y)
//     {
//         X = x;
//         Y = y;
//     }

//     public void Move(ConsoleKey key)
//     {
//         string dir = key switch
//         {
//             ConsoleKey.W => "N",
//             ConsoleKey.S => "S",
//             ConsoleKey.A => "W",
//             ConsoleKey.D => "E",
//             _ => _facing
//         };

//         if (dir == _facing)
//         {
//             if (dir == "N") Y--;
//             if (dir == "S") Y++;
//             if (dir == "W") X--;
//             if (dir == "E") X++;
//         }
//         else
//         {
//             _facing = dir;
//         }
//     }

//     public bool Location(int x, int y)
//     {
//         return X == x && Y == y;
//     }

//     public void Display()
//     {
//         Console.Write("@");
//     }
// }
// using System;

// public class Inventory
// {
//     public List<Item> Items = new List<Item>();
//     public int LuckySeeds;
//     public int Seeds;
//     public int Coins;

//     public void AddItem(Item i)
//     {
//         Items.Add(i);
//     }

//     public bool BuyItem(string type, int cost)
//     {
//         if (Coins < cost) return false;

//         Coins -= cost;

//         if (type == "Seed") Seeds++;
//         if (type == "LuckySeed") LuckySeeds++;

//         return true;
//     }

//     public void SellMenu()
//     {
//         Console.Clear();
//         Console.WriteLine("SELL ITEMS");
//         Console.WriteLine("Select index to sell, ESC to exit");

//         for (int i = 0; i < Items.Count; i++)
//         {
//             Console.WriteLine($"[{i}] {Items[i].Name} ({Items[i].Value} coins)");
//         }

//         while (true)
//         {
//             var key = Console.ReadKey(true).Key;
//             if (key == ConsoleKey.Escape) return;

//             if (char.IsDigit((char)key))
//             {
//                 int idx = (int)char.GetNumericValue((char)key);
//                 if (idx >= 0 && idx < Items.Count)
//                 {
//                     Coins += Items[idx].Value;
//                     Items.RemoveAt(idx);
//                     return;
//                 }
//             }
//         }
//     }

//     public void SeeInv()
//     {
//         Console.Clear();
//         Console.WriteLine($"Coins: {Coins}");
//         Console.WriteLine($"Seeds: {Seeds}");
//         Console.WriteLine($"Lucky Seeds: {LuckySeeds}\n");

//         foreach (var i in Items)
//         {
//             i.Display();
//         }

//         Console.WriteLine("\nPress ESC to exit inventory.");
//         while (Console.ReadKey(true).Key != ConsoleKey.Escape) { }
//     }

//     public static Inventory FromCSV(string[] lines)
//     {
//         Inventory inv = new Inventory();

//         foreach (string line in lines)
//         {
//             var parts = line.Split(',');
//             if (parts.Length < 5) continue;

//             inv.Items.Add(new Item(parts[0], parts[1], parts[2], parts[3]));
//             inv.Coins = int.Parse(parts[4]);
//         }

//         return inv;
//     }
// }
// using System;

// public class Item
// {
//     public string Name { get; private set; }
//     public string Rarity { get; private set; }
//     public string Size { get; private set; }
//     public string Condition { get; private set; }
//     public int Value { get; private set; }

//     public Item(string name, string rarity, string size, string condition)
//     {
//         Name = name;
//         Rarity = rarity;
//         Size = size;
//         Condition = condition;

//         Value = ComputeValue();
//     }

//     public static ConsoleColor ColorFromRarity(string rarity)
//     {
//         return rarity switch
//         {
//             "GOLD" => ConsoleColor.Yellow,
//             "RED" => ConsoleColor.Red,
//             "PINK" => ConsoleColor.Magenta,
//             "PURPLE" => ConsoleColor.DarkMagenta,
//             "BLUE" => ConsoleColor.Cyan,
//             _ => ConsoleColor.White
//         };
//     }

//     private int ComputeValue()
//     {
//         int baseValue = Name.ToLower() switch
//         {
//             "carrot" => 5,
//             "potato" => 5,
//             "strawberry" => 6,
//             "squash" => 4,
//             "zucchini" => 3,
//             "pepper" => 4,
//             "tomato" => 2,
//             "blueberry" => 7,
//             "corn" => 3,
//             "peas" => 2,
//             _ => 1
//         };

//         double rarityMult = Rarity.ToUpper() switch
//         {
//             "GOLD" => 80.0,
//             "RED" => 20.0,
//             "PINK" => 5.0,
//             "PURPLE" => 1.5,
//             "BLUE" => 1.0,
//             _ => 1.0
//         };

//         double conditionMult = Condition switch
//         {
//             "Super Fresh" => 2.0,
//             "Fresh" => 1.5,
//             "Fair" => 1.2,
//             "Normal" => 1.0,
//             "Slightly Bruised" => 0.9,
//             "Bruised" => 0.7,
//             "Squishy" => 0.5,
//             _ => 1.0
//         };

//         double sizeMult = Size switch
//         {
//             "Jumbo" => 2.0,
//             "Large" => 1.5,
//             "Normal-Large" => 1.2,
//             "Normal" => 1.0,
//             "Normal-Small" => 0.9,
//             "Small" => 0.8,
//             _ => 1.0
//         };

//         double raw = baseValue * rarityMult * conditionMult * sizeMult;
//         return (int)Math.Ceiling(raw);
//     }

//     public void Display()
//     {
//         Console.ForegroundColor = ColorFromRarity(Rarity);
//         Console.WriteLine($"{Name} ({Rarity}) size:{Size} condition:{Condition} value:{Value}");
//         Console.ResetColor();
//     }
// }