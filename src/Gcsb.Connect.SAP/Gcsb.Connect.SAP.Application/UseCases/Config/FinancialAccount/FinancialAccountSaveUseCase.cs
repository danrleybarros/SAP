using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.Config;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config
{
    public class FinancialAccountSaveUseCase : IFinancialAccountSaveUseCase
    {
        private readonly IFinancialAccountWriteOnlyRepository FinancialAccountRepository;
        private readonly IFinancialAccountReadOnlyRepository FinancialAccountReadRepository;
        private readonly ILogWriteOnlyRepository LogRepository;

        public FinancialAccountSaveUseCase(IFinancialAccountWriteOnlyRepository financialAccountRepository, IFinancialAccountReadOnlyRepository financialAccountReadRepository, ILogWriteOnlyRepository logRepository)
        {
            this.FinancialAccountRepository = financialAccountRepository;
            this.FinancialAccountReadRepository = financialAccountReadRepository;
            this.LogRepository = logRepository;
        }

        public int Execute(FinancialAccountResult financialAccountResult, string UserId, string UserName)
        {
            if (financialAccountResult == null)
                throw new ArgumentException("could not convert object");

            if (string.IsNullOrEmpty(financialAccountResult.ServiceCode) ||
                string.IsNullOrEmpty(financialAccountResult.ServiceName) ||
                string.IsNullOrEmpty(financialAccountResult.FaturamentoFAT) ||
                string.IsNullOrEmpty(financialAccountResult.FaturamentoAJU) ||               
                string.IsNullOrEmpty(financialAccountResult.DescontoFAT) ||
                string.IsNullOrEmpty(financialAccountResult.ContaContabilAjusteCompetenciaDeb) ||
                string.IsNullOrEmpty(financialAccountResult.ContaContabilAjusteCompetenciaCred) ||
                string.IsNullOrEmpty(financialAccountResult.ContaContabilEstimativaCicloDeb) ||
                string.IsNullOrEmpty(financialAccountResult.ContaContabilEstimativaCicloCred)
                || string.IsNullOrEmpty(financialAccountResult.MultaQuebraContFAT)
                )
                throw new ArgumentException("Required field is empty");

            if (financialAccountResult.StoreType == Domain.JSDN.Stores.StoreType.Others)
                throw new ArgumentException("Invalid store");

            
            try
            {
                if (financialAccountResult.Id == null || financialAccountResult.Id == Guid.Empty)
                {
                    if (FinancialAccountReadRepository.GetFinancialAccount(financialAccountResult.ServiceCode,financialAccountResult.StoreType) != null)
                        throw new ArgumentException("ServiceCode already registered.");

                    var financialAccount = new Domain.Config.FinancialAccount(Guid.NewGuid(), financialAccountResult.ServiceCode, financialAccountResult.ServiceName, financialAccountResult.FaturamentoFAT,
                        financialAccountResult.FaturamentoAJU, financialAccountResult.DescontoFAT, financialAccountResult.ContaContabilFATCred, financialAccountResult.ContaContabilFATDeb, financialAccountResult.ContaContabilContestacaoCred, financialAccountResult.ContaContabilContestacaoDeb,
                        financialAccountResult.BoletoRetificadoDeb, financialAccountResult.BoletoRetificadoCred,
                        financialAccountResult.ContaContabilIMPDEB, financialAccountResult.ContaContabilIMPCRED, financialAccountResult.CompensacaoAJU, financialAccountResult.ContaFuturaAJUDeb, financialAccountResult.ContaFuturaAJUCred, financialAccountResult.ContaContabilAjusteCompetenciaDeb, 
                        financialAccountResult.ContaContabilAjusteCompetenciaCred, financialAccountResult.ContaContabilEstimativaCicloDeb,financialAccountResult.ContaContabilEstimativaCicloCred,
                        financialAccountResult.MultaQuebraContFAT, financialAccountResult.ContaContabilMultaContDeb,
                        financialAccountResult.ContaContabilMultaContCred, financialAccountResult.ContaContabilMultaContPagaDeb, financialAccountResult.ContaContabilMultaContPagaCred, financialAccountResult.ContaContabilMultaContNpagaDeb, financialAccountResult.ContaContabilMultaContNpagaCred,
                        financialAccountResult.ContaContabilMultaEstimativaCicloDeb, financialAccountResult.ContaContabilMultaEstimativaCicloCred,
                        financialAccountResult.ContaFaturaEstornoContestacao, financialAccountResult.ContaContabilESTCredFuturoValorNUTILDeb, financialAccountResult.ContaContabilESTCredFuturoValorNUTILCred, financialAccountResult.ContaContabilESTCredFuturoValorUTILDeb,
                        financialAccountResult.ContaContabilESTCredFuturoValorUTILCred, financialAccountResult.EstBoletoRetificadoDeb, financialAccountResult.EstBoletoRetificadoCred, financialAccountResult.ContaFaturaDebitoConcedido, financialAccountResult.ContaContabilDebitoConcedidoDeb,
                        financialAccountResult.ContaContabilDebitoConcedidoCred,
                        financialAccountResult.ContaContabilProdutoNaoEmitidoPagoDeb, financialAccountResult.ContaContabilProdutoNaoEmitidoPagoCred, financialAccountResult.ContaContabilProdutoNaoEmitidoNaoPagoDeb, financialAccountResult.ContaContabilProdutoNaoEmitidoNaoPagoCred,
                        financialAccountResult.ContaContabilRecReceitaDeb, financialAccountResult.ContaContabilRecReceitaCred,
                        financialAccountResult.StoreType);

                    var financialAccountDate = new Domain.Config.FinancialAccountDate.FinancialAccount(Guid.NewGuid(), financialAccountResult.ServiceCode, financialAccountResult.ServiceName,
                        financialAccountResult.FaturamentoFAT, financialAccountResult.FaturamentoAJU, financialAccountResult.DescontoFAT,
                        financialAccountResult.ContaContabilFATCred, financialAccountResult.ContaContabilFATDeb, financialAccountResult.ContaContabilContestacaoCred, financialAccountResult.ContaContabilContestacaoDeb,
                        financialAccountResult.BoletoRetificadoDeb, financialAccountResult.BoletoRetificadoCred,
                        financialAccountResult.ContaContabilIMPDEB, financialAccountResult.ContaContabilIMPCRED, financialAccountResult.CompensacaoAJU, financialAccountResult.ContaFuturaAJUDeb, financialAccountResult.ContaFuturaAJUCred,
                        financialAccountResult.ContaContabilAjusteCompetenciaDeb, financialAccountResult.ContaContabilAjusteCompetenciaCred, financialAccountResult.ContaContabilEstimativaCicloDeb, financialAccountResult.ContaContabilEstimativaCicloCred,
                        financialAccountResult.MultaQuebraContFAT, financialAccountResult.ContaContabilMultaContDeb, financialAccountResult.ContaContabilMultaContCred, financialAccountResult.ContaContabilMultaContPagaDeb, financialAccountResult.ContaContabilMultaContPagaCred,
                        financialAccountResult.ContaContabilMultaContNpagaDeb, financialAccountResult.ContaContabilMultaContNpagaCred, financialAccountResult.ContaContabilMultaEstimativaCicloDeb, financialAccountResult.ContaContabilMultaEstimativaCicloCred,
                        financialAccountResult.ContaFaturaEstornoContestacao, financialAccountResult.ContaContabilESTCredFuturoValorNUTILDeb, financialAccountResult.ContaContabilESTCredFuturoValorNUTILCred, financialAccountResult.ContaContabilESTCredFuturoValorUTILDeb,
                        financialAccountResult.ContaContabilESTCredFuturoValorUTILCred, financialAccountResult.EstBoletoRetificadoDeb, financialAccountResult.EstBoletoRetificadoCred, financialAccountResult.ContaFaturaDebitoConcedido, financialAccountResult.ContaContabilDebitoConcedidoDeb,
                        financialAccountResult.ContaContabilDebitoConcedidoCred,
                        financialAccountResult.ContaContabilProdutoNaoEmitidoPagoDeb, financialAccountResult.ContaContabilProdutoNaoEmitidoPagoCred, financialAccountResult.ContaContabilProdutoNaoEmitidoNaoPagoDeb, financialAccountResult.ContaContabilProdutoNaoEmitidoNaoPagoCred,
                        financialAccountResult.ContaContabilRecReceitaDeb, financialAccountResult.ContaContabilRecReceitaCred,
                        DateTime.UtcNow, DateTime.UtcNow, false, financialAccountResult.StoreType)
                    {
                        IdFinancialAccount = financialAccount.Id
                    };

                    FinancialAccountRepository.Add(financialAccount);
                    FinancialAccountRepository.Add(financialAccountDate);
                }
                else
                {
                    var financialAccount = new Domain.Config.FinancialAccount(financialAccountResult.Id.Value, financialAccountResult.ServiceCode, financialAccountResult.ServiceName, financialAccountResult.FaturamentoFAT,
                        financialAccountResult.FaturamentoAJU, financialAccountResult.DescontoFAT, financialAccountResult.ContaContabilFATCred, financialAccountResult.ContaContabilFATDeb, financialAccountResult.ContaContabilContestacaoCred, financialAccountResult.ContaContabilContestacaoDeb,
                        financialAccountResult.BoletoRetificadoDeb, financialAccountResult.BoletoRetificadoCred,
                        financialAccountResult.ContaContabilIMPDEB, financialAccountResult.ContaContabilIMPCRED, financialAccountResult.CompensacaoAJU, financialAccountResult.ContaFuturaAJUDeb, financialAccountResult.ContaFuturaAJUCred, financialAccountResult.ContaContabilAjusteCompetenciaDeb,
                        financialAccountResult.ContaContabilAjusteCompetenciaCred, financialAccountResult.ContaContabilEstimativaCicloDeb, financialAccountResult.ContaContabilEstimativaCicloCred,
                        financialAccountResult.MultaQuebraContFAT, financialAccountResult.ContaContabilMultaContDeb,
                        financialAccountResult.ContaContabilMultaContCred, financialAccountResult.ContaContabilMultaContPagaDeb, financialAccountResult.ContaContabilMultaContPagaCred, financialAccountResult.ContaContabilMultaContNpagaDeb, financialAccountResult.ContaContabilMultaContNpagaCred,
                        financialAccountResult.ContaContabilMultaEstimativaCicloDeb, financialAccountResult.ContaContabilMultaEstimativaCicloCred,
                        financialAccountResult.ContaFaturaEstornoContestacao, financialAccountResult.ContaContabilESTCredFuturoValorNUTILDeb, financialAccountResult.ContaContabilESTCredFuturoValorNUTILCred, financialAccountResult.ContaContabilESTCredFuturoValorUTILDeb,
                        financialAccountResult.ContaContabilESTCredFuturoValorUTILCred, financialAccountResult.EstBoletoRetificadoDeb, financialAccountResult.EstBoletoRetificadoCred, financialAccountResult.ContaFaturaDebitoConcedido, financialAccountResult.ContaContabilDebitoConcedidoDeb,
                        financialAccountResult.ContaContabilDebitoConcedidoCred,
                        financialAccountResult.ContaContabilProdutoNaoEmitidoPagoDeb, financialAccountResult.ContaContabilProdutoNaoEmitidoPagoCred, financialAccountResult.ContaContabilProdutoNaoEmitidoNaoPagoDeb, financialAccountResult.ContaContabilProdutoNaoEmitidoNaoPagoCred,
                        financialAccountResult.ContaContabilRecReceitaDeb, financialAccountResult.ContaContabilRecReceitaCred,
                        financialAccountResult.StoreType);

                    var financialAccountDate = new Domain.Config.FinancialAccountDate.FinancialAccount(Guid.NewGuid(), financialAccountResult.ServiceCode, financialAccountResult.ServiceName,
                        financialAccountResult.FaturamentoFAT, financialAccountResult.FaturamentoAJU, financialAccountResult.DescontoFAT,
                        financialAccountResult.ContaContabilFATCred, financialAccountResult.ContaContabilFATDeb, financialAccountResult.ContaContabilContestacaoCred, financialAccountResult.ContaContabilContestacaoDeb,
                        financialAccountResult.BoletoRetificadoDeb, financialAccountResult.BoletoRetificadoCred,
                        financialAccountResult.ContaContabilIMPDEB, financialAccountResult.ContaContabilIMPCRED, financialAccountResult.CompensacaoAJU, financialAccountResult.ContaFuturaAJUDeb, financialAccountResult.ContaFuturaAJUCred,
                        financialAccountResult.ContaContabilAjusteCompetenciaDeb, financialAccountResult.ContaContabilAjusteCompetenciaCred, financialAccountResult.ContaContabilEstimativaCicloDeb, financialAccountResult.ContaContabilEstimativaCicloCred,
                        financialAccountResult.MultaQuebraContFAT, financialAccountResult.ContaContabilMultaContDeb, financialAccountResult.ContaContabilMultaContCred, financialAccountResult.ContaContabilMultaContPagaDeb, financialAccountResult.ContaContabilMultaContPagaCred,
                        financialAccountResult.ContaContabilMultaContNpagaDeb, financialAccountResult.ContaContabilMultaContNpagaCred, financialAccountResult.ContaContabilMultaEstimativaCicloDeb, financialAccountResult.ContaContabilMultaEstimativaCicloCred,
                        financialAccountResult.ContaFaturaEstornoContestacao, financialAccountResult.ContaContabilESTCredFuturoValorNUTILDeb, financialAccountResult.ContaContabilESTCredFuturoValorNUTILCred, financialAccountResult.ContaContabilESTCredFuturoValorUTILDeb,
                        financialAccountResult.ContaContabilESTCredFuturoValorUTILCred, financialAccountResult.EstBoletoRetificadoDeb, financialAccountResult.EstBoletoRetificadoCred, financialAccountResult.ContaFaturaDebitoConcedido, financialAccountResult.ContaContabilDebitoConcedidoDeb,
                        financialAccountResult.ContaContabilDebitoConcedidoCred,
                        financialAccountResult.ContaContabilProdutoNaoEmitidoPagoDeb, financialAccountResult.ContaContabilProdutoNaoEmitidoPagoCred, financialAccountResult.ContaContabilProdutoNaoEmitidoNaoPagoDeb, financialAccountResult.ContaContabilProdutoNaoEmitidoNaoPagoCred,
                        financialAccountResult.ContaContabilRecReceitaDeb, financialAccountResult.ContaContabilRecReceitaCred,
                        DateTime.UtcNow, DateTime.UtcNow, false, financialAccountResult.StoreType)
                    {
                        IdFinancialAccount = financialAccount.Id
                    };

                    FinancialAccountRepository.Update(financialAccount);
                    FinancialAccountRepository.Add(financialAccountDate);
                }

                LogRepository.Add(new Log("FinancialAccountSave.Execute", "Financial Account saved", TypeLog.Processing, UserId));

                return 1;
            }
            catch (Exception ex)
            {
                LogRepository.Add(new Log("FinancialAccountSave.Execute", ex.Message, TypeLog.Error, ex.StackTrace, UserId));
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
