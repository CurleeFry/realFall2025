class SimpleGoal : Goal
{
    // A simple goal completes once, then awards 0 points on repeats
    public override int RecEvent()
    {
        if (!_done)
        {
            _done = true;
            return _pts;
        }
        return 0;
    }

    public override string Stringify()
    {
        return $"{nameof(SimpleGoal)}:{_name},{_desc},{_done},{_pts}";
    }
}
