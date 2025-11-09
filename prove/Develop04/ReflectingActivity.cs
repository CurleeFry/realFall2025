public class ReflectingActivity : Activity
{

    List<string> _prompts = [

            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        ];

    List<string> _questions = [

            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
    ];

    public override void LoadActivity()
    {
        _activityName = "Reflecting activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        DisplayStartMsg();
        Console.Clear();
        Console.WriteLine("This is the Reflecting Activity. For this exersize: ");
        Console.WriteLine(RandomReturn(_prompts));
        Console.WriteLine();
        Console.WriteLine("Once you are ready with your personal experience, press Enter to continue.");
        Console.ReadLine();
        Console.WriteLine("With your experience in mind, please reflect to the following question(s).");
        StartTimer();
        while (true)
        {
            Console.WriteLine(RandomReturn(_questions));
            LoadIcon(8);
            if (Tim())
            {
                DisplayEndMsg();
                break;
            }
        }
    }
}