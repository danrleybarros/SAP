using Gcsb.Connect.SAP.Domain.AJU;
using Gcsb.Connect.SAP.Domain.Config;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.Helper
{
    public interface ILauncher
    {
        List<Launch> GetLaunch(
            ChargeBackType type, List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute> counterchargeDisputes,            
            List<FinancialAccount> financialAccounts,
            string store,
            DateTime dateFrom,
            DateTime dateTo,          
            int lines = 0);
    }
}
