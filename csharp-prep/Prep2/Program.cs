using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your grade (in number form): ");
        int gradeNum = int.Parse(Console.ReadLine());
        string letGrade;
        bool pass = true;

        if (gradeNum >= 90)
        {
            letGrade = "A";
        }
        else if (gradeNum >= 80)
        {
            letGrade = "B";
        }
        else if (gradeNum >= 70)
        {
            letGrade = "C";
        }
        else if (gradeNum >= 60)
        {
            letGrade = "D";
            pass = false;
        }
        else
        {
            letGrade = "F";
            pass = false;
        }
        Console.WriteLine($"Your letter grade for {gradeNum} is {letGrade}.");
        if (pass == true)
        {
            Console.WriteLine("Congrats! You passed the class.");
        }
        else
        {
            Console.WriteLine("You failed, but at least you'll have a headstart next time you take the class! :) ");
        }

    }
}