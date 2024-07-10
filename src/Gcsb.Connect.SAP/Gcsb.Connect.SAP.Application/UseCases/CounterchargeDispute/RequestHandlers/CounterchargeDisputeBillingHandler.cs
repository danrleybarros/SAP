﻿using Gcsb.Connect.SAP.Application.Repositories.JSDN;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class CounterchargeDisputeBillingHandler : Handler
    {
        private readonly IJsdnRepository jsdnRepository;

        public CounterchargeDisputeBillingHandler(IJsdnRepository jsdnRepository)
        {
            this.jsdnRepository = jsdnRepository;
        }

        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("Consulting CounterchargeDispute - Billing");

            request.CounterchargeDisputesBilling.AddRange(jsdnRepository.GetAllCounterchargeDisputeBilling(request.DateFrom, request.DateTo));

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
