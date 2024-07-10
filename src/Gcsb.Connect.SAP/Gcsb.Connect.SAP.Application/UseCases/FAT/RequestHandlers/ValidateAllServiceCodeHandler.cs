using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers
{
    public class ValidateAllServiceCodeHandler : Handler
    {
        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Validating financial account associed to service code FAT - ValidateFinancialAccountAssociedToServiceCodeHandler");

            //request.Services.ForEach(s => s.Account = request.Accounts.FirstOrDefault(a => a.ServiceCode.ToLower() == s.ServiceCode.ToLower()));

            var serviceWithouAccount = request.Services.Where(w => !request.FinancialAccounts.Select(s => s.ServiceCode).ToList().Contains(w.ServiceCode)).ToList();

            if (serviceWithouAccount.Any())
            {
                serviceWithouAccount.ForEach(f =>
                {
                    request.AddExceptionLog($"Service code: {f.ServiceCode} não possui conta", $"Service code: {f.ServiceCode} não possui conta");
                });

                throw new ArgumentException("Not all services have financial account");
            }

            // Validation ProviderCompanyAcronym
            var servicesWithoutProvider = request.Services.Where(w =>
                   !request.FinancialAccounts.Select(s => s.ServiceCode).ToList().Contains(w.ServiceCode)
                && !request.FinancialAccounts.Select(s => s.StoreAcronym).ToList().Contains(w.StoreAcronym)
                && !request.FinancialAccounts.Select(s => s.ProviderCompanyAcronym).ToList().Contains(w.ProviderCompanyAcronym)).ToList();

            if (servicesWithoutProvider.Any())
            {
                servicesWithoutProvider.ForEach(f =>
                {
                    request.AddExceptionLog($"Service code: {f.ServiceCode} não possui conta provider para {f.ProviderCompanyAcronym}", $"Service code: {f.ServiceCode} não possui conta");
                });

                throw new ArgumentException("Not all services have ProviderCompanyAcronym financial account");
            }

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
