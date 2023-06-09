// See https://aka.ms/new-console-template for more information
using ByteVariants;
using System;
using System.Security.Cryptography;
using static System.Formats.Asn1.AsnWriter;

internal class Program
{
    private static void Main(string[] args)
    {
        var env = Environment.GetEnvironmentVariable("MAR_DUT");
        Console.WriteLine($"Hello byte v env:{env?.ToString()}");

        foreach (var item in Byties.AcceptedCla)
        {
            Console.Write(item.ToString("X2"));
            Console.Write(item.ToString(" "));
            Console.WriteLine(Convert.ToString(item, toBase: 2).PadLeft(8, '0'));
        }

        Console.WriteLine("----------------------------");

        var testdata = Byties.WrongClaTestDataX();

        foreach (var item in testdata)
        {
            Console.Write(item.ToString("X2"));
            Console.Write(item.ToString(" "));
            Console.WriteLine(Convert.ToString(item, toBase: 2).PadLeft(8, '0'));
        }

        Console.WriteLine("done");
    }
}