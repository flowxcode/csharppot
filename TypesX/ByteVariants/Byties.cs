using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteVariants
{
    public class Byties
    {
        public static readonly IEnumerable<byte> ByteRange = Enumerable.Range(0, 256)
            .Select(x => (byte)x);

        public static readonly byte[] AcceptedCla =
        {
            0x00,
            0x10,
            0x0c,
            0x10 | 0x0c,
        };

        public static int DutOS
        {
            get
            {
                var z = Environment.GetEnvironmentVariable("MAR_DUT");
                return Environment.GetEnvironmentVariable("MAR_DUT") switch
                {
                    "JC" => 1,
                    "RAW" => 2,
                    _ => 2,
                };
            }
        }

        private static readonly int[] BitsToIgnoreIfSet = DutOS == 1
            ? new int[] { 0, 1, 2, 3, 4, 6 }
            : new int[] { 0, 1, 2, 3, 4 };

        public IEnumerable<byte> WrongClaTestDataX()
        {
            var x = ByteRange
            .Where(v => IsValidValueToTest(v, BitsToIgnoreIfSet, AcceptedCla));
            return x;
        }

        public bool IsValidValueToTest(byte value, int[] bitsToCheck, byte[] acceptedValues)
        {
            Console.Write(">" + value.ToString("X2"));

            /*Console.Write("\n");
            foreach (var bit in bitsToCheck)
            {
                Console.Write(BinString(bit) + " ");
                Console.Write(BinString(1 << bit) + " ");
                Console.Write(BinString(value) + " ");
                var x = (value & (1 << bit));
                var y = x != 0;
                Console.WriteLine(BinString(x));
            }*/

            var part1 = !bitsToCheck.Any(bit => (value & (1 << bit)) != 0);

            var midarr = new int[] { 0, 1, 2, 3, 4 };
            var partMid = !midarr.Any(bit => (value & (1 << bit)) != 0);

            var part2 = !acceptedValues.Any(classByte => value == classByte);

            if (part1 == false && partMid == true)
            {
                Console.WriteLine("THIS is it");
                /*Assert.Ignore("NA");*/
            }
            var eval = part1 && partMid && part2;

            Console.Write(" " + part1 + " && " + partMid + " && " + part2 + " = " + eval + " ");
            Console.WriteLine("" + value.ToString("X2") + " " + BinString(value));

            /*if (eval == false && bitsToCheck.Length == 6 && DutOS == 1)
            {
                return true;
            }*/

            return eval;
        }

        public string BinString(int x)
        {
            return Convert.ToString(x, toBase: 2).PadLeft(8, '0');
        }
    }
}
