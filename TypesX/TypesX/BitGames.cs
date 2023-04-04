namespace S2T.RemoveAdf
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// Remove ADF related testcases.
    /// </summary>
    public class RemoveAdf : Seos2TestFixtureContext
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetLogger(nameof(RemoveAdf));
        
        /// <summary>
        /// This Method executes the test case logic for x test
        /// variants.
        /// </summary>
        private void Ex(RemoveApplicationProfile profile)
        {
            for (int i = 0; i < profile.Adfs.Length; i++)
            {
                var currentOid = profile.Adfs[i].AdfObject.Data.Oid;

                var lbyte = currentOid[currentOid.Length - 1];
                var maskbyte = (byte)0x01;
                var lbytex = lbyte ^ maskbyte;

                var lbytev = (byte)(lbyte ^ 0x01);

                var shift1 = 0x01 << 1;
                var shift2 = shift1 << 1;
                var shift3 = shift2 << 1;

                var lbytev1 = (byte)(lbyte ^ shift1);
                var lbytev2 = (byte)(lbyte ^ shift2);
                var lbytev3 = (byte)(lbyte ^ shift3);

                Debug.WriteLine(Convert.ToString(lbyte, toBase: 2).PadLeft(8));
                Debug.WriteLine(Convert.ToString(lbytex, toBase: 2).PadLeft(8));
                Debug.WriteLine(Convert.ToString(lbytev, toBase: 2).PadLeft(8));
                Debug.WriteLine(Convert.ToString(shift1, toBase: 2).PadLeft(8));
                Debug.WriteLine(Convert.ToString(shift2, toBase: 2).PadLeft(8));
                Debug.WriteLine(Convert.ToString(shift3, toBase: 2).PadLeft(8));
                Debug.WriteLine(Convert.ToString(lbytev1, toBase: 2).PadLeft(8));
                Debug.WriteLine(Convert.ToString(lbytev2, toBase: 2).PadLeft(8));
                Debug.WriteLine(Convert.ToString(lbytev3, toBase: 2).PadLeft(8));

                var cmdempty = new RemoveApplicationCommand(new TlvData((uint)Seos2Tags.SEOS_OID, currentOid));
            }
        }
    }
}
