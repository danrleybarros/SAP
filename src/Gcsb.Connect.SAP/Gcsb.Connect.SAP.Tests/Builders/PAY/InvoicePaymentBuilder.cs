using System;

namespace Gcsb.Connect.SAP.Tests.Builders.PAY
{
    public class InvoicePaymentBuilder
    {
        public static InvoicePaymentBuilder New()
        {
            return new InvoicePaymentBuilder
            {
                CustomerCode = 7001234567,
                InvoiceNumber = "TST-1-12345678",
                PaidAmount = 100.0m,
                Amount = 150.0m,
                PaymentDate = DateTime.UtcNow.AddDays(-1),
                FormAssignment = "Boleto",
                InvoiceAmount = 150.0m,
                Credit = 0
            };
        }

        #region Properties

        public long CustomerCode;
        public string InvoiceNumber;
        public decimal PaidAmount;
        public decimal Amount;
        public decimal InvoiceAmount;
        public DateTime PaymentDate;
        public string FormAssignment;
        public decimal Credit;
        #endregion

        #region With Methods

        public InvoicePaymentBuilder WithCustomerCode(long customercode)
        {
            CustomerCode = customercode;
            return this;
        }

        public InvoicePaymentBuilder WithInvoiceNumber(string invoicenumber)
        {
            InvoiceNumber = invoicenumber;
            return this;
        }

        public InvoicePaymentBuilder WithPaidAmount(decimal paidamount)
        {
            PaidAmount = paidamount;
            return this;
        }

        public InvoicePaymentBuilder WithInvoiceAmount(decimal invoiceAmount)
        {
            InvoiceAmount = invoiceAmount;
            return this;
        }

        public InvoicePaymentBuilder WithAmount(decimal amount)
        {
            Amount = amount;
            return this;
        }

        public InvoicePaymentBuilder WithPaymentDate(DateTime paymentdate)
        {
            PaymentDate = paymentdate;
            return this;
        }

        public InvoicePaymentBuilder WithFormAssignment(string formassignment)
        {
            FormAssignment = formassignment;
            return this;
        }

        public InvoicePaymentBuilder WithCredit(decimal credit)
        {
            Credit = credit;
            return this;
        }
        #endregion

        #region Build
        public Gcsb.Connect.SAP.Domain.PAY.InvoicePayment Build()
        {
            return new Gcsb.Connect.SAP.Domain.PAY.InvoicePayment(
                        CustomerCode,
                        InvoiceNumber,
                        PaidAmount,
                        Amount,
                        PaymentDate,
                        FormAssignment,
                        InvoiceAmount,
                        Credit);
        }
        #endregion
    }
}
