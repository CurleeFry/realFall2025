using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string nombre = PromptUserName();
        int numeroFav = PromptUserNumber();

        int nmoSquared = SquaredNumber(numeroFav);

        int edad;
        PromptUserBirthYear(out edad);

        DisplayResult(nombre, nmoSquared, edad);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int favNum = int.Parse(Console.ReadLine());

        return favNum;
    }

    static void PromptUserBirthYear(out int cumpleanos)
    {
        Console.Write("Please enter the year that you were born: ");
        cumpleanos = int.Parse(Console.ReadLine());
    }

    static int SquaredNumber(int numeroFav)
    {
        int squared = numeroFav * numeroFav;
        return squared;
    }

    static void DisplayResult(string nombre, int nmoSquared, int edad)
    {
        Console.WriteLine($"{nombre}, the square of your number is {nmoSquared}");
        Console.WriteLine($"{nombre}, you will turn {2025 - edad} years old this year.");
    }
}