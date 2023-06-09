using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteVariants
{
    public static class Byties
    {
        public static readonly IEnumerable<byte> ByteRange = Enumerable.Range(0, 256)
            .Select(x => (byte)x);

        private static readonly byte[] AcceptedCla =
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

        public static IEnumerable<byte> WrongClaTestDataX()
        {
            var x = ByteRange
            .Where(v => IsValidValueToTest(v, BitsToIgnoreIfSet, AcceptedCla));
            return x;
        }

        public static bool IsValidValueToTest(byte value, int[] bitsToCheck, byte[] acceptedValues)
        {
            var eval = !bitsToCheck.Any(bit => (value & (1 << bit)) != 0) &&
                !acceptedValues.Any(classByte => value == classByte);

            if (eval == false && bitsToCheck.Length == 6 && DutOS == 1)
            {
                return true;
            }

            return eval;
        }
    }
}
