// See https://aka.ms/new-console-template for more information
using TypesX.FS;

Console.WriteLine("- sta x");

var x = ARRef.ByShortRef;
var y = ARRef.FreeAccess;
var z = ARRefAll.All;

Console.WriteLine("{0:X}", x);
Console.WriteLine("{0:X}", y);
Console.WriteLine("{0:X}", z);

var values = Enum.GetValues(typeof(ARRef));

Console.WriteLine("{0:X}", values);

var values2 = Enum.GetValues(typeof(ARRefAll)).Cast<ARRefAll>();
Console.WriteLine("{0:X}", values2);

Console.WriteLine("- fine dev");
