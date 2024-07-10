using Gcsb.Connect.SAP.Application.Repositories.Config;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.AxiliaryBook.RequestHandlers
{
    public class GetFinancialAccountsHandler : Handler
    {
        private readonly IFinancialAccountReadOnlyRepository financialAccountReadOnlyRepository;

        public GetFinancialAccountsHandler(IFinancialAccountReadOnlyRepository financialAccountReadOnlyRepository)
        {
            this.financialAccountReadOnlyRepository = financialAccountReadOnlyRepository;
        }

        public override void ProcessRequest(AxiliaryBookRequest request)
        {          
            request.AddProcessingLog("Consulting Financial Accounts on database");

            var servicesCode = request.Invoices.SelectMany(s => s.Services).Select(s=> s.ServiceCode).Distinct().ToList();

            request.FinancialAccounts = financialAccountReadOnlyRepository.GetFinancialAccounts(servicesCode);

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
