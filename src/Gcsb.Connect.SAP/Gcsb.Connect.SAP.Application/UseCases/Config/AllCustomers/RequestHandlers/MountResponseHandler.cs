using Gcsb.Connect.SAP.Application.Boundaries.AllCustomers;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.RequestHandlers
{
    public class MountResponseHandler : Handler
    {
        public override void ProcessRequest(AllCustomersRequest request)
        {
            request.AllCustomersOutputs = request.Customers
                   .GroupJoin(request.Invoices, c => c.InvoiceNumber, i => i.InvoiceNumber, (c, i) => new { c, i })
                   .GroupBy(g => new { g.c.CustomerCode, g.c.CustomerCNPJ, CompanyName = g.c.CompanyName.ToUpper(), StoreAcronym = (g.i.First().StoreAcronym ?? "telerese") })
                   .Select(s => new AllCustomersOutput(
                        s.Key.CustomerCNPJ,
                        s.Key.CustomerCode,
                        s.Key.CompanyName,
                        s.Key.StoreAcronym,
                        request.Stores.Where(w => w.StoreAcronym.Equals(s.Key.StoreAcronym)).First().StoreName
                   ))
                   .Distinct().ToList();

            sucessor?.ProcessRequest(request);
        }
    }
}
