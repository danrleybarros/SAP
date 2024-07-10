using Gcsb.Connect.SAP.Domain.ARR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gcsb.Connect.SAP.Domain.Critical
{
    public class LaunchCritical : LaunchItem
    {
        public LaunchCritical(
            int? lineNumber,
            DateTime launchDate,
            string financialAccount,
            decimal launchValue,
            string secondComplement,
            string type,
            string complement,
            string accountingEntry,
            string accountingAccount)
            : base(
                  lineNumber,
                  launchDate,
                  financialAccount,
                  launchValue,
                  secondComplement,
                  type,
                  complement,
                  accountingEntry,
                  accountingAccount)
        {
        }
    }
}
