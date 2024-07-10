using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Gcsb.Connect.SAP.Domain.Deferral.StatusActivationService.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActivationTypeEnum
    {
        [EnumMember(Value = "Disabled")]
        [Description("Service disabled")]
        Disabled = 0,

        [EnumMember(Value = "Activated")]
        [Description("Service activated")]
        Activated = 1,
    }
}
