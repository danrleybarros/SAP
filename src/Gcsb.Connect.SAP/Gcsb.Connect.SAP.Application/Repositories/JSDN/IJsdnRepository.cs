using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.Repositories.JSDN
{
    public interface IJsdnRepository
    {
        List<CounterchargeDispute> GetAllCounterchargeDispute(DateTime from, DateTime to);
        List<CounterchargeDispute> GetAllCounterchargeDisputeBilling(DateTime from, DateTime to);
        List<CounterchargeDispute> GetCounterchargeDispute(DateTime from, DateTime to);
        List<CounterchargeDispute> GetCounterchargeDisputeByInvoice(List<string> invoicesNumber);
        List<CounterchargeDispute> GetCounterchargeDisputeByInvoiceAndTransactionType(List<string> invoicesNumber, string transactionType);
        List<CounterchargeDispute> GetCounterChargeDisputeByCycle(DateTime from, DateTime to);
        List<PaymentReport> GetPaymentReportsByInvoices(List<string> invoicesNumber);
    }
}
