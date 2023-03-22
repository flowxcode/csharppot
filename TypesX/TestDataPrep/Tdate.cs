using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataPrep
{
    internal class Tdate
    {
        public static IEnumerable<string> IFDTestData()
        {

            // SelectADF tests will run with keysets as following:
            var keysetsWithSf1Adf = new Tuple<int, string>[]
            {
                new(11, "2"),
                new(12, "3"),
            };

            foreach (var element in keysetsWithSf1Adf)
            {
                /* keyset SF1 refByTag */
                yield return new string("1");
                yield return new string("2");
            }
        }

        public Tdate()
        {
            Console.WriteLine(IFDTestData());

            Console.WriteLine("-");

            foreach (var x in IFDTestData())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("-");

            Console.WriteLine(IFDTestData);
        }
    }
}
