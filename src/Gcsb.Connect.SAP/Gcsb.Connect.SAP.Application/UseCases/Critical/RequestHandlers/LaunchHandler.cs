using Gcsb.Connect.SAP.Domain.Critical;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Critical.RequestHandlers
{
    public class LaunchHandler : Handler
    {
        public override void ProcessRequest(CriticaRequest request)
        {
            request.AddProcessingLog("Start processing Critica - LaunchHandler");

            request.LaunchItems.AddRange(request.Criticas
                .GroupBy(g => new { g.BankCode, RegisterDate = g.RegisterDate.Date })
                .Select(c => new 
                { 
                    c.Key.BankCode,
                    c.Key.RegisterDate,
                    InvoiceAmount = c.Sum(sum => sum.InvoiceAmount)
                })
                .SelectMany(m => request.AccountingEntriesCritica, (critica, ae) => new { critica, ae })
                .Select(s => new LaunchCritical(
                    1,
                    s.critica.RegisterDate,
                    s.ae.FinancialAccount,
                    s.critica.InvoiceAmount,
                    "",
                    $"BCO{s.critica.BankCode}",
                    "",
                    s.ae.AccountingEntryType,
                    s.ae.AccountingAccount
                    )));

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
