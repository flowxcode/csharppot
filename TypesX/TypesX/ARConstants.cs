using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TypesX.FS
{
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ARRef
    {
        ByShortRef = 0x00,
        ByTagNumber = 0x20,
        SpecialReference = 0x28,
        AnyKeset = 0x30,
        FreeAccess = 0x38,
    }
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ARRefAll
    {
        ByShortRef = 0x00,
        ByTagNumber = 0x20,
        SpecialReference = 0x28,
        AnyKeset = 0x30,
        FreeAccess = 0x38,
        All = 0x40,
        XAll = ByShortRef | ByTagNumber | SpecialReference | AnyKeset | FreeAccess | All,
    }
}
