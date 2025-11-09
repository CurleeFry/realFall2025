public class ListingActivity : Activity
{

    List<string> _prompts = [

            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        ];

    public override void LoadActivity()
    {
        _activityName = "Reflecting activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        DisplayStartMsg();
        Console.Clear();
        Console.WriteLine("List as many responses as you can to the following prompt.");
        Console.WriteLine();
        Console.WriteLine(RandomReturn(_prompts));
        Console.WriteLine();
        Console.WriteLine("Take this time to think about the prompt. You may begin listing momentarily...  ");
        LoadIcon(10);
        Console.WriteLine("Please begin now.");
        StartTimer();
        while (true)
        {
            Console.Write("> ");
            Console.ReadLine();
            if (Tim())
            {
                break;
            }
        }
        DisplayEndMsg();
    }
}