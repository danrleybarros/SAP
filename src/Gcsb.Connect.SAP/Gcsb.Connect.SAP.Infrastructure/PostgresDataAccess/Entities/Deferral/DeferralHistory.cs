using System;
using Gcsb.Connect.SAP.Domain.Deferral;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Deferral
{
    public class DeferralHistory
    {
        public Guid Id { get;  set; }
        public DateTime? BillTo { get;  set; }
        public string OrderId { get;  set; }
        public DateTime OrderCreationDate { get;  set; }
        public string CompanyName { get;  set; }
        public string InvoiceNumber { get;  set; }
        public string ServiceName { get;  set; }
        public string ServiceCode { get;  set; }
        public double GrandTotalRetailPrice { get;  set; }
        public double TotalRetailPrice { get;  set; }
        public string AccountingAccountBillingCredit { get;  set; }
        public string AccountingAccountBillingDebit { get;  set; }
        public string Receivable { get;  set; }
        public string PaymentMethod { get;  set; }
        public string PaymentOption { get;  set; }
        public string CostCenter { get;  set; }
        public string InternalOrder { get;  set; }
        public string BusinessLocation { get;  set; }
        public string FilialCode { get;  set; }
        public string UF { get;  set; }
        public string ServiceType { get;  set; }
        public string ProductStatus { get;  set; }
        public DateTime? ActivationDate { get;  set; }
        public DateTime? ExpirationDate { get;  set; }
        public string FinancialAccount { get;  set; }
        public double DeferralAmount { get;  set; }
        public int NumberOfInstallments { get; set; }
        public DateTime? DeferralCycleCut { get;  set; }
        public string DeferralDescriptionInstallment { get;  set; }
        public double TotalShortBalance { get;  set; }
        public string AccountingAccountShortTermCreditTotal { get;  set; }
        public string AccountingAccountShortTermDebitTotal { get;  set; }
        public double TotalLongBalance { get;  set; }
        public string AccountingAccountLongTermCreditTotal { get;  set; }
        public string AccountingAccountLongTermDebitTotal { get;  set; }
        public double TransferShortBalanceToLongBalance { get;  set; }
        public string AccountingAccountLongTermCreditInstallment { get;  set; }
        public string AccountingAccountLongTermDebitInstallment { get;  set; }
        public double DeferralAmountProvision { get;  set; }
        public double DeferralAmountShortTermTotal { get;  set; }
        public string AccountingAccountShortTermDeferralCreditInstallment { get;  set; }
        public string AccountingAccountShortTermDeferralDebitInstallment { get;  set; }
        public double DeferralAmountLowProvisionShortTerm { get;  set; }
        public string AccountingAccountShortTermLowProvisionCredit { get;  set; }
        public string AccountingAccountShortTermLowProvisionDebit { get;  set; }
        public double DeferralAmountProvisionLongTerm { get;  set; }
        public string AccountingAccountLongTermProvisionCredit { get;  set; }
        public string AccountingAccountLongTermProvisionDebit { get;  set; }
        public double DeferralAmountLowProvisionLongTerm { get;  set; }
        public string AccountingAccountLongTermLowProvisionCredit { get;  set; }
        public string AccountingAccountLongTermLowProvisionDebit { get;  set; }
        public string ContractDeadline { get;  set; }
        public DateTime DateStartedContract { get;  set; }
        public string StoreAcronymServiceProvider { get;  set; }
        public string CnpjServiceProviderCompany { get;  set; }
        public DeferralType DeferralType { get;  set; }
        public DateTime InclusionDate { get; set; }      

    }
}
