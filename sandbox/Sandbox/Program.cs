using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        string randomWords = "hello sandbox world!!";
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        string capitalized = textInfo.ToTitleCase(randomWords);
        Console.WriteLine(capitalized);
    }
}