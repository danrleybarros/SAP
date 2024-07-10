using Gcsb.Connect.SAP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Tests.Builders
{
    public class PaymentInformationBuilder
    {
        public string OrderNumber;
        public DateTime OrderDate;
        public string CardNumber;
        public string NSU;
        public string CardFlag;
        public string AdmGlobalPayment;
        public string AuthorizationCode;
        public string Division;

        public static PaymentInformationBuilder New()
        {
            return new PaymentInformationBuilder
            {
                OrderNumber = "303030303030303030303030303030",
                OrderDate = DateTime.UtcNow,
                CardNumber = "123456******1234",
                NSU = "ABCDEFGHIJKL",
                CardFlag = "VISAVISAVISAVIS",
                AdmGlobalPayment = "DS",
                AuthorizationCode = "TRUETRUETRUE",
                Division = "24SP"
            };
        }

        public PaymentInformationBuilder WithOrderNumber(string ordernumber)
        {
            OrderNumber = ordernumber;
            return this;
        }

        public PaymentInformationBuilder WithOrderDate(DateTime orderdate)
        {
            OrderDate = orderdate;
            return this;
        }

        public PaymentInformationBuilder WithCardNumber(string cardnumber)
        {
            CardNumber = cardnumber;
            return this;
        }

        public PaymentInformationBuilder WithNSU(string nsu)
        {
            NSU = nsu;
            return this;
        }

        public PaymentInformationBuilder WithCardFlag(string cardflag)
        {
            CardFlag = cardflag;
            return this;
        }

        public PaymentInformationBuilder WithAdmGlobalPayment(string admGlobalPayment)
        {
            AdmGlobalPayment = admGlobalPayment;
            return this;
        }

        public PaymentInformationBuilder WithAuthorizationCode(string authorizationCode)
        {
            AuthorizationCode = authorizationCode;
            return this;
        }

        public PaymentInformationBuilder WithDivision(string division)
        {
            Division = division;
            return this;
        }

        public PaymentInformation Build()
        {
            return new PaymentInformation(OrderNumber, OrderDate, CardNumber, NSU, CardFlag, AdmGlobalPayment, AuthorizationCode, Division);
        }
    }
}
