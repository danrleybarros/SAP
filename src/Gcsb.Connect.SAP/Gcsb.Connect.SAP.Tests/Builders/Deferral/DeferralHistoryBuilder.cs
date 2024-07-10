using Gcsb.Connect.SAP.Domain.Deferral;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.Deferral
{
    public class DeferralHistoryBuilder
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
        private bool isEmitted;
        private bool isActive;
        private DateTime inclusionDate;

        public static DeferralHistoryBuilder New()
            => new DeferralHistoryBuilder()
            {
                billTo = DateTime.UtcNow,
                orderId = "4015110",
                orderCreationDate = DateTime.UtcNow,
                companyName = "Teste Cadastro",
                invoiceNumber = "TlA-1-00044465",
                serviceName = "Amazon Subscription Service",
                serviceCode = "Teste Cadastro\tamazonsubscriptionservicesweden",
                grandTotalRetailPrice = 100.00,
                totalRetailPrice = 100.00,
                accountingAccountBillingCredit = "41435025",
                accountingAccountBillingDebit = "11211142",
                receivable = "SPIAASTBRA",
                paymentMethod = "boleto",
                internalOrder = "C2983AC",
                uf = "AC",
                serviceType = "IAAS",
                productStatus = true,
                activationDate = DateTime.UtcNow,
                expirationDate = DateTime.UtcNow.AddYears(1),
                financialAccount = "FATO365CSPGW",
                deferralAmount = 1200000.00,
                numberOfInstallments = 1,
                deferralCycleCut = DateTime.UtcNow,
                deferralDescriptionInstallment = "1/12",
                totalShortBalance = 1100000.00,
                AccountingAccountShortTermCreditTotal = "8787878",
                AccountingAccountShortTermDebitTotal = "666666",
                totalLongBalance = 1200000.00,
                AccountingAccountLongTermCreditTotal = "7777777",
                AccountingAccountLongTermDebitTotal = "8888888",
                transferShortBalanceToLongBalance = 1200000.00,
                AccountingAccountLongTermCreditInstallment = "5987812",
                AccountingAccountLongTermDebitInstallment = "64578712",
                deferralAmountProvision = 1000000.00,
                DeferralAmountShortTermTotal = 600000.00,
                AccountingAccountShortTermDeferralCreditInstallment = "59845426",
                AccountingAccountShortTermDeferralDebitInstallment = "95124585",
                deferralAmountLowProvisionShortTerm = 500000.00,
                accountingAccountShortTermLowProvisionCredit = "7532654",
                accountingAccountShortTermLowProvisionDebit = "8456231",
                deferralAmountProvisionLongTerm = 400000.00,
                accountingAccountLongTermProvisionCredit = "8521479",
                accountingAccountLongTermProvisionDebit = "963258",
                deferralAmountLowProvisionLongTerm = 300000.00,
                accountingAccountLongTermLowProvisionCredit = "258741",
                accountingAccountLongTermLowProvisionDebit = "852147",
                contractDeadline = 12,
                dateStartedContract = DateTime.UtcNow,
                storeAcronymServiceProvider = "telerese",
                cnpjServiceProviderCompany = "10.556.034/0001-98",
                deferralType = DeferralType.LongTermInitialDeferralNFEmittedActivatedService,
                isProvision = false,
                isEmitted = false,
                isActive = true,
                inclusionDate = DateTime.UtcNow
            };

        public DeferralHistoryBuilder WithIsProvision(bool isProvision)
        {
            this.isProvision = isProvision;
            return this;
        }

        public DeferralHistoryBuilder WithIsEmitted(bool isEmitted)
        {
            this.isEmitted = isEmitted;
            return this;
        }

        public DeferralHistoryBuilder WithIsActiveService(bool isActive)
        {
            this.isActive = isActive;
            return this;
        }

        public DeferralHistoryBuilder WithBillTo(DateTime? billTo)
        {
            this.billTo = billTo;
            return this;
        }

        public DeferralHistoryBuilder WithOrderId(string orderId)
        {
            this.orderId = orderId;
            return this;
        }

        public DeferralHistoryBuilder WithOrderCreationDate(DateTime orderCreationDate)
        {
            this.orderCreationDate = orderCreationDate;
            return this;
        }

        public DeferralHistoryBuilder WithCompanyName(string companyName)
        {
            this.companyName = companyName;
            return this;
        }

        public DeferralHistoryBuilder WithInvoiceNumber(string invoiceNumber)
        {
            this.invoiceNumber = invoiceNumber;
            return this;
        }

        public DeferralHistoryBuilder WithServiceName(string serviceName)
        {
            this.serviceName = serviceName;
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

        public DeferralHistoryBuilder WithAccountingAccountBillingCredit(string accountingAccountBillingCredit)
        {
            this.accountingAccountBillingCredit = accountingAccountBillingCredit;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountBillingDebit(string accountingAccountBillingDebit)
        {
            this.accountingAccountBillingDebit = accountingAccountBillingDebit;
            return this;
        }

        public DeferralHistoryBuilder WithReceivable(string receivable)
        {
            this.receivable = receivable;
            return this;
        }

        public DeferralHistoryBuilder WithPaymentMethod(string paymentMethod)
        {
            this.paymentMethod = paymentMethod;
            return this;
        }

        public DeferralHistoryBuilder WithInternalOrder(string internalOrder)
        {
            this.internalOrder = internalOrder;
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

        public DeferralHistoryBuilder WithFinancialAccount(string financialAccount)
        {
            this.financialAccount = financialAccount;
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

        public DeferralHistoryBuilder WithDeferralCycleCut(DateTime deferralCycleCut)
        {
            this.deferralCycleCut = isEmitted ? deferralCycleCut : default(DateTime?);
            return this;
        }

        public DeferralHistoryBuilder WithDeferralDescriptionInstallment(string deferralDescriptionInstallment)
        {
            this.deferralDescriptionInstallment = deferralDescriptionInstallment;
            return this;
        }

        public DeferralHistoryBuilder WithTotalShortBalance(double totalShortBalance)
        {
            this.totalShortBalance = !isProvision ? totalShortBalance : default(double); ;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountShortTermCreditTotal(string accountingAccountShortTermCreditTotal)
        {
            AccountingAccountShortTermCreditTotal = accountingAccountShortTermCreditTotal;
            return this;
        }

        public DeferralHistoryBuilder WithaccountingAccountShortTermDebitTotal(string accountingAccountShortTermDebitTotal)
        {
            AccountingAccountShortTermDebitTotal = accountingAccountShortTermDebitTotal;
            return this;
        }

        public DeferralHistoryBuilder WithTotalLongBalance(double totalLongBalance)
        {
            this.totalLongBalance = !isProvision ? totalLongBalance : default(double);
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountLongTermCreditTotal(string accountingAccountLongTermCreditTotal)
        {
            AccountingAccountLongTermCreditTotal = accountingAccountLongTermCreditTotal;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountLongTermDebitTotal(string accountingAccountLongTermDebitTotal)
        {
            AccountingAccountLongTermDebitTotal = accountingAccountLongTermDebitTotal;
            return this;
        }

        public DeferralHistoryBuilder WithTransferShortBalanceToLongBalance(double transferShortBalanceToLongBalance)
        {
            this.transferShortBalanceToLongBalance = transferShortBalanceToLongBalance;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountLongTermCreditInstallment(string accountingAccountLongTermCreditInstallment)
        {
            AccountingAccountLongTermCreditInstallment = accountingAccountLongTermCreditInstallment;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountLongTermDebitInstallment(string accountingAccountLongTermDebitInstallment)
        {
            AccountingAccountLongTermDebitInstallment = accountingAccountLongTermDebitInstallment;
            return this;
        }

        public DeferralHistoryBuilder WithDeferralAmountProvision(double deferralAmountProvision)
        {
            this.deferralAmountProvision = isProvision ? deferralAmountProvision : default(double);
            return this;
        }

        public DeferralHistoryBuilder WithDeferralAmountProvisionShortTerm(double deferralAmountShortTermTotal)
        {
            DeferralAmountShortTermTotal = isProvision ? deferralAmountShortTermTotal : 0;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountShortTermDeferralCreditInstallment(string accountingAccountShortTermDeferralCreditInstallment)
        {
            AccountingAccountShortTermDeferralCreditInstallment = accountingAccountShortTermDeferralCreditInstallment;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountShortTermDeferralDebitInstallment(string accountingAccountShortTermDeferralDebitInstallment)
        {
            AccountingAccountShortTermDeferralDebitInstallment = accountingAccountShortTermDeferralDebitInstallment;
            return this;
        }

        public DeferralHistoryBuilder WithDeferralAmountLowProvisionShortTerm(double deferralAmountLowProvisionShortTerm)
        {
            this.deferralAmountLowProvisionShortTerm = isProvision ? deferralAmountLowProvisionShortTerm : 0;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountShortTermLowProvisionCredit(string accountingAccountShortTermLowProvisionCredit)
        {
            this.accountingAccountShortTermLowProvisionCredit = accountingAccountShortTermLowProvisionCredit;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountShortTermLowProvisionDebit(string accountingAccountShortTermLowProvisionDebit)
        {
            this.accountingAccountShortTermLowProvisionDebit = accountingAccountShortTermLowProvisionDebit;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountLongTermProvisionCredit(string accountingAccountLongTermProvisionCredit)
        {
            this.accountingAccountLongTermProvisionCredit = accountingAccountLongTermProvisionCredit;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountLongTermProvisionDebit(string accountingAccountLongTermProvisionDebit)
        {
            this.accountingAccountLongTermProvisionDebit = accountingAccountLongTermProvisionDebit;
            return this;
        }

        public DeferralHistoryBuilder WithDeferralAmountProvisionLongTerm(double deferralAmountProvisionLongTerm)
        {
            this.deferralAmountProvisionLongTerm = isProvision ? deferralAmountProvisionLongTerm : 0;
            return this;
        }

        public DeferralHistoryBuilder WithDeferralAmountLowProvisionLongTerm(double deferralAmountLowProvisionLongTerm)
        {
            this.deferralAmountLowProvisionLongTerm = isProvision ? deferralAmountLowProvisionLongTerm : 0;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountLongTermLowProvisionCredit(string accountingAccountLongTermLowProvisionCredit)
        {
            this.accountingAccountLongTermLowProvisionCredit = accountingAccountLongTermLowProvisionCredit;
            return this;
        }

        public DeferralHistoryBuilder WithAccountingAccountLongTermLowProvisionDebit(string accountingAccountLongTermLowProvisionDebit)
        {
            this.accountingAccountLongTermLowProvisionDebit = accountingAccountLongTermLowProvisionDebit;
            return this;
        }

        public DeferralHistoryBuilder WithContractDeadline(int contractDeadline)
        {
            this.contractDeadline = contractDeadline;
            return this;
        }

        public DeferralHistoryBuilder WithDateStartedContract(DateTime dateStartedContract)
        {
            this.dateStartedContract = dateStartedContract;
            return this;
        }

        public DeferralHistoryBuilder WithStoreAcronymServiceProvider(string storeAcronymServiceProvider)
        {
            this.storeAcronymServiceProvider = storeAcronymServiceProvider;
            return this;
        }

        public DeferralHistoryBuilder WithCnpjServiceProviderCompany(string cnpjServiceProviderCompany)
        {
            this.cnpjServiceProviderCompany = cnpjServiceProviderCompany;
            return this;
        }

        public DeferralHistoryBuilder WithDeferralType(DeferralType deferralType)
        {
            this.deferralType = deferralType;
            return this;
        }

        public DeferralHistoryBuilder WithInclusionDate(DateTime inclusionDate)
        {
            this.inclusionDate = inclusionDate;
            return this;
        }

        public DeferralHistory Build() => new DeferralHistory(
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


