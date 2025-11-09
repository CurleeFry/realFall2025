using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;
        PlayLoadingAnimation(5); // play it 5 times
        Console.CursorVisible = true;

        Console.WriteLine("\nDone!");
    }

    static void PlayLoadingAnimation(int repeatCount)
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

        int delay = 150; // milliseconds between frames

        for (int i = 0; i < repeatCount; i++)
        {
            foreach (string frame in frames)
            {
                Console.Write($"\r{frame} ");
                Thread.Sleep(delay);
            }
        }

        // clear the line when done
        Console.Write("\r" + new string(' ', 20) + "\r");
    }
}
