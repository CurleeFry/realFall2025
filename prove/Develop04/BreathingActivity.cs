public class BreathingActivity : Activity
{


    public override void LoadActivity()
    {
        _activityName = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        DisplayStartMsg();
        Console.Clear();
        StartTimer();
        while (true)
        {
            Console.WriteLine("Breathe in... ");
            LoadIcon(5);
            Console.Clear();
            Console.WriteLine("Breathe out... ");
            LoadIcon(5);
            Console.Clear();
            if (Tim())
            {
                break;
            }
            else
            {
                Console.WriteLine();
            }
        }
        DisplayEndMsg();
    }
}