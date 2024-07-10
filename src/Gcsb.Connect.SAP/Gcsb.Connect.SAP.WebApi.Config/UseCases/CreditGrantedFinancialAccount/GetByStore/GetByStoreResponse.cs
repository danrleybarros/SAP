using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.CreditGrantedFinancialAccount.GetByStore
{
    public class GetByStoreResponse
    {
        public Guid Id { get; private set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public StoreType StoreAcronym { get; private set; }
        public string CreditGrantedAJU { get; private set; }
        public string AccountingAccountDeb { get; private set; }
        public string AccountingAccountCred { get; private set; }

        public GetByStoreResponse(Guid id, StoreType storeAcronym, string creditGrantedAJU, string accountingAccountDeb, string accountingAccountCred)
        {
            Id = id;
            StoreAcronym = storeAcronym;
            CreditGrantedAJU = creditGrantedAJU;
            AccountingAccountDeb = accountingAccountDeb;
            AccountingAccountCred = accountingAccountCred;
        }

    }
}
