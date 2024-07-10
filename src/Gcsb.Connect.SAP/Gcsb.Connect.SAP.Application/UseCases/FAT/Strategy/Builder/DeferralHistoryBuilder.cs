using System;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.FinancialAccount;
using Gcsb.Connect.SAP.Domain;
using Gcsb.Connect.SAP.Domain.Deferral;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.DeferralFinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.DeferralHistoryBuilder
{
    public class DeferralHistoryBuilder : DeferralAccountingEntry
    {
        private DateTime? billTo;
        private string orderId;
        private DateTime orderCreationDate;
        private string companyName;
        private string invoiceNumber;
        private string serviceName;
        private string serviceCode;
        private double grandTotalRetailPrice;
        private double totalRetailPrice;
        private string accountingAccountBillingCredit;
        private string accountingAccountBillingDebit;
        private string receivable;
        private string paymentMethod;
        private string internalOrder;
        private string uf;
        private string serviceType;
        private bool productStatus;
        private DateTime? activationDate;
        private DateTime? expirationDate;
        private string financialAccount;
        private double deferralAmount;
        private int numberOfInstallments;
        private DateTime? deferralCycleCut;
        private string deferralDescriptionInstallment;
        private double totalShortBalance;
        private string AccountingAccountShortTermCreditTotal;
        private string AccountingAccountShortTermDebitTotal;
        private double totalLongBalance;
        private string AccountingAccountLongTermCreditTotal;
        private string AccountingAccountLongTermDebitTotal;
        private double transferShortBalanceToLongBalance;
        private string AccountingAccountLongTermCreditInstallment;
        private string AccountingAccountLongTermDebitInstallment;
        private double deferralAmountProvision;
        private double DeferralAmountShortTermTotal;
        private string AccountingAccountShortTermDeferralCreditInstallment;
        private string AccountingAccountShortTermDeferralDebitInstallment;
        private double deferralAmountLowProvisionShortTerm;
        private string accountingAccountShortTermLowProvisionCredit;
        private string accountingAccountShortTermLowProvisionDebit;
        private double deferralAmountProvisionLongTerm;
        private string accountingAccountLongTermProvisionCredit;
        private string accountingAccountLongTermProvisionDebit;
        private double deferralAmountLowProvisionLongTerm;
        private string accountingAccountLongTermLowProvisionCredit;
        private string accountingAccountLongTermLowProvisionDebit;
        private int contractDeadline;
        private DateTime dateStartedContract;
        private string storeAcronymServiceProvider;
        private string cnpjServiceProviderCompany;
        private DeferralType deferralType;
        private bool isProvision;
        private bool isNFEmitted;
        private bool isActive;
        private DateTime inclusionDate;
        private bool IsShortTerm;
        private bool IsLongTerm => !IsShortTerm;

        public static DeferralHistoryBuilder New() => new();
        public DeferralHistoryBuilder WithIsProvision(bool isProvision)
        {
            this.isProvision = isProvision;
            return this;
        }

        public DeferralHistoryBuilder WithShortTerm(bool shortTerm)
        {
            IsShortTerm = shortTerm;
            return this;
        }

        public DeferralHistoryBuilder WithIsNFEmitted(bool isNFEmitted)
        {
            this.isNFEmitted = isNFEmitted;
            return this;
        }

        public DeferralHistoryBuilder WithIsActiveService(bool isActive)
        {
            this.isActive = isActive;
            return this;
        }

        public DeferralHistoryBuilder WithBillTo(DateTime? billTo)
        {
            this.billTo = billTo ?? default(DateTime);
            return this;
        }

        public DeferralHistoryBuilder WithOrderId(string orderId)
        {
            this.orderId = orderId;
            return this;
        }

        public DeferralHistoryBuilder WithOrderCreationDate(DateTime? orderCreationDate, DateTime purchase)
        {
            this.orderCreationDate = orderCreationDate == null ? purchase : orderCreationDate ?? default(DateTime);
            return this;
        }

        public DeferralHistoryBuilder WithCompanyName(string companyName)
        {
            this.companyName = companyName ?? string.Empty;
            return this;
        }

        public DeferralHistoryBuilder WithInvoiceNumber(string invoiceNumber)
        {
            this.invoiceNumber = invoiceNumber ?? string.Empty;
            return this;
        }

        public DeferralHistoryBuilder WithServiceName(string serviceName)
        {
            this.serviceName = serviceName ?? string.Empty;
            return this;
        }

        public DeferralHistoryBuilder WithServiceCode(string serviceCode)
        {
            this.serviceCode = serviceCode;
            return this;
        }

        public DeferralHistoryBuilder WithGrandTotalRetailPrice(double grandTotalRetailPrice)
        {
            this.grandTotalRetailPrice = grandTotalRetailPrice;
            return this;
        }

        public DeferralHistoryBuilder WithTotalRetailPrice(double totalRetailPrice)
        {
            this.totalRetailPrice = totalRetailPrice;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountBillingCredit(DeferralOffer offer, AccountDetailsByServiceDto accountingAccounts)
        {
            accountingAccountBillingCredit = GetAccountingAccountBilling(AccountingEntryType.Credit, offer, accountingAccounts);
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountBillingDebit(DeferralOffer offer, AccountDetailsByServiceDto accountingAccounts)
        {
            accountingAccountBillingDebit = GetAccountingAccountBilling(AccountingEntryType.Debit, offer, accountingAccounts);
            return this;
        }

        public DeferralHistoryBuilder WithReceivable(string receivable)
        {
            this.receivable = receivable ?? string.Empty;
            return this;
        }

        public DeferralHistoryBuilder WithPaymentMethod(string paymentMethod)
        {
            this.paymentMethod = paymentMethod;
            return this;
        }

        public DeferralHistoryBuilder WithInternalOrder(string uf, string store)
        {
            internalOrder = (uf == null || store == null) ? null : Util.GetUF(uf, store.ToStoreType())?.InternalOrder;
            return this;
        }

        public DeferralHistoryBuilder WithUf(string uf)
        {
            this.uf = uf;
            return this;
        }

        public DeferralHistoryBuilder WithServiceType(string serviceType)
        {
            this.serviceType = serviceType;
            return this;
        }

        public DeferralHistoryBuilder WithProductStatus(bool productStatus)
        {
            this.productStatus = productStatus;
            return this;
        }

        public DeferralHistoryBuilder WithActivationDate(DateTime? activationDate)
        {
            this.activationDate = activationDate;
            return this;
        }

        public DeferralHistoryBuilder WithExpirationDate(DateTime? expirationDate)
        {
            this.expirationDate = expirationDate;
            return this;
        }

        public DeferralHistoryBuilder WithFinancialAccount(DeferralOffer offer, List<DeferralFinancialAccount> deferralFinancialAccounts)
        {
            this.financialAccount = GetDeferralFinancialAccount(deferralFinancialAccounts, offer)?.FinancialAccount;
            return this;
        }

        public DeferralHistoryBuilder WithDeferralAmount(double deferralAmount)
        {
            this.deferralAmount = !isProvision ? deferralAmount : default(double);
            return this;
        }

        public DeferralHistoryBuilder WithNumberOfInstallments(int numberOfInstallments)
        {
            this.numberOfInstallments = numberOfInstallments;
            return this;
        }

        public DeferralHistoryBuilder WithDeferralCycleCut(DateTime? deferralCycleCut)
        {
            this.deferralCycleCut = deferralCycleCut;
            return this;
        }

        public DeferralHistoryBuilder WithDeferralDescriptionInstallment(string deferralDescriptionInstallment)
        {
            this.deferralDescriptionInstallment = deferralDescriptionInstallment;
            return this;
        }

        public DeferralHistoryBuilder WithTotalShortBalance(double installmentAmount)
        {
            this.totalShortBalance = !isProvision && this.isActive ? installmentAmount : 0;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountShortTermCreditTotal(DeferralOffer offer, List<DeferralFinancialAccount> deferralFinancialAccount)
        {
            AccountingAccountShortTermCreditTotal = !isProvision && this.isActive ? GetAccountingAccountDeferral(AccountingAccountDeferralType.ShortTermTotal, AccountingEntryType.Credit, offer, deferralFinancialAccount) : string.Empty;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountShortTermDebitTotal(DeferralOffer offer, List<DeferralFinancialAccount> deferralFinancialAccount)
        {
            AccountingAccountShortTermDebitTotal = !isProvision && this.isActive ? GetAccountingAccountDeferral(AccountingAccountDeferralType.ShortTermTotal, AccountingEntryType.Debit, offer, deferralFinancialAccount) : string.Empty;
            return this;
        }

        public DeferralHistoryBuilder WithTotalLongBalance(double installmentAmount)
        {
            this.totalLongBalance = !isProvision && IsLongTerm && this.isActive && IsLongTerm ? installmentAmount : 0;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountLongTermCreditTotal(DeferralOffer offer, List<DeferralFinancialAccount> deferralFinancialAccount)
        {
            AccountingAccountLongTermCreditTotal = !isProvision && IsLongTerm && this.isActive && IsLongTerm ? GetAccountingAccountDeferral(AccountingAccountDeferralType.LongTermTotal, AccountingEntryType.Credit, offer, deferralFinancialAccount) : string.Empty;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountLongTermDebitTotal(DeferralOffer offer, List<DeferralFinancialAccount> deferralFinancialAccount)
        {
            AccountingAccountLongTermDebitTotal = !isProvision && IsLongTerm && this.isActive && IsLongTerm ? GetAccountingAccountDeferral(AccountingAccountDeferralType.LongTermTotal, AccountingEntryType.Debit, offer, deferralFinancialAccount) : string.Empty;
            return this;
        }

        public DeferralHistoryBuilder WithTransferShortBalanceToLongBalance(double transferShortBalanceToLongBalance)
        {
            this.transferShortBalanceToLongBalance = !isProvision && IsLongTerm ? transferShortBalanceToLongBalance : 0;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountLongTermCreditInstallment(DeferralOffer offer, List<DeferralFinancialAccount> deferralFinancialAccount)
        {
            AccountingAccountLongTermCreditInstallment = !isProvision && IsLongTerm ? GetAccountingAccountDeferral(AccountingAccountDeferralType.LongTermInstallment, AccountingEntryType.Credit, offer, deferralFinancialAccount) : string.Empty;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountLongTermDebitInstallment(DeferralOffer offer, List<DeferralFinancialAccount> deferralFinancialAccount)
        {
            AccountingAccountLongTermDebitInstallment = !isProvision && IsLongTerm ? GetAccountingAccountDeferral(AccountingAccountDeferralType.LongTermInstallment, AccountingEntryType.Debit, offer, deferralFinancialAccount) : string.Empty;
            return this;
        }

        public DeferralHistoryBuilder WithDeferralAmountProvision(double deferralAmountProvision)
        {
            this.deferralAmountProvision = isProvision ? deferralAmountProvision : default(double);
            return this;
        }

        public DeferralHistoryBuilder WithDeferralAmountShortTermTotal(double deferralAmountProvisionShortTerm)
        {
            DeferralAmountShortTermTotal = !isProvision ? deferralAmountProvisionShortTerm : 0;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountShortTermDeferralCreditInstallment(DeferralOffer offer, List<DeferralFinancialAccount> deferralFinancialAccount)
        {
            var value = !isProvision ? GetAccountingAccountDeferral(AccountingAccountDeferralType.ShortTermInstallment, AccountingEntryType.Credit, offer, deferralFinancialAccount) : string.Empty;
            AccountingAccountShortTermDeferralCreditInstallment = value;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountShortTermDeferralDebitInstallment(DeferralOffer offer, List<DeferralFinancialAccount> deferralFinancialAccount)
        {
            var value = !isProvision ? GetAccountingAccountDeferral(AccountingAccountDeferralType.ShortTermInstallment, AccountingEntryType.Debit, offer, deferralFinancialAccount) : string.Empty;
            AccountingAccountShortTermDeferralDebitInstallment = value;
            return this;
        }

        public DeferralHistoryBuilder WithDeferralAmountLowProvisionShortTerm(double deferralAmountLowProvisionShortTerm)
        {
            this.deferralAmountLowProvisionShortTerm = isProvision && IsShortTerm ? deferralAmountLowProvisionShortTerm : 0;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountShortTermLowProvisionCredit(DeferralOffer offer, List<DeferralFinancialAccount> deferralFinancialAccount)
        {
            var value = isProvision && IsShortTerm ? GetAccountingAccountDeferral(AccountingAccountDeferralType.ShortTermLowProvision, AccountingEntryType.Credit, offer, deferralFinancialAccount) : string.Empty;
            accountingAccountShortTermLowProvisionCredit = value;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountShortTermLowProvisionDebit(DeferralOffer offer, List<DeferralFinancialAccount> deferralFinancialAccount)
        {
            var value = isProvision && IsShortTerm ? GetAccountingAccountDeferral(AccountingAccountDeferralType.ShortTermLowProvision, AccountingEntryType.Debit, offer, deferralFinancialAccount) : string.Empty;
            accountingAccountShortTermLowProvisionDebit = value;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountLongTermProvisionCredit(DeferralOffer offer, List<DeferralFinancialAccount> deferralFinancialAccount)
        {
            var value = isProvision && IsLongTerm ? GetAccountingAccountDeferral(AccountingAccountDeferralType.LongTermProvision, AccountingEntryType.Credit, offer, deferralFinancialAccount) : string.Empty;
            accountingAccountLongTermProvisionCredit = value;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountLongTermProvisionDebit(DeferralOffer offer, List<DeferralFinancialAccount> deferralFinancialAccount)
        {
            var value = isProvision && IsLongTerm ? GetAccountingAccountDeferral(AccountingAccountDeferralType.LongTermProvision, AccountingEntryType.Debit, offer, deferralFinancialAccount) : string.Empty;
            accountingAccountLongTermProvisionDebit = value;
            return this;
        }

        public DeferralHistoryBuilder WithDeferralAmountProvisionLongTerm(double deferralAmountProvisionLongTerm)
        {
            this.deferralAmountProvisionLongTerm = isProvision && IsLongTerm ? deferralAmountProvisionLongTerm : 0;
            return this;
        }

        public DeferralHistoryBuilder WithDeferralAmountLowProvisionLongTerm(double deferralAmountLowProvisionLongTerm)
        {
            this.deferralAmountLowProvisionLongTerm = isProvision && IsLongTerm ? deferralAmountLowProvisionLongTerm : 0;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountLongTermLowProvisionCredit(DeferralOffer offer, List<DeferralFinancialAccount> deferralFinancialAccount)
        {
            var value = isProvision && IsLongTerm ? GetAccountingAccountDeferral(AccountingAccountDeferralType.LongTermLowProvision, AccountingEntryType.Credit, offer, deferralFinancialAccount) : string.Empty;
            accountingAccountLongTermLowProvisionCredit = value;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountLongTermLowProvisionDebit(DeferralOffer offer, List<DeferralFinancialAccount> deferralFinancialAccount)
        {
            var value = isProvision && IsLongTerm ? GetAccountingAccountDeferral(AccountingAccountDeferralType.LongTermLowProvision, AccountingEntryType.Debit, offer, deferralFinancialAccount) : string.Empty;
            accountingAccountLongTermLowProvisionDebit = value;
            return this;
        }

        public DeferralHistoryBuilder WithContractDeadline(int contractDeadline)
        {
            this.contractDeadline = contractDeadline;
            return this;
        }

        public DeferralHistoryBuilder WithDateStartedContract(DateTime? dateStartedContract)
        {
            this.dateStartedContract = dateStartedContract ?? default(DateTime);
            return this;
        }

        public DeferralHistoryBuilder WithStoreAcronymServiceProvider(string storeAcronymServiceProvider)
        {
            this.storeAcronymServiceProvider = storeAcronymServiceProvider;
            return this;
        }

        public DeferralHistoryBuilder WithCnpjServiceProviderCompany(string cnpjServiceProviderCompany)
        {
            this.cnpjServiceProviderCompany = cnpjServiceProviderCompany ?? string.Empty;
            return this;
        }

        public DeferralHistoryBuilder WithDeferralType(DeferralType deferralType)
        {
            this.deferralType = deferralType;
            return this;
        }

        public string GetAccountingAccountBilling(AccountingEntryType accountingEntryType, DeferralOffer offer, AccountDetailsByServiceDto AccountingAccounts)
         => GetAccountingAccount(AccountingAccounts, offer, FinancialAccountType.Billed.ToString())
          ?.GetAccountingAccountByType(accountingEntryType);

        public string GetAccountingAccountDeferral(AccountingAccountDeferralType accountingAccountDeferralType, AccountingEntryType accountingEntryType, DeferralOffer offer, List<DeferralFinancialAccount> deferralFinancialAccounts)
            => GetDeferralFinancialAccount(deferralFinancialAccounts, offer)
             ?.GetAccountingAccountByType(accountingAccountDeferralType, accountingEntryType).ToString();

        public DeferralHistoryBuilder WithInclusionDate(DateTime inclusionDate)
        {
            this.inclusionDate = inclusionDate;
            return this;
        }

        public DeferralHistory Build() => new(
                billTo,
                orderId,
                orderCreationDate,
                companyName,
                invoiceNumber,
                serviceName,
                serviceCode,
                grandTotalRetailPrice,
                totalRetailPrice,
                accountingAccountBillingCredit,
                accountingAccountBillingDebit,
                receivable,
                paymentMethod,
                internalOrder,
                uf,
                serviceType,
                productStatus,
                activationDate,
                expirationDate,
                financialAccount,
                deferralAmount,
                numberOfInstallments,
                deferralCycleCut,
                deferralDescriptionInstallment,
                totalShortBalance,
                AccountingAccountShortTermCreditTotal,
                AccountingAccountShortTermDebitTotal,
                totalLongBalance,
                AccountingAccountLongTermCreditTotal,
                AccountingAccountLongTermDebitTotal,
                transferShortBalanceToLongBalance,
                AccountingAccountLongTermCreditInstallment,
                AccountingAccountLongTermDebitInstallment,
                deferralAmountProvision,
                DeferralAmountShortTermTotal,
                AccountingAccountShortTermDeferralCreditInstallment,
                AccountingAccountShortTermDeferralDebitInstallment,
                deferralAmountLowProvisionShortTerm,
                accountingAccountShortTermLowProvisionCredit,
                accountingAccountShortTermLowProvisionDebit,
                deferralAmountProvisionLongTerm,
                accountingAccountLongTermProvisionCredit,
                accountingAccountLongTermProvisionDebit,
                deferralAmountLowProvisionLongTerm,
                accountingAccountLongTermLowProvisionCredit,
                accountingAccountLongTermLowProvisionDebit,
                contractDeadline,
                dateStartedContract,
                storeAcronymServiceProvider,
                cnpjServiceProviderCompany,
                deferralType,
                inclusionDate
            );
    }
}

