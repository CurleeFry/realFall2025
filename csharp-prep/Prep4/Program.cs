using System;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        List<int> numberBank = new List<int>();
        int input = 1;
        float sum = 0;
        float avg = 0;
        float count = 0;

        while (input != 0)
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            numberBank.Add(input);
        }
        foreach (int num in numberBank)
        {
            sum += num;
            if (num != 0)
            {
                count += 1;
            }
        }
        Console.WriteLine($"The sum is: {sum}");
        avg = sum / count;
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {numberBank.Max()}");
        Console.WriteLine($"The smallest number is: {numberBank.Min()}");
    }
}