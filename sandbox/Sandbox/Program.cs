using System;
using System.Globalization;
namespace Sandbox;

class Program
{
    static void Main(string[] args)
    {
        Bin twentyBin = new Bin("Twenties", 20.00, 5);
        Bin tenBin = new Bin("Ten", 10.00, 10);
        // and so on
        Bin pennyBin = new Bin("Pennies", 0.001, 50);


        pennyBin.Alter(11);
        Console.WriteLine(pennyBin.GetDenomintation());
        Console.WriteLine(pennyBin.GetCount());

    }
}