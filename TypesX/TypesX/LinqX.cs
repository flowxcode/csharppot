public class LinqX
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int CampaignID { get; set; }

    public LinqX()
    {
        Console.WriteLine("{0}", 1);

        var trailings = new byte[]
        {
            0x98,
            0x99,
        };
        var bytes = new byte[]
        {
            0x00,
            0x03,
            //trailings.SelectMany<byte>(x => x).ToArray()
        };

        var x = bytes.Concat(trailings);
        var str = BitConverter.ToString(x.ToArray());

        Console.WriteLine(str);

        ushort sw = 26368; // 0x6700
        var y = new byte[] { (byte)(sw >> 8), (byte)sw };

        var z1 = sw >> 8;
        var z2 = sw;

        // TODO cons

        Console.WriteLine(str);
    }
}