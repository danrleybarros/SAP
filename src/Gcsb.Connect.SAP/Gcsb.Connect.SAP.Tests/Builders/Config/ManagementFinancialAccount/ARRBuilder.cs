using System;
using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount;

namespace Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount
{
    public class ARRBuilder
    {      
        public Boleto Boleto;
        public CreditCard CreditCard;

        public static ARRBuilder New()
        {
            return new ARRBuilder
            {             
                Boleto = BoletoBuilder.New().Build(),
                CreditCard = CreditCardBuilder.New().Build()
            };
        }       

        public ARRBuilder WithBoleto(Boleto boleto)
        {
            Boleto = boleto;
            return this;
        }

        public ARRBuilder WithCreditCard(CreditCard creditcard)
        {
            CreditCard = creditcard;
            return this;
        }

        public Domain.Config.ManagementFinancialAccount.ARR Build()
        => new Domain.Config.ManagementFinancialAccount.ARR(Boleto, CreditCard);
    }
}
