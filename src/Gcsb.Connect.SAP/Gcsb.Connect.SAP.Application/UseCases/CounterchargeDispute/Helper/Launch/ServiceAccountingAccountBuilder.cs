using Gcsb.Connect.SAP.Domain.AJU;
using Gcsb.Connect.SAP.Domain.Config;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.Helper
{
    public class ServiceAccountingAccountBuilder
    {
        public List<ServiceAccountingAccountAJU> ServiceAccountingAccounts;

        public static ServiceAccountingAccountBuilder New()
        {
            return new ServiceAccountingAccountBuilder
            {
                ServiceAccountingAccounts = new List<ServiceAccountingAccountAJU>(),
            };
        }

        public ServiceAccountingAccountBuilder WithChargeBackTotalNotUsed(List<FinancialAccount> financialAccounts)
        {
            var serviceAccounting = GetServiceAccountingAccounts(financialAccounts, x => x.ContaFaturaEstornoContestacao);           
            ServiceAccountingAccounts = serviceAccounting.Where(w => w.Key == ChargeBackType.TotalNotUsed).SelectMany(s => s.Value).ToList(); ;
            return this;
        }

        public ServiceAccountingAccountBuilder WithChargeBackTotalUsed(List<FinancialAccount> financialAccounts)
        {
            var serviceAccounting = GetServiceAccountingAccounts(financialAccounts, x => x.ContaFaturaEstornoContestacao);         
            ServiceAccountingAccounts = serviceAccounting.Where(w => w.Key == ChargeBackType.TotalUsed).SelectMany(s => s.Value).ToList();
            return this;
        }

        public ServiceAccountingAccountBuilder WithChargeBackPartialUsed(List<FinancialAccount> financialAccounts)
        {
            var serviceAccounting = GetServiceAccountingAccounts(financialAccounts, x => x.ContaFaturaEstornoContestacao);
            ServiceAccountingAccounts = serviceAccounting.Where(w => w.Key == ChargeBackType.PartialUsed).SelectMany(s => s.Value).ToList();
            return this;
        }

        public ServiceAccountingAccountBuilder WithChargeBackRectifiedBoleto(List<FinancialAccount> financialAccounts)
        {
            var serviceAccounting = GetServiceAccountingAccounts(financialAccounts, x => x.ContaFaturaEstornoContestacao);         
            ServiceAccountingAccounts = serviceAccounting.Where(w => w.Key == ChargeBackType.RetifiedBoleto).SelectMany(s => s.Value).ToList(); ;
            return this;
        }

        public ServiceAccountingAccountBuilder WithChargeBackDebtGranted(List<FinancialAccount> financialAccounts)
        {
            var serviceAccounting = GetServiceAccountingAccounts(financialAccounts, x => x.ContaFaturaDebitoConcedido);         
            ServiceAccountingAccounts = serviceAccounting.Where(w => w.Key == ChargeBackType.DebtGranted).SelectMany(s => s.Value).ToList(); ;

            return this;
        }

        public Dictionary<ChargeBackType, List<ServiceAccountingAccountAJU>> GetServiceAccountingAccounts(List<FinancialAccount> financialAccounts, Func<FinancialAccount, string> groupping)
        {
            var dict = new Dictionary<ChargeBackType, List<ServiceAccountingAccountAJU>>();

            financialAccounts
            .GroupBy(groupping)
            .ToList()
            .ForEach(e =>
            {
                var financial = e.FirstOrDefault();
                dict.Add(ChargeBackType.TotalNotUsed, new List<ServiceAccountingAccountAJU>()
                    {
                       new ServiceAccountingAccountAJU(financial.ContaFaturaEstornoContestacao, TypeAccounting.Credito, financial.ContaContabilESTCredFuturoValorNUTILCred),
                       new ServiceAccountingAccountAJU(financial.ContaFaturaEstornoContestacao, TypeAccounting.Debito, financial.ContaContabilESTCredFuturoValorNUTILDeb)

                    });
                dict.Add(ChargeBackType.TotalUsed, new List<ServiceAccountingAccountAJU>()
                  {
                     new ServiceAccountingAccountAJU(financial.ContaFaturaEstornoContestacao, TypeAccounting.Credito, financial.ContaContabilESTCredFuturoValorUTILCred),
                     new ServiceAccountingAccountAJU(financial.ContaFaturaEstornoContestacao, TypeAccounting.Debito, financial.ContaContabilESTCredFuturoValorUTILDeb)

                  });
                dict.Add(ChargeBackType.PartialUsed, new List<ServiceAccountingAccountAJU>()
                  {
                     new ServiceAccountingAccountAJU(financial.ContaFaturaEstornoContestacao, TypeAccounting.Credito, financial.ContaContabilESTCredFuturoValorUTILCred,financial.ContaContabilESTCredFuturoValorNUTILCred),
                     new ServiceAccountingAccountAJU(financial.ContaFaturaEstornoContestacao, TypeAccounting.Debito, financial.ContaContabilESTCredFuturoValorUTILDeb,financial.ContaContabilESTCredFuturoValorNUTILDeb)

                  });
                dict.Add(ChargeBackType.RetifiedBoleto, new List<ServiceAccountingAccountAJU>()
                {
                     new ServiceAccountingAccountAJU(financial.ContaFaturaEstornoContestacao, TypeAccounting.Credito, financial.EstBoletoRetificadoCred),
                     new ServiceAccountingAccountAJU(financial.ContaFaturaEstornoContestacao, TypeAccounting.Debito, financial.EstBoletoRetificadoDeb)

                 });
                dict.Add(ChargeBackType.DebtGranted, new List<ServiceAccountingAccountAJU>()
                {
                     new ServiceAccountingAccountAJU(financial.ContaFaturaDebitoConcedido, TypeAccounting.Credito, financial.ContaContabilDebitoConcedidoCred),
                     new ServiceAccountingAccountAJU(financial.ContaFaturaDebitoConcedido, TypeAccounting.Debito, financial.ContaContabilDebitoConcedidoDeb)
                 });

            });

            return dict;
        }

        public List<ServiceAccountingAccountAJU> Build() => ServiceAccountingAccounts;

    }
}
