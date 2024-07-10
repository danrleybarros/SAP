using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.CreditGrantedFinancialAccount.ExportCSV
{
    public class ExportCSVInput
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public StoreType? StoreAcronym { get; set; }
    }
}
