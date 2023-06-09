// See https://aka.ms/new-console-template for more information
using ByteVariants;
using System;
using static System.Formats.Asn1.AsnWriter;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello byte v");

        var testdata = Byties.WrongClaTestDataX();

        foreach (var item in testdata)
        {
            Console.Write(item.ToString("X"));
            Console.Write(item.ToString(" "));
            Console.Write(Convert.ToString(item, toBase: 2).PadLeft(8, '0'));
            Console.Write(item.ToString("\n"));
        }

        Console.WriteLine("done");
    }
}