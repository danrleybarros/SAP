using Gcsb.Connect.Messaging.Messages.Log;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.AxiliaryBook.RequestHandlers
{
    public class ValidateAllServiceCodeHandler : Handler
    {
        public override void ProcessRequest(AxiliaryBookRequest request)
        {
            request.AddProcessingLog("Validating financial account associed to service code FAT - ValidateFinancialAccountAssociedToServiceCodeHandler");

            request.Services = request.Invoices.SelectMany(s => s.Services).ToList();

            var activitiesToAvoid = new List<string> { "credits", "fines", "interest", "payment credit", "contractual fine" };
            request.Services = request.Services.Where(f => !activitiesToAvoid.Contains(f.Activity.ToLower())).ToList();

            request.Services.ForEach(f => f.Account = request.FinancialAccounts.Where(w => w.ServiceCode == f.ServiceCode).FirstOrDefault());

            var serviceWithouAccount = request.Services.Where(w => !request.FinancialAccounts.Select(s => s.ServiceCode).ToList().Contains(w.ServiceCode)).ToList();

            if (serviceWithouAccount.Any())
            {
                var logDetails = new List<LogDetail>();

                serviceWithouAccount.ForEach(f =>
                {
                    logDetails.Add(new LogDetail(string.Empty, $"Service code: {f.ServiceCode} not account"));                     
                });

                request.AddExceptionLog("Not all services have financial account", logDetails);

                return;
            }          

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
