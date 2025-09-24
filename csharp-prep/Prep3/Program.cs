using System;

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();

        int magicNum = rand.Next(1, 101);

        Console.WriteLine($"What is the Magic number? {magicNum}");

        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());

        while (guess != magicNum)
        {
            if (guess > magicNum)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Lower");
            }
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("You guessed it!");
    }
}