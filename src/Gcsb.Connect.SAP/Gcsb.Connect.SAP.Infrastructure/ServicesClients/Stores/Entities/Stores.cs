using Newtonsoft.Json;

namespace Gcsb.Connect.SAP.Infrastructure.ServicesClients.Stores.Entities
{
    public class Stores
    {
        [JsonProperty("store")]
        public Store Store { get; set; }
    }

    public class Store
    {
        [JsonProperty("storeIDPEntityId")]
        public string StoreIDPEntityId { get; set; }

        [JsonProperty("store-acronym")]
        public string StoreAcronym { get; set; }

        [JsonProperty("store-name")]
        public string StoreName { get; set; }

        [JsonProperty("store-status")]
        public string StoreStatus { get; set; }

        [JsonProperty("store-organization")]
        public StoreOrganization StoreOrganization { get; set; }
    }

    public class StoreOrganization
    {
        [JsonProperty("admin")]
        public Address Address { get; set; }

        [JsonProperty("storeUrl")]
        public string StoreUrl { get; set; }

        [JsonProperty("storeAcronym")]
        public string StoreAcronym { get; set; }

        [JsonProperty("municipalTaxpayerReg")]
        public string MunicipalTaxpayerReg { get; set; }

        [JsonProperty("companyCode")]
        public string CompanyCode { get; set; }

        [JsonProperty("branchCode")]
        public string BranchCode { get; set; }

        [JsonProperty("cityHallServiceCode")]
        public string CityHallServiceCode { get; set; }

        [JsonProperty("cityHallServiceDescription")]
        public string CityHallServiceDescription { get; set; }

        [JsonProperty("processNumSpeReg")]
        public string ProcessNumSpeReg { get; set; }

        [JsonProperty("company-id")]
        public int CompanyId { get; set; }

        [JsonProperty("company-acronym")]
        public string CompanyAcronym { get; set; }

        [JsonProperty("company-name")]
        public string CompanyName { get; set; }

        [JsonProperty("custom-info1")]
        public string Custominfo1 { get; set; }

        [JsonProperty("custom-info2")]
        public string Custominfo2 { get; set; }

        [JsonProperty("custom-info3")]
        public string Custominfo3 { get; set; }

        [JsonProperty("custom-info4")]
        public string Custominfo4 { get; set; }

        [JsonProperty("company-status")]
        public string CompanyStatus { get; set; }
    }

    public class Address
    {
        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("address3")]
        public string Address3 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}
