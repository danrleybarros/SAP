using Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Domain.FAT.FATFaturado;
using Gcsb.Connect.SAP.Domain.JSDN;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.Helper
{
    public interface ILauncher
    {
        public List<LaunchFaturado> GetLaunches(ChargeBackType type, List<ServiceFilter> CounterchargeChargebacks, Account financialAccount, 
            string store, DateTime cycle, int lines = 0);
    }
}
