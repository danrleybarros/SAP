using Gcsb.Connect.SAP.Domain;
using Gcsb.Connect.SAP.Domain.AJU;
using Gcsb.Connect.SAP.Domain.Config;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.Helper
{
    public class Launcher : ILauncher
    {
        public List<Launch> GetLaunch(
            ChargeBackType type,
            List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute> counterchargeDisputes,
            List<FinancialAccount> financialAccounts,
            string store,
            DateTime dateFrom,
            DateTime dateTo,
            int lines = 0)
        {

            var storeType = Domain.Util.ToEnum<StoreType>(store);
            var serviceAccountingAccounts = GetAccountingAccountAJU(type, financialAccounts);
            var ignoreList = new List<string>() { "Interest", "Fines", "Payment Credit", "Contractual Fine" };

            return counterchargeDisputes
                 .Where(f => f.StoreAcronym.Equals(store) && !ignoreList.Contains(f.TipoAtividade))
                 .Join(serviceAccountingAccounts, GetFunc(type), s => s.FinancialAccount, (c, a) => new { c, a })
               .GroupBy(g => new { g.a.FinancialAccount, g.c.MetodoPagamento, g.c.TipoDisputa, g.c.UF, g.a.Type })
               .Select((s) => new Launch(
                   ++lines,
                   dateFrom,
                   s.Key.FinancialAccount,
                   s.Key.Type == TypeAccounting.Debito ? s.Sum(m => m.c.ValorTransacao) : s.Sum(m => Math.Abs(m.c.ValorContestado.Value)) - s.Sum(m => m.c.ValorTransacao),
                   Util.GetUF(s.Key.UF, storeType).InternalOrder,
                   dateTo,
                   s.Key.UF,
                   s.FirstOrDefault().c.MetodoPagamento.RemoveAccents(),
                   s.Key.Type.GetAttributeOfType<EnumMemberAttribute>().Value,
                   s.FirstOrDefault().a.AccountingAccount[0],
                   storeType
                   ))
               .ToList();
        }

        private Func<Domain.JSDN.CounterChargeDispute.CounterchargeDispute, string> GetFunc(ChargeBackType type)
        {
            if (type == ChargeBackType.DebtGranted)
                return s => s.FinancialAccount.ContaFaturaDebitoConcedido;
            else
                return s => s.FinancialAccount.ContaFaturaEstornoContestacao;
        }

        private List<ServiceAccountingAccountAJU> GetAccountingAccountAJU(ChargeBackType type, List<FinancialAccount> financialAccounts)
        {
            return type switch
            {
                ChargeBackType.TotalNotUsed => ServiceAccountingAccountBuilder.New().WithChargeBackTotalNotUsed(financialAccounts).Build(),
                ChargeBackType.TotalUsed => ServiceAccountingAccountBuilder.New().WithChargeBackTotalUsed(financialAccounts).Build(),
                ChargeBackType.PartialUsed => ServiceAccountingAccountBuilder.New().WithChargeBackPartialUsed(financialAccounts).Build(),
                ChargeBackType.DebtGranted => ServiceAccountingAccountBuilder.New().WithChargeBackDebtGranted(financialAccounts).Build(),
                ChargeBackType.RetifiedBoleto => ServiceAccountingAccountBuilder.New().WithChargeBackRectifiedBoleto(financialAccounts).Build(),
                _ => throw new NotSupportedException()
            };
        }
    }
}
