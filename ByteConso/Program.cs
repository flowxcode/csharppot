// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("hi bytes");

byte[] buffer = new byte[] { 0x01, 0x02, };

var xclone = (byte[])buffer.Clone();
var xcopy = buffer;

// #####################
Console.WriteLine("xcopy before:");
Console.WriteLine(Convert.ToString(xcopy.First(), toBase: 2).PadLeft(8, '0'));
Console.WriteLine(Convert.ToString(xcopy[1], toBase: 2).PadLeft(8, '0'));

xcopy[0] = (byte)(xcopy[0] ^ 0x01);

//Debug.WriteLine(Convert.ToString(xcopy.First(), toBase: 2).PadLeft(8, '0'));

Console.WriteLine("xcopy after:");
Console.WriteLine(Convert.ToString(xcopy.First(), toBase: 2).PadLeft(8, '0'));
Console.WriteLine(Convert.ToString(xcopy[1], toBase: 2).PadLeft(8, '0'));

Console.WriteLine("-");

// #####################
Console.WriteLine("buffer before:");
Console.WriteLine(Convert.ToString(buffer.First(), toBase: 2).PadLeft(8, '0'));
Console.WriteLine(Convert.ToString(buffer[1], toBase: 2).PadLeft(8, '0'));

buffer[0] = (byte)(buffer[0] ^ 0x01);

Console.WriteLine("buffer after:");
Console.WriteLine(Convert.ToString(buffer.First(), toBase: 2).PadLeft(8, '0'));
Console.WriteLine(Convert.ToString(buffer[1], toBase: 2).PadLeft(8, '0'));

Console.WriteLine("-");

// #####################
Console.WriteLine("xclone before:");
Console.WriteLine(Convert.ToString(xclone.First(), toBase: 2).PadLeft(8, '0'));
Console.WriteLine(Convert.ToString(xclone[1], toBase: 2).PadLeft(8, '0'));

xcopy[0] = (byte)(xclone[0] ^ 0x01);

Console.WriteLine("xclone after:");
Console.WriteLine(Convert.ToString(xclone.First(), toBase: 2).PadLeft(8, '0'));
Console.WriteLine(Convert.ToString(xclone[1], toBase: 2).PadLeft(8, '0'));

Console.WriteLine("-");

Console.WriteLine("done");