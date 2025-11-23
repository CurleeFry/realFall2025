using System;

class Goal
{
    protected string _name;
    protected string _desc;
    protected bool _done;
    protected int _pts;

    public virtual void NewGoal()
    {
        Console.Write("Goal name: ");
        _name = Console.ReadLine();

        Console.Write("Description: ");
        _desc = Console.ReadLine();

        Console.Write("Points: ");
        _pts = int.Parse(Console.ReadLine());

        _done = false;
    }

    public bool isComplete() => _done;

    public virtual int RecEvent()
    {
        _done = true;
        return _pts;
    }

    public virtual void goalExp()
    {
        string box = _done ? "[X]" : "[ ]";
        Console.WriteLine($"{box} {_name}: {_desc}");
    }

    public virtual string Stringify()
    {
        return $"{nameof(Goal)}:{_name},{_desc},{_done},{_pts}";
    }

    public virtual void LoadBase(string name, string desc, bool done, int pts)
    {
        _name = name;
        _desc = desc;
        _done = done;
        _pts = pts;
    }

    public static Goal Deserialize(string data)
    {
        string[] major = data.Split(':');
        string type = major[0];
        string[] fields = major[1].Split(',');

        string name = fields[0];
        string desc = fields[1];
        bool done = bool.Parse(fields[2]);
        int pts = int.Parse(fields[3]);

        Goal g = type switch
        {
            "Goal" => new Goal(),
            "SimpleGoal" => new SimpleGoal(),
            "EternalGoal" => new EternalGoal(),
            "ChecklistGoal" => new ChecklistGoal().LoadChecklist(fields),
            _ => null
        };

        g?.LoadBase(name, desc, done, pts);
        return g;
    }
}
