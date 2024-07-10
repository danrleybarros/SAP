using Autofac.Features.Indexed;
using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.Helper;
using Gcsb.Connect.SAP.Domain.AJU;
using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class ChargeBackLaunchHandler : Handler
    {
        private readonly IIndex<ChargeBackType, IChargeBackStrategy> chargeBackStrategy;
        private readonly IJsdnRepository jsdnRepository;
        private readonly ILauncher launcher;

        public ChargeBackLaunchHandler(IIndex<ChargeBackType, IChargeBackStrategy> chargeBackStrategy, IJsdnRepository jsdnRepository, ILauncher launcher)
        {
            this.chargeBackStrategy = chargeBackStrategy;
            this.jsdnRepository = jsdnRepository;
            this.launcher = launcher;
        }

        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("Processing lines chargeBack");            
            request.CounterchargeDisputes = jsdnRepository.GetCounterChargeDisputeByCycle(request.DateFrom, request.DateTo);
            request.CounterchargeDisputes.ForEach(f => f.FinancialAccount = request.FinancialAccounts.Find(w => w.ServiceCode.Equals(f.CodigoServico)));
            var stores = request.CounterchargeDisputes.Where(w => w.TransactionType == TransactionType.AdjustReversal).Select(s => s.StoreAcronym).Distinct().ToList();

            foreach (var store in stores)
            {
                var storeType = Domain.Util.ToEnum<StoreType>(store);

                if (storeType.Equals(StoreType.Others))
                    continue;

                var launches = new List<Launch>();
                var fileAJULineCount = request.Lines.ContainsKey(storeType) ? request.Lines[storeType].Count : 0;

                chargeBackStrategy[ChargeBackType.TotalNotUsed].Add(request);
                chargeBackStrategy[ChargeBackType.TotalUsed].Add(request);
                chargeBackStrategy[ChargeBackType.PartialUsed].Add(request);
                chargeBackStrategy[ChargeBackType.DebtGranted].Add(request);
                chargeBackStrategy[ChargeBackType.RetifiedBoleto].Add(request);

                request.CounterchargeChargeBack.ToList().ForEach(f =>
                {
                    var chargeBack = launcher.GetLaunch(
                                 f.Key,
                                 f.Value,                                
                                 request.FinancialAccounts,
                                 store,
                                 request.DateFrom,
                                 request.DateTo,                                
                                 fileAJULineCount);

                    fileAJULineCount += chargeBack.Count;

                    launches.AddRange(chargeBack);
                });

                request.AddLaunchs(storeType, launches);
            };
        }
    }
}
