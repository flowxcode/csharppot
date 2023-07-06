// See https://aka.ms/new-console-template for more information
using ByteVariants;
using System;
using System.Security.Cryptography;
using static System.Formats.Asn1.AsnWriter;

internal class Program
{
    public const byte P1Amr = 12;
    public const byte P1AmrHex = 0x12;

    public const byte P2Amr = 3;

    public const byte P1GetData = 63;

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

        var byties = new Byties();
        var testdata = byties.WrongClaTestDataX().ToList();

        Console.WriteLine("\n---------------------------- " + testdata.Count());

        foreach (var item in testdata)
        {
            Console.Write(item.ToString("X2"));
            Console.Write(item.ToString(" "));
            Console.WriteLine(Convert.ToString(item, toBase: 2).PadLeft(8, '0'));
        }

        Console.WriteLine("done " + testdata.Count());
    }
}