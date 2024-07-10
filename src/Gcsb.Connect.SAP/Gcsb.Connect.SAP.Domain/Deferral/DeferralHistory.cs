using Gcsb.Connect.SAP.Domain.Validator.Deferral;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;

namespace Gcsb.Connect.SAP.Domain.Deferral
{
    public class DeferralHistory : Entity
    {
        private const string businesslocationTBRA = "3574";
        private const string businesslocationCloudCO = "0107";
        private const string costCenterTBRA = "GW29TR018233";
        private const string costCenterCloudCO = "GW29CR018200";
        private const string paymentOption = "pós-pago";
        private const string filialCode = "29SP";
        public DateTime? BillTo { get; private set; }
        public string OrderId { get; private set; }
        public DateTime OrderCreationDate { get; private set; }
        public string CompanyName { get; private set; }
        public string InvoiceNumber { get; private set; }
        public string ServiceName { get; private set; }
        public string ServiceCode { get; private set; }
        public double GrandTotalRetailPrice { get; private set; }
        public double TotalRetailPrice { get; private set; }
        public string AccountingAccountBillingCredit { get; private set; }
        public string AccountingAccountBillingDebit { get; private set; }
        public string Receivable { get; private set; }
        public string PaymentMethod { get; private set; }
        public string PaymentOption { get => paymentOption; }
        public string CostCenter { get => GetCostCenter(StoreAcronymServiceProvider); }
        public string InternalOrder { get; private set; }
        public string BusinessLocation { get => GetBusinesslocation(StoreAcronymServiceProvider); }
        public string FilialCode { get => filialCode; }
        public string UF { get; private set; }
        public string ServiceType { get; private set; }
        public string ProductStatus { get; private set; }
        public DateTime? ActivationDate { get; private set; }
        public DateTime? ExpirationDate { get; private set; }
        public string FinancialAccount { get; private set; }
        public double DeferralAmount { get; private set; }
        public int NumberOfInstallments { get; private set; }
        public DateTime? DeferralCycleCut { get; private set; }
        public string DeferralDescriptionInstallment { get; private set; }
        public double TotalShortBalance { get; private set; }
        public string AccountingAccountShortTermCreditTotal { get; private set; }
        public string AccountingAccountShortTermDebitTotal { get; private set; }
        public double TotalLongBalance { get; private set; }
        public string AccountingAccountLongTermCreditTotal { get; private set; }
        public string AccountingAccountLongTermDebitTotal { get; private set; }
        public double TransferShortBalanceToLongBalance { get; private set; }
        public string AccountingAccountLongTermCreditInstallment { get; private set; }
        public string AccountingAccountLongTermDebitInstallment { get; private set; }
        public double DeferralAmountProvision { get; private set; }
        public double DeferralAmountShortTermTotal { get; private set; }
        public string AccountingAccountShortTermDeferralCreditInstallment { get; private set; }
        public string AccountingAccountShortTermDeferralDebitInstallment { get; private set; }
        public double DeferralAmountLowProvisionShortTerm { get; private set; }
        public string AccountingAccountShortTermLowProvisionCredit { get; private set; }
        public string AccountingAccountShortTermLowProvisionDebit { get; private set; }
        public double DeferralAmountProvisionLongTerm { get; private set; }
        public string AccountingAccountLongTermProvisionCredit { get; private set; }
        public string AccountingAccountLongTermProvisionDebit { get; private set; }
        public double DeferralAmountLowProvisionLongTerm { get; private set; }
        public string AccountingAccountLongTermLowProvisionCredit { get; private set; }
        public string AccountingAccountLongTermLowProvisionDebit { get; private set; }
        public int ContractDeadline { get; private set; }
        public DateTime DateStartedContract { get; private set; }
        public string StoreAcronymServiceProvider { get; private set; }
        public string CnpjServiceProviderCompany { get; private set; }
        public DeferralType DeferralType { get; private set; }
        public DateTime InclusionDate { get; private set; }    

