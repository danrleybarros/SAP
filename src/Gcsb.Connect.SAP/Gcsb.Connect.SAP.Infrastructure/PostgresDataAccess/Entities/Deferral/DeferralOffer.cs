using System;
using Gcsb.Connect.SAP.Domain.Deferral;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Deferral
{
    public class DeferralOffer
    {
        public Guid Id { get;  set; }
        public string CycleDate { get;  set; }
        public string ServiceCode { get;  set; }
        public string OfferCode { get;  set; }
        public string CustomerCode { get;  set; }
        public string OrderNumber { get;  set; }
        public string ProviderStoreAcronym { get;  set; }       
        public string InvoiceNumber { get;  set; }
        public string StoreAcronym { get;  set; }
        public string BillingStateOrProvince { get;  set; }
        public string PaymentMethod { get;  set; }
        public string ServiceType { get;  set; }
        public double TotalShortBalance { get;  set; }
        public double TotalLongBalance { get;  set; }
        public double TotalBalance { get;  set; }
        public double InstallmentAmount { get;  set; }
        public int NumberOfInstallments { get;  set; }
        public int CurrentInstallment { get;  set; }
        public DateTime DeferralCreationDate { get;  set; }
        public DateTime PurchaseDate { get;  set; }
        public DateTime LastUpdatedDate { get;  set; }
        public bool DeferralStarted { get;  set; }
        public bool IsIncomeRecognized { get;  set; }
        public bool IsActive { get;  set; }
        public bool IsNFEmitted { get;  set; }
        public bool HasDiscount { get;  set; }
        public bool IsProvisioned { get;  set; }
        public DeferralType DeferralType { get;  set; }
        public DeferralStatus DeferralStatus { get;  set; }      
        public Guid? BillfeedFileId { get; set; }
        public int ContractPeriod { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
