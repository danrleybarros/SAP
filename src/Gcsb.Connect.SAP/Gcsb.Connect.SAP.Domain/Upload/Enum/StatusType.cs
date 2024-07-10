using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Gcsb.Connect.SAP.Domain.Upload.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusType
    {
        [EnumMember(Value = "Processing")]
        Processing,
        [EnumMember(Value = "Error")]
        Error,
        [EnumMember(Value = "Success")]
        Success,        
    }
}
