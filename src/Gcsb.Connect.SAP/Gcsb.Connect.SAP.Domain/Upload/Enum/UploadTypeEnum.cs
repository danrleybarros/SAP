using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Gcsb.Connect.SAP.Domain.Upload.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UploadTypeEnum
    {
        [EnumMember(Value = "Billfeed")]
        [Description("Processar Billfeed")]
        Billfeed = 0,
        
        [EnumMember(Value = "PaymentFeedBoleto")]
        [Description("Processar Paymentfeed - Boleto")]
        PaymentFeedBoleto = 1,
        
        [EnumMember(Value = "PaymentFeedCartão")]
        [Description("Processar Paymentfeed - Cartão")]
        PaymentFeedCreditCard = 2,

        [EnumMember(Value = "RetornoNFE")]
        [Description("Processar Retorno da NFE")]
        ReturnNF = 3,

        [EnumMember(Value = "InterfaceContestação")]
        [Description("Executar job de geração da interface de contestação")]
        Fat57_79 = 4
    }
}
