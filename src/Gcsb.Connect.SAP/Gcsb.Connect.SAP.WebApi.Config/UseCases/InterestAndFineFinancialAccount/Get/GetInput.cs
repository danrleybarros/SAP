using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.InterestAndFineFinancialAccount.Get
{
    public class GetInput
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public StoreType StoreAcronym { get; set; }
    }
}
