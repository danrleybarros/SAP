using System;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.DeferralFinancialAccount;

namespace Gcsb.Connect.SAP.Tests.Builders.FinancialAccountsClient
{
    public class DeferralFinancialAccountBuilder
    {
        public Guid Id;
        public string Store;
        public string Interface;
        public string ServiceCode;
        public string ServiceName;
        public string OfferCode;
        public string OfferName;
        public string FinancialAccount;
        public DeferralAccount LongTerm;
        public DeferralAccount LongTermLow;
        public DeferralAccount LongTermProvision;
        public DeferralAccount ShortTerm;
        public DeferralAccount ShortTermProvision;
        public DeferralAccount ShortTermLowProvision;
        public DeferralAccount LongTermLowProvision;

        public static DeferralFinancialAccountBuilder New()
        {
            return new DeferralFinancialAccountBuilder
            {
                Id = Guid.NewGuid(),
                Store = "telerese",
                Interface = "Billed",
                ServiceCode = "Office365EnterpriseE3",
                ServiceName = "Office 365 Enterprise E3",
                OfferCode = "Office365EnterpriseE3Offer",
                OfferName = "Vivo Cloud Azure",
                FinancialAccount = "FATAZURECSPGW",
                LongTerm = DeferralAccountBuilder.New().Build(),
                LongTermLow = DeferralAccountBuilder.New().Build(),
                LongTermProvision = DeferralAccountBuilder.New().Build(),
                ShortTerm = DeferralAccountBuilder.New().Build(),
                ShortTermProvision = DeferralAccountBuilder.New().Build(),
                ShortTermLowProvision = DeferralAccountBuilder.New().Build(),
                LongTermLowProvision = DeferralAccountBuilder.New().Build()
            };
        }

        public DeferralFinancialAccountBuilder WithStore(string store)
        {
            Store = store;
            return this;
        }

        public DeferralFinancialAccountBuilder WithInterface(string interfaces)
        {
            Interface = interfaces;
            return this;
        }

        public DeferralFinancialAccountBuilder WithServiceCode(string serviceCode)
        {
            ServiceCode = serviceCode;
            return this;
        }

        public DeferralFinancialAccountBuilder WithOfferCode(string offerCode)
        {
            OfferCode = offerCode;
            return this;
        }

        public DeferralFinancialAccountBuilder WithOfferName(string offerName)
        {
            OfferName = offerName;
            return this;
        }

        public DeferralFinancialAccountBuilder WithFinancialAccount(string financialAccount)
        {
            FinancialAccount = financialAccount;
            return this;
        }

        public DeferralFinancialAccountBuilder WithShortTerm(DeferralAccount shortTerm)
        {
            ShortTerm = shortTerm;
            return this;
        }

        public DeferralFinancialAccountBuilder WithLongTerm(DeferralAccount longTerm)
        {
            LongTerm = longTerm;
            return this;
        }

        public DeferralFinancialAccountBuilder WithLongTermLow(DeferralAccount longTermLow)
        {
            LongTermLow = longTermLow;
            return this;
        }

        public DeferralFinancialAccountBuilder WithLongTermLowProvision(DeferralAccount longTermLowProvision)
        {
            LongTermLowProvision = longTermLowProvision;
            return this;
        }

        public DeferralFinancialAccountBuilder WithLongTermProvision(DeferralAccount longTermProvision)
        {
            LongTermProvision = longTermProvision;
            return this;
        }

        public DeferralFinancialAccountBuilder WithShortTermProvision(DeferralAccount shortTermProvision)
        {
            ShortTermProvision = shortTermProvision;
            return this;
        }      

        public DeferralFinancialAccountBuilder WithShortTermLowProvision(DeferralAccount shortTermLowProvision)
        {
            ShortTermLowProvision = shortTermLowProvision;
            return this;
        }

        public DeferralFinancialAccount Build()
        => new DeferralFinancialAccount(
            Id,
            Store,
            Interface,
            ServiceCode,
            ServiceName,
            OfferCode,
            OfferName,
            FinancialAccount,
            LongTerm,
            LongTermLow,
            LongTermProvision,
            ShortTerm,
            ShortTermProvision,
            ShortTermLowProvision,
            LongTermLowProvision);
    }
}
