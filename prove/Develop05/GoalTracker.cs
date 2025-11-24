using System;

// I think I forgot to add a bonus thing in this week, whoops. That being said I did learn about what a switch is this week and that's pretty cool 
class GoalTracker
{
    private List<Goal> _goals;
    private int _netPts;

    public GoalTracker()
    {
        _goals = new List<Goal>();
        _netPts = 0;
    }

    public void DisplayMenu()
    {
        while (true)
        {
            Console.WriteLine("\n=== GOAL TRACKER ===");
            Console.WriteLine($"Total Points: {_netPts}");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Save goals");
            Console.WriteLine("3. Load goals");
            Console.WriteLine("4. Record progress on a goal");
            Console.WriteLine("5. List all goals");
            Console.WriteLine("6. Quit");
            Console.Write("Your selection: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateNewGoal(); break;
                case "2": Save(); break;
                case "3": Load(); break;
                case "4": RecEvent(); break;
                case "5": ListAllGoals(); break;
                case "6": return;
                default: Console.WriteLine("Invalid selection."); break;
            }
        }
    }

    public void CreateNewGoal()
    {
        Console.WriteLine("\nAvailable goals:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Please choose a goal type (or 4 to cancel): ");

        string input = Console.ReadLine();

        Goal g = input switch
        {
            "1" => new SimpleGoal(),
            "2" => new EternalGoal(),
            "3" => new ChecklistGoal(),
            "4" => null,
            _ => null
        };

        if (g == null)
        {
            Console.WriteLine("Sorry, your input wasn't recognized by the program.");
            return;
        }
        g.NewGoal();
        _goals.Add(g);

    }

    public void ListGoals()
    {
        Console.WriteLine("\nYour goals so far:");
        foreach (var goal in _goals)
            goal.goalExp();
    }
    public void ListAllGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any yet, or they haven't been loaded yet.");
            return;
        }

        Console.WriteLine("\n=== ALL GOALS ===");

        int index = 1;
        foreach (var g in _goals)
        {
            Console.Write($"{index}. ");
            g.goalExp();
            index++;
        }
    }
    public void Save()
    {
        Console.Write("Please enter a name for your goals' save file: ");
        string name = Console.ReadLine();
        string file = name + ".txt";

        using (StreamWriter sw = new StreamWriter(file))
        {
            sw.WriteLine(_netPts);

            foreach (Goal g in _goals)
                sw.WriteLine(g.Stringify());
        }

        Console.WriteLine($"Saved to {file}");
    }

    public void Load()
    {
        Console.Write("Please enter the name of the file you'd like to load from: ");
        string name = Console.ReadLine();
        string file = name + ".txt";

        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(file);
        if (lines.Length == 0)
        {
            Console.WriteLine("File empty.");
            return;
        }

        _netPts = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            Goal g = Goal.Deserialize(lines[i]);
            if (g != null)
                _goals.Add(g);
        }

        Console.WriteLine("Loaded successfully!");
    }

    public void RecEvent()
    {
        var incomplete = _goals.Where(g => !g.isComplete()).ToList();

        if (incomplete.Count == 0)
        {
            Console.WriteLine("No incomplete goals!");
            return;
        }

        Console.WriteLine("\nIncomplete goals:");
        for (int i = 0; i < incomplete.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            incomplete[i].goalExp();
        }

        Console.Write("Please select the goal you want to record progress on: ");
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > incomplete.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Goal g = incomplete[choice - 1];
        int earned = g.RecEvent();
        _netPts += earned;

        if (g.isComplete())
        {
            _goals.Remove(g);
            _goals.Add(g);
        }

        Console.WriteLine($"You earned {earned} points!");
    }
}
