using Gcsb.Connect.SAP.Domain.PAY;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.PAY
{
    public class CriticalBuilder
    {
        public string BankCode;
        public decimal InvoiceAmount;
        public DateTime RegisterDate;
        public DateTime IncludeDate;
        public Guid IdFile;

        public static CriticalBuilder New()
        {
            return new CriticalBuilder
            {
                BankCode = "001",
                InvoiceAmount = 100.0M,
                RegisterDate = DateTime.Now,
                IncludeDate = DateTime.Now,
                IdFile = Guid.NewGuid()
            };
        }

        public CriticalBuilder WithBankCode(string bankCode)
        {
            BankCode = bankCode;
            return this;
        }

        public CriticalBuilder WithInvoiceAmount(decimal invoiceAmount)
        {
            InvoiceAmount = invoiceAmount;
            return this;
        }

        public CriticalBuilder WithRegisterDate(DateTime registerDate)
        {
            RegisterDate = registerDate;
            return this;
        }

        public CriticalBuilder WithIncludeDate(DateTime includeDate)
        {
            IncludeDate = includeDate;
            return this;
        }

        public CriticalBuilder WithIdFile(Guid idFile)
        {
            IdFile = idFile;
            return this;
        }

        public Critical Build()
        {
            return new Critical(BankCode, InvoiceAmount, RegisterDate, IncludeDate, IdFile);
        }
    }
}
