public class Activity
{
    private int _duration;
    protected string _activityName;
    protected string _description;
    private DateTime _startTimeStamp;
    private List<int> unusedIndices = new List<int>();
    private Random random = new Random();
    private int _totalAppTime = 0;
    private Dictionary<string, int> _activityTimes = new Dictionary<string, int>();


    public string RandomReturn(List<string> list)
    {
        if (unusedIndices.Count == 0)
        {
            for (int i = 0; i < list.Count; i++)
                unusedIndices.Add(i);
        }

        int randomListIndex = random.Next(unusedIndices.Count);
        int selectedIndex = unusedIndices[randomListIndex];

        unusedIndices.RemoveAt(randomListIndex);

        return list[selectedIndex];
    }
    public void DisplayStartMsg()
    {
        Console.WriteLine(_activityName);
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine("How many seconds would you like to participate in this activity?");
        Console.Write("> ");
        _duration = int.Parse(Console.ReadLine());
        LoadIcon(3);
    }
    public void DisplayEndMsg()
    {
        _totalAppTime += _duration;
        if (_activityTimes.ContainsKey(_activityName))
        {
            _activityTimes[_activityName] += _duration;
        }
        else
        {
            _activityTimes[_activityName] = _duration;
        }
        Console.WriteLine($"Thanks for doing the activity. You just participated in the {_activityName} for {_duration} seconds.");
        Console.WriteLine($"You've spent a total of {_activityTimes[_activityName]} seconds on this activity, and {_totalAppTime} seconds in the mindfulness app overall.");
        Console.Write("Press Enter when you are ready to go back to the menu.");
        Console.ReadLine();
    }
    public void LoadIcon(int repeatCount)
    {
        string[] frames = {
            "OOOOooo",
            "oOOOOoo",
            "ooOOOOo",
            "oooOOOO",
            "OoooOOO",
            "OOoooOO",
            "OOOoooO"
        };

        int delay = 150;

        for (int i = 0; i < repeatCount; i++)
        {
            foreach (string frame in frames)
            {
                Console.Write($"\r{frame} ");
                Thread.Sleep(delay);
            }
        }
    }
    public virtual void LoadActivity() { }
    public void StartTimer()
    {
        _startTimeStamp = DateTime.Now;
    }
    public bool Tim()
    {
        DateTime current = DateTime.Now;
        TimeSpan passedTim = current - _startTimeStamp;
        return passedTim >= TimeSpan.FromSeconds(_duration);
    }
}