        public DeferralHistory(DateTime? billTo, string orderId, DateTime orderCreationDate, string companyName, string invoiceNumber, string serviceName, string serviceCode, double grandTotalRetailPrice, double totalRetailPrice, string accountingAccountBillingCredit, string accountingAccountBillingDebit, string receivable, string paymentMethod, string internalOrder, string uF, string serviceType, bool productStatus, DateTime? activationDate, DateTime? expirationDate, string financialAccount, double deferralAmount, int numberOfInstallments, DateTime? deferralCycleCut, string deferralDescriptionInstallment, double totalShortBalance, string accountingAccountShortTermCreditTotal, string accountingAccountLongTermDebitTotal, double totalLongBalance, string accountingAccountLongTermCreditTotal, string accountingAccountLongTermDebit, double transferShortBalanceToLongBalance, string accountingAccountLongTermCreditInstallment, string accountingAccountLongTermDebitInstallment, double deferralAmountProvision, double deferralAmountShortTermTotal, string accountingAccountShortTermDeferralCreditInstallment, string accountingAccountShortTermDeferralDebitInstallment, double deferralAmountLowProvisionShortTerm, string accountingAccountShortTermLowProvisionCredit, string accountingAccountShortTermLowProvisionDebit, double deferralAmountProvisionLongTerm, string accountingAccountLongTermProvisionCredit, string accountingAccountLongTermProvisionDebit, double deferralAmountLowProvisionLongTerm, string accountingAccountLongTermLowProvisionCredit, string accountingAccountLongTermLowProvisionDebit, int contractDeadline, DateTime dateStartedContract, string storeAcronymServiceProvider, string cnpjServiceProviderCompany, DeferralType deferralType, DateTime inclusionDate)
        {
            Id = Guid.NewGuid();
            BillTo = billTo;
            OrderId = orderId;
            OrderCreationDate = orderCreationDate;
            CompanyName = companyName;
            InvoiceNumber = invoiceNumber;
            ServiceName = serviceName;
            ServiceCode = serviceCode;
            GrandTotalRetailPrice = grandTotalRetailPrice;
            TotalRetailPrice = totalRetailPrice;
            AccountingAccountBillingCredit = accountingAccountBillingCredit;
            AccountingAccountBillingDebit = accountingAccountBillingDebit;
            Receivable = receivable;
            PaymentMethod = paymentMethod;
            InternalOrder = internalOrder;
            UF = uF;
            ServiceType = serviceType;
            ProductStatus = GetProductStatusDescription(productStatus);
            ActivationDate = activationDate;
            ExpirationDate = expirationDate;
            FinancialAccount = financialAccount;
            DeferralAmount = deferralAmount;
            NumberOfInstallments = numberOfInstallments;
            DeferralCycleCut = deferralCycleCut;
            DeferralDescriptionInstallment = deferralDescriptionInstallment;
            TotalShortBalance = totalShortBalance;
            AccountingAccountShortTermCreditTotal = accountingAccountShortTermCreditTotal;
            AccountingAccountLongTermDebitTotal = accountingAccountLongTermDebitTotal;
            TotalLongBalance = totalLongBalance;
            AccountingAccountLongTermCreditTotal = accountingAccountLongTermCreditTotal;
            AccountingAccountLongTermCreditTotal = accountingAccountLongTermDebit;
            TransferShortBalanceToLongBalance = transferShortBalanceToLongBalance;
            AccountingAccountLongTermCreditInstallment = accountingAccountLongTermCreditInstallment;
            AccountingAccountLongTermDebitInstallment = accountingAccountLongTermDebitInstallment;
            DeferralAmountProvision = deferralAmountProvision;
            DeferralAmountShortTermTotal = deferralAmountShortTermTotal;
            AccountingAccountShortTermDeferralCreditInstallment = accountingAccountShortTermDeferralCreditInstallment;
            AccountingAccountShortTermDeferralDebitInstallment = accountingAccountShortTermDeferralDebitInstallment;
            DeferralAmountLowProvisionShortTerm = deferralAmountLowProvisionShortTerm;
            AccountingAccountShortTermLowProvisionCredit = accountingAccountShortTermLowProvisionCredit;
            AccountingAccountShortTermLowProvisionDebit = accountingAccountShortTermLowProvisionDebit;
            DeferralAmountProvisionLongTerm = deferralAmountProvisionLongTerm;
            AccountingAccountLongTermProvisionCredit = accountingAccountLongTermProvisionCredit;
            AccountingAccountLongTermProvisionDebit = accountingAccountLongTermProvisionDebit;
            DeferralAmountLowProvisionLongTerm = deferralAmountLowProvisionLongTerm;
            AccountingAccountLongTermLowProvisionCredit = accountingAccountLongTermLowProvisionCredit;
            AccountingAccountLongTermLowProvisionDebit = accountingAccountLongTermLowProvisionDebit;
            ContractDeadline = contractDeadline;
            DateStartedContract = dateStartedContract;
            StoreAcronymServiceProvider = storeAcronymServiceProvider;
            CnpjServiceProviderCompany = cnpjServiceProviderCompany;
            DeferralType = deferralType;
            InclusionDate = inclusionDate;

            Validate(this, new DeferralHistoryValidator());
        }


        private string GetCostCenter(string store)
            => ValidateStore(store) ? store.ToStoreType() == StoreType.TBRA ? costCenterTBRA : costCenterCloudCO : store;

        private string GetBusinesslocation(string store)
            => ValidateStore(store) ? store.ToStoreType() == StoreType.TBRA ? businesslocationTBRA : businesslocationCloudCO : store;

        private bool ValidateStore(string store)
            => !string.IsNullOrEmpty(store);

        private string GetProductStatusDescription(bool isActive)
            => isActive ? "Ativo" : "Inativo";

    }


}
