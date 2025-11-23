class ChecklistGoal : Goal
{
    private int _timesNeeded;
    private int _bonusPoints;
    private int _timesComplete;

    public override void NewGoal()
    {
        base.NewGoal();

        Console.Write("Times needed: ");
        _timesNeeded = int.Parse(Console.ReadLine());

        Console.Write("Bonus points: ");
        _bonusPoints = int.Parse(Console.ReadLine());

        _timesComplete = 0;
    }

    public override int RecEvent()
    {
        _timesComplete++;

        if (_timesComplete >= _timesNeeded)
        {
            _done = true;
            return _pts + _bonusPoints;
        }

        return _pts;
    }

    public override void goalExp()
    {
        string box = _done ? "[X]" : "[ ]";
        Console.WriteLine($"{box} {_name}: {_desc}  ({_timesComplete}/{_timesNeeded})");
    }

    public override string Stringify()
    {
        return $"{nameof(ChecklistGoal)}:{_name},{_desc},{_done},{_pts},{_timesNeeded},{_bonusPoints},{_timesComplete}";
    }

    public ChecklistGoal LoadChecklist(string[] fields)
    {
        _timesNeeded = int.Parse(fields[4]);
        _bonusPoints = int.Parse(fields[5]);
        _timesComplete = int.Parse(fields[6]);
        return this;
    }
}
