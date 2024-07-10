using Gcsb.Connect.SAP.Domain.Config;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class ValidateAllServiceCodeHandler : Handler
    {
        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("Validating financial account associed to service code FAT57 - ValidateFinancialAccountAssociedToServiceCodeHandler");
            
            var serviceCode = request.FinancialAccountsNew.Select(s => s.ServiceCode).Distinct().ToList();
            var counterchargeDisputes = request.CounterchargeDisputesAdjustment.Union(request.CounterchargeDisputesBilling);
            var notFoundServiceCode = counterchargeDisputes.Where(w => !serviceCode.Contains(w.CodigoServico) && w.CodigoServico != "").Select(s => s.CodigoServico).ToList();

            if (notFoundServiceCode.Any())
            {
                notFoundServiceCode.ForEach(serviceCode => request.AddExceptionLog($"Service code: {serviceCode} não possui conta", $"Service code: {serviceCode} não possui conta"));
                return;
            }

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }       
    }
}
