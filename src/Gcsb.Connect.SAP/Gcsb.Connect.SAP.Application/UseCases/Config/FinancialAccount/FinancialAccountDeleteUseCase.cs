using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.Config;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config
{
    public class FinancialAccountDeleteUseCase : IFinancialAccountDeleteUseCase
    {
        private readonly IFinancialAccountWriteOnlyRepository financialAccountWriteOnlyRepository;
        private readonly IFinancialAccountReadOnlyRepository financialAccountReadOnlyRepository;
        private readonly ILogWriteOnlyRepository LogRepository;

        public FinancialAccountDeleteUseCase(IFinancialAccountWriteOnlyRepository financialAccountWriteOnlyRepository, IFinancialAccountReadOnlyRepository financialAccountReadOnlyRepository, ILogWriteOnlyRepository logRepository)
        {
            this.financialAccountWriteOnlyRepository = financialAccountWriteOnlyRepository;
            this.financialAccountReadOnlyRepository = financialAccountReadOnlyRepository;
            this.LogRepository = logRepository;
        }

        public int Execute(Guid financialAccountId, string userId, string userName)
        {
            try
            {
                var financialAccount = financialAccountReadOnlyRepository.GetFinancialAccount(financialAccountId);
                var financialAccountDate = new Domain.Config.FinancialAccountDate.FinancialAccount(Guid.NewGuid(), financialAccount.ServiceCode, financialAccount.ServiceCodeName, financialAccount.FaturamentoFAT,
                    financialAccount.FaturamentoAJU, financialAccount.DescontoFAT,  
                    financialAccount.ContaContabilFATCred, financialAccount.ContaContabilFATDeb, financialAccount.ContaContabilContestacaoCred, financialAccount.ContaContabilContestacaoDeb,
                    financialAccount.BoletoRetificadoDeb, financialAccount.BoletoRetificadoCred,
                    financialAccount.ContaContabilIMPDEB, financialAccount.ContaContabilIMPCRED, financialAccount.CompensacaoAJU, financialAccount.ContaFuturaAJUDeb, financialAccount.ContaFuturaAJUCred,
                    financialAccount.ContaContabilAjusteCompetenciaDeb, financialAccount.ContaContabilAjusteCompetenciaCred,
                    financialAccount.ContaContabilEstimativaCicloDeb, financialAccount.ContaContabilEstimativaCicloCred,
                    financialAccount.MultaQuebraContFAT, financialAccount.ContaContabilMultaContDeb,
                    financialAccount.ContaContabilMultaContCred, financialAccount.ContaContabilMultaContPagaDeb, financialAccount.ContaContabilMultaContPagaCred, financialAccount.ContaContabilMultaContNpagaDeb,
                    financialAccount.ContaContabilMultaContNpagaCred, financialAccount.ContaContabilMultaEstimativaCicloDeb, financialAccount.ContaContabilMultaEstimativaCicloCred,
                    financialAccount.ContaFaturaEstornoContestacao, financialAccount.ContaContabilESTCredFuturoValorNUTILDeb, financialAccount.ContaContabilESTCredFuturoValorNUTILCred,
                    financialAccount.ContaContabilESTCredFuturoValorUTILDeb, financialAccount.ContaContabilESTCredFuturoValorUTILCred, financialAccount.EstBoletoRetificadoDeb, financialAccount.EstBoletoRetificadoCred,
                    financialAccount.ContaFaturaDebitoConcedido, financialAccount.ContaContabilDebitoConcedidoDeb, financialAccount.ContaContabilDebitoConcedidoCred,
                    financialAccount.ContaContabilProdutoNaoEmitidoPagoDeb,
                    financialAccount.ContaContabilProdutoNaoEmitidoPagoCred, financialAccount.ContaContabilProdutoNaoEmitidoNaoPagoDeb, financialAccount.ContaContabilProdutoNaoEmitidoNaoPagoCred,
                    financialAccount.ContaContabilRecReceitaDeb, financialAccount.ContaContabilRecReceitaCred,
                    null, DateTime.UtcNow, true, financialAccount.StoreType)
                {
                    IdFinancialAccount = financialAccount.Id
                };

                financialAccountWriteOnlyRepository.Delete(financialAccountId);
                financialAccountWriteOnlyRepository.Add(financialAccountDate);

                LogRepository.Add(new Log("FinancialAccountDelete.Execute", "Financial Account deleted", TypeLog.Processing, financialAccountId.ToString(), userId));

                return 1;
            }
            catch (Exception ex)
            {
                LogRepository.Add(new Log("FinancialAccountDelete.Execute", ex.Message, TypeLog.Error, ex.StackTrace, userId));
                return 0;
            }
        }
    }
}
