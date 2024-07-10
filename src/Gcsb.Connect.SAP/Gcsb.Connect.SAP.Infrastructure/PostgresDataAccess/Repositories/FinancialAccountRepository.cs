using AutoMapper;
using Gcsb.Connect.SAP.Application.Repositories.Config;
using Gcsb.Connect.SAP.Domain.Config;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class FinancialAccountRepository : IFinancialAccountReadOnlyRepository, IFinancialAccountWriteOnlyRepository
    {
        private readonly IMapper mapper;

        public FinancialAccountRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Delete(Guid FinancialAccountId)
        {
            using (Context context = new Context())
            {
                var model = mapper.Map<Entities.FinancialAccount>(context.FinancialAccount.Where(w => w.Id == FinancialAccountId).FirstOrDefault());

                context.FinancialAccount.Remove(model);
                return context.SaveChanges();
            }
        }

        public List<FinancialAccount> GetFinancialAccounts(List<string> listServiceCode)
        {
            var lListAccounts = new List<FinancialAccount>();

            using (var context = new Context())
            {
                lListAccounts = mapper.Map<List<FinancialAccount>>(context.FinancialAccount.Where(w => listServiceCode.Contains(w.ServiceCode)).ToList());
            }

            return lListAccounts;
        }

        public List<FinancialAccount> GetFinancialAccounts()
        {
            var lListAccounts = new List<FinancialAccount>();

            using (var context = new Context())
            {
                lListAccounts = mapper.Map<List<FinancialAccount>>(context.FinancialAccount);
            }

            return lListAccounts;
        }

        public Guid Add(FinancialAccount FinancialAccount)
        {
            var model = mapper.Map<Entities.FinancialAccount>(FinancialAccount);
            using (Context context = new Context())
            {
                context.FinancialAccount.Add(model);
                context.SaveChanges();
                return model.Id;
            }
        }

        public int Add(IEnumerable<FinancialAccount> FinancialAccount)
        {
            var model = mapper.Map<List<Entities.FinancialAccount>>(FinancialAccount);
            using (Context context = new Context())
            {
                context.FinancialAccount.AddRange(model);
                return context.SaveChanges();
            }
        }

        public List<FinancialAccount> GetFinancialAccounts(string serviceCode, string financialAccount, StoreType store)
        {
            var lListAccounts = new List<FinancialAccount>();

            using (var context = new Context())
            {
                IQueryable<Entities.FinancialAccount> lstfinancial = context.FinancialAccount.Where(w => w.StoreType.Equals(store));

                if (!string.IsNullOrEmpty(serviceCode))
                    lstfinancial = lstfinancial.Where(f => f.ServiceCode.Contains(serviceCode));

                if (!string.IsNullOrEmpty(financialAccount))
                    lstfinancial = lstfinancial.Where(w => (
                        w.FaturamentoAJU == financialAccount ||
                        w.FaturamentoFAT == financialAccount ||
                        w.DescontoFAT == financialAccount ||
                        w.ContaContabilFATCred == financialAccount ||
                        w.ContaContabilFATDeb == financialAccount ||
                        w.ContaContabilContestacaoCred == financialAccount ||
                        w.ContaContabilIMPDEB == financialAccount ||
                        w.ContaContabilIMPCRED == financialAccount ||
                        w.BoletoRetificadoDeb == financialAccount ||
                        w.BoletoRetificadoCred == financialAccount ||
                        w.CompensacaoAJU == financialAccount ||
                        w.ContaFuturaAJUDeb == financialAccount ||
                        w.ContaFuturaAJUCred == financialAccount ||
                        w.MultaQuebraContFAT == financialAccount
                    ));

                lListAccounts = mapper.Map<List<FinancialAccount>>(lstfinancial.ToList());
            }

            return lListAccounts;
        }

        public Guid Update(FinancialAccount financialAccount)
        {
            var model = mapper.Map<Entities.FinancialAccount>(financialAccount);
            using (Context context = new Context())
            {
                context.FinancialAccount.Update(model);                
                context.SaveChanges();
                return model.Id;
            }
        }

        public FinancialAccount GetFinancialAccount(string serviceCode, StoreType storeType)
        {
            var accounts = new FinancialAccount();

            using (var context = new Context())
            {
                accounts = mapper.Map<FinancialAccount>(context.FinancialAccount.Where(w => serviceCode == w.ServiceCode && w.StoreType.Equals(storeType)).FirstOrDefault());
            }

            return accounts;
        }

        public List<Domain.Config.FinancialAccountDate.FinancialAccount> GetFinancialAccounts(DateTime date)
        {
            var financialAccounts = new List<Domain.Config.FinancialAccountDate.FinancialAccount>();

            using (var context = new Context())
            {
                var accounts = context.FinancialAccountDate.Where(w => w.LastUpdateDate.Date <= date.Date)
                                 .GroupBy(g => new { g.ServiceCode, g.StoreType })
                                 .Select(s =>
                                     new Domain.Config.FinancialAccountDate.FinancialAccount(
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.Id).First(),
                                             s.Key.ServiceCode,
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ServiceName).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.FaturamentoFAT).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.FaturamentoAJU).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.DescontoFAT).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilFATCred).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilFATDeb).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilContestacaoCred).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilContestacaoDeb).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.BoletoRetificadoDeb).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.BoletoRetificadoCred).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilIMPDEB).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilIMPCRED).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.CompensacaoAJU).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaFuturaAJUDeb).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaFuturaAJUCred).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilAjusteCompetenciaDeb).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilAjusteCompetenciaCred).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilEstimativaCicloDeb).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilEstimativaCicloCred).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.MultaQuebraContFAT).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilMultaContDeb).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilMultaContCred).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilMultaContPagaDeb).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilMultaContPagaCred).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilMultaContNpagaDeb).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilMultaContNpagaCred).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilMultaEstimativaCicloDeb).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilMultaEstimativaCicloCred).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaFaturaEstornoContestacao).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilESTCredFuturoValorNUTILDeb).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilESTCredFuturoValorNUTILCred).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilESTCredFuturoValorUTILDeb).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilESTCredFuturoValorUTILCred).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.EstBoletoRetificadoDeb).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.EstBoletoRetificadoCred).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaFaturaDebitoConcedido).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilDebitoConcedidoDeb).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilDebitoConcedidoCred).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilProdutoNaoEmitidoPagoDeb).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilProdutoNaoEmitidoPagoCred).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilProdutoNaoEmitidoNaoPagoDeb).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilProdutoNaoEmitidoNaoPagoCred).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilRecReceitaDeb).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.ContaContabilRecReceitaCred).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.DateIncluded).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.LastUpdateDate).First(),
                                             s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.IsDeleted).First(),
                                             s.Key.StoreType)

                                     {
                                         IdFinancialAccount = s.Where(w => w.LastUpdateDate == s.Max(m => m.LastUpdateDate)).Select(sel => sel.IdFinancialAccount).First(),
                                     })
                                 .ToList();

                accounts = accounts.Where(w => !w.IsDeleted).OrderBy(o => o.ServiceCode).ToList();
                financialAccounts = mapper.Map<List<Domain.Config.FinancialAccountDate.FinancialAccount>>(accounts);
            }

            return financialAccounts;
        }

        public int Add(Domain.Config.FinancialAccountDate.FinancialAccount financialAccount)
        {
            try
            {
                var retorno = 0;

                using (var context = new Context())
                {
                    context.FinancialAccountDate.Add(mapper.Map<Entities.FinancialAccountDate>(financialAccount));
                    retorno = context.SaveChanges();
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FinancialAccount GetFinancialAccount(Guid id)
        {
            var financialAccount = new FinancialAccount();

            using (var context = new Context())
            {
                financialAccount = mapper.Map<FinancialAccount>(context.FinancialAccount.Where(w => w.Id.Equals(id)).FirstOrDefault());
            }

            return financialAccount;
        }
    }
}
