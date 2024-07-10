using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Gcsb.Connect.SAP.WebApi.Config.Model.InterestAndFineFinancialAccount
{
    public class FinancialAccount
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public StoreType StoreAcronym;
        public Account Interest { get; set; }
        public Account Fine { get; set; }

        public FinancialAccount(StoreType store, 
            Account interest, Account fine)
        {
            StoreAcronym = store;
            Interest = interest;
            Fine = fine;
        }
    }
}
