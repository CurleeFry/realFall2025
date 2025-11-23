class EternalGoal : Goal
{
    public override int RecEvent()
    {
        // Eternal goals never complete, always give points
        return _pts;
    }

    public override void goalExp()
    {
        Console.WriteLine($"[∞] {_name}: {_desc}");
        Console.WriteLine("This is an eternal goal.");
    }

    public override string Stringify()
    {
        return $"{nameof(EternalGoal)}:{_name},{_desc},{_done},{_pts}";
    }
}
