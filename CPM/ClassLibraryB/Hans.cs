using ClassLibraryA;
using System.Diagnostics;

namespace ClassLibraryB
{
    public class Hans
    {
        public void Essen()
        {
            var sublib = new BottomDive();

            sublib.Diving();

            Console.WriteLine("eat....");

            var j = new Newtonsoft.Json.Linq.JObject();
        }
    }
}