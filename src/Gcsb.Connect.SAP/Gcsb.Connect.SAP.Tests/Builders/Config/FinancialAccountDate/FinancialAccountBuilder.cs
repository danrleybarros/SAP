using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Tests.Builders.Config.FinancialAccountDate
{
    public class FinancialAccountBuilder
    {
        public Guid Id;
        public string ServiceCode;
        public string ServiceName;
        public string FaturamentoFAT;
        public string FaturamentoAJU;
        public string DescontoFAT;
        public DateTime? DateIncluded;
        public DateTime LastUpdateDate;
        public bool IsDeleted;
        public string ContaContabilFATCred;
        public string ContaContabilFATDeb;
        public string ContaContabilContestacaoCred;
        public string ContaContabilContestacaoDeb;
        public string BoletoRetificadoDeb;
        public string BoletoRetificadoCred;
        public string ContaContabilIMPDEB;
        public string ContaContabilIMPCRED;
        public string CompensacaoAJU;
        public string ContaFuturaAJUDeb;
        public string ContaFuturaAJUCred;
        public string ContaContabilAjusteCompetenciaDeb;
        public string ContaContabilAjusteCompetenciaCred;
        public string ContaContabilEstimativaCicloDeb;
        public string ContaContabilEstimativaCicloCred;
        public StoreType StoreType;
        public string MultaQuebraContFAT;
        public string ContaContabilMultaContDeb;
        public string ContaContabilMultaContCred;
        public string ContaContabilMultaContPagaDeb;
        public string ContaContabilMultaContPagaCred;
        public string ContaContabilMultaContNpagaDeb;
        public string ContaContabilMultaContNpagaCred;
        public string ContaContabilMultaEstimativaCicloDeb;
        public string ContaContabilMultaEstimativaCicloCred;
        public string ContaFaturaEstornoContestacao;
        public string ContaContabilESTCredFuturoValorNUTILDeb;
        public string ContaContabilESTCredFuturoValorNUTILCred;
        public string ContaContabilESTCredFuturoValorUTILDeb;
        public string ContaContabilESTCredFuturoValorUTILCred;
        public string EstBoletoRetificadoDeb;
        public string EstBoletoRetificadoCred;
        public string ContaFaturaDebitoConcedido;
        public string ContaContabilDebitoConcedidoDeb;
        public string ContaContabilDebitoConcedidoCred;
        public string ContaContabilProdutoNaoEmitidoPagoDeb;
        public string ContaContabilProdutoNaoEmitidoPagoCred;
        public string ContaContabilProdutoNaoEmitidoNaoPagoDeb;
        public string ContaContabilProdutoNaoEmitidoNaoPagoCred;
        public string ContaContabilRecReceitaDeb;
        public string ContaContabilRecReceitaCred;

        public FinancialAccountBuilder()
        {
            Id = Guid.NewGuid();
            ServiceCode = "office365";
            ServiceName = "Office 365";
            FaturamentoFAT = "FATGW";
            FaturamentoAJU = "FATGWAJU";
            DescontoFAT = "FATGWDESC";
            DateIncluded = DateTime.UtcNow;
            LastUpdateDate = DateTime.UtcNow;
            IsDeleted = false;
            ContaContabilAjusteCompetenciaDeb = "88888888";
            ContaContabilAjusteCompetenciaCred = "99999999";
            ContaContabilEstimativaCicloDeb = "77777777";
            ContaContabilEstimativaCicloCred = "55555555";
            StoreType = StoreType.TBRA;
            MultaQuebraContFAT = "000000000000004";
            ContaContabilMultaContDeb = "66666666";
            ContaContabilMultaContCred = "55555555";
            ContaContabilMultaContPagaDeb = "44444444";
            ContaContabilMultaContPagaCred = "33333333";
            ContaContabilMultaContNpagaDeb = "22222222";
            ContaContabilMultaContNpagaCred = "11111111";
            ContaContabilMultaEstimativaCicloDeb = "10000000";
            ContaContabilMultaEstimativaCicloCred = "01000000";
            ContaFaturaEstornoContestacao = "CONTAESTC";
            ContaContabilESTCredFuturoValorNUTILDeb = "00000010";
            ContaContabilESTCredFuturoValorNUTILCred = "00000011";
            ContaContabilESTCredFuturoValorUTILDeb = "00000012";
            ContaContabilESTCredFuturoValorUTILCred = "00000013";
            EstBoletoRetificadoDeb = "00000014";
            EstBoletoRetificadoCred = "00000015";
            ContaFaturaDebitoConcedido = "DEBRESTGW";
            ContaContabilDebitoConcedidoDeb = "00000016";
            ContaContabilDebitoConcedidoCred = "00000017";
            ContaContabilProdutoNaoEmitidoPagoDeb = "00000018";
            ContaContabilProdutoNaoEmitidoPagoCred = "00000019";
            ContaContabilProdutoNaoEmitidoNaoPagoDeb = "00000020";
            ContaContabilProdutoNaoEmitidoNaoPagoCred = "00000021";
            ContaContabilRecReceitaDeb = "00000022";
            ContaContabilRecReceitaCred = "00000023";
        }

        public FinancialAccountBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public FinancialAccountBuilder WithServiceCode(string servicecode)
        {
            ServiceCode = servicecode;
            return this;
        }

        public FinancialAccountBuilder WithServiceName(string serviceName)
        {
            ServiceName = serviceName;
            return this;
        }

        public FinancialAccountBuilder WithFaturamentoFAT(string faturamentofat)
        {
            FaturamentoFAT = faturamentofat;
            return this;
        }

        public FinancialAccountBuilder WithFaturamentoAJU(string faturamentoaju)
        {
            FaturamentoAJU = faturamentoaju;
            return this;
        }

        public FinancialAccountBuilder WithDescontoFAT(string descontofat)
        {
            DescontoFAT = descontofat;
            return this;
        }

        public FinancialAccountBuilder WithDateIncluded(DateTime? dateincluded)
        {
            DateIncluded = dateincluded;
            return this;
        }

        public FinancialAccountBuilder WithLastUpdateDate(DateTime lastUpdateDate)
        {
            LastUpdateDate = lastUpdateDate;
            return this;
        }

        public FinancialAccountBuilder WithIsDeleted(bool isdeleted)
        {
            IsDeleted = isdeleted;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilFATCred(string contaContabilFATCred)
        {
            ContaContabilFATCred = contaContabilFATCred;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilFATDeb(string contaContabilFATDeb)
        {
            ContaContabilFATDeb = contaContabilFATDeb;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilContestacaoCred(string contaContabilContestacaoCred)
        {
            ContaContabilContestacaoCred = contaContabilContestacaoCred;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilContestacaoDeb(string contaContabilContestacaoDeb)
        {
            ContaContabilContestacaoDeb = contaContabilContestacaoDeb;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilIMPDEB(string contaContabilIMPDEB)
        {
            ContaContabilIMPDEB = contaContabilIMPDEB;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilIMPCRED(string contaContabilIMPCRED)
        {
            ContaContabilIMPCRED = contaContabilIMPCRED;
            return this;
        }

        public FinancialAccountBuilder WithCompensacaoAJU(string compensacaoAJU)
        {
            CompensacaoAJU = compensacaoAJU;
            return this;
        }

        public FinancialAccountBuilder WithContaFuturaAJUDeb(string contaFuturaAJUDeb)
        {
            ContaFuturaAJUDeb = contaFuturaAJUDeb;
            return this;
        }

        public FinancialAccountBuilder WithContaFuturaAJUCred(string contaFuturaAJUCred)
        {
            ContaFuturaAJUCred = contaFuturaAJUCred;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilAjusteCompetenciaDeb(string contaContabilAjusteCompetenciaDeb)
        {
            ContaContabilAjusteCompetenciaDeb = contaContabilAjusteCompetenciaDeb;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilAjusteCompetenciaCred(string contaContabilAjusteCompetenciaCred)
        {
            ContaContabilAjusteCompetenciaCred = contaContabilAjusteCompetenciaCred;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilEstimativaCicloDeb(string contaContabilEstimativaCicloDeb)
        {
            ContaContabilEstimativaCicloDeb = contaContabilEstimativaCicloDeb;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilEstimativaCicloCred(string contaContabilEstimativaCicloCred)
        {
            ContaContabilEstimativaCicloCred = contaContabilEstimativaCicloCred;
            return this;
        }

        public FinancialAccountBuilder WithMultaQuebraContFAT(string multaQuebraContFAT)
        {
            MultaQuebraContFAT = multaQuebraContFAT;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilMultaContDeb(string contaContabilMultaContDeb)
        {
            ContaContabilMultaContDeb = contaContabilMultaContDeb;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilMultaContCred(string contaContabilMultaContCred)
        {
            ContaContabilMultaContCred = contaContabilMultaContCred;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilMultaContPagaDeb(string contaContabilMultaContPagaDeb)
        {
            ContaContabilMultaContPagaDeb = contaContabilMultaContPagaDeb;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilMultaContPagaCred(string contaContabilMultaContPagaCred)
        {
            ContaContabilMultaContPagaCred = contaContabilMultaContPagaCred;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilMultaContNpagaDeb(string contaContabilMultaContNpagaDeb)
        {
            ContaContabilMultaContNpagaDeb = contaContabilMultaContNpagaDeb;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilMultaContNpagaCred(string contaContabilMultaContNpagaCred)
        {
            ContaContabilMultaContNpagaCred = contaContabilMultaContNpagaCred;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilMultaEstimativaCicloDeb(string contaContabilMultaEstimativaCicloDeb)
        {
            ContaContabilMultaEstimativaCicloDeb = contaContabilMultaEstimativaCicloDeb;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilMultaEstimativaCicloCred(string contaContabilMultaEstimativaCicloCred)
        {
            ContaContabilMultaEstimativaCicloCred = contaContabilMultaEstimativaCicloCred;
            return this;
        }

        public FinancialAccountBuilder WithContaFaturaEstornoContestacao(string contaFaturaEstornoContestacao)
        {
            ContaFaturaEstornoContestacao = contaFaturaEstornoContestacao;
            return this;
        }
        public FinancialAccountBuilder WithContaContabilESTCredFuturoValorNUTILDeb(string contaContabilESTCredFuturoValorNUTILDeb)
        {
            ContaContabilESTCredFuturoValorNUTILDeb = contaContabilESTCredFuturoValorNUTILDeb;
            return this;
        }
        public FinancialAccountBuilder WithContaContabilESTCredFuturoValorNUTILCred(string contaContaContabilESTCredFuturoValorNUTILCred)
        {
            ContaContabilESTCredFuturoValorNUTILCred = contaContaContabilESTCredFuturoValorNUTILCred;
            return this;
        }
        public FinancialAccountBuilder WithContaContabilESTCredFuturoValorUTILDeb(string contaContabilESTCredFuturoValorUTILDeb)
        {
            ContaContabilESTCredFuturoValorUTILDeb = contaContabilESTCredFuturoValorUTILDeb;
            return this;
        }
        public FinancialAccountBuilder WithContaContabilESTCredFuturoValorUTILCred(string contaContabilESTCredFuturoValorUTILCred)
        {
            ContaContabilESTCredFuturoValorUTILCred = contaContabilESTCredFuturoValorUTILCred;
            return this;
        }
        public FinancialAccountBuilder WithEstBoletoRetificadoDeb(string estBoletoRetificadoDeb)
        {
            EstBoletoRetificadoDeb = estBoletoRetificadoDeb;
            return this;
        }
        public FinancialAccountBuilder WithEstBoletoRetificadoCred(string estBoletoRetificadoCred)
        {
            EstBoletoRetificadoCred = estBoletoRetificadoCred;
            return this;
        }
        public FinancialAccountBuilder WithContaFaturaDebitoConcedido(string contaFaturaDebitoConcedido)
        {
            ContaFaturaDebitoConcedido = contaFaturaDebitoConcedido;
            return this;
        }
        public FinancialAccountBuilder WithContaContabilDebitoConcedidoDeb(string contaContabilDebitoConcedidoDeb)
        {
            ContaContabilDebitoConcedidoDeb = contaContabilDebitoConcedidoDeb;
            return this;
        }
        public FinancialAccountBuilder WithContaContabilDebitoConcedidoCred(string contaContabilDebitoConcedidoCred)
        {
            ContaContabilDebitoConcedidoCred = contaContabilDebitoConcedidoCred;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilProdutoNaoEmitidoPagoDeb(string value)
        {
            ContaContabilProdutoNaoEmitidoPagoDeb = value;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilProdutoNaoEmitidoPagoCred(string value)
        {
            ContaContabilProdutoNaoEmitidoPagoCred = value;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilProdutoNaoEmitidoNaoPagoDeb(string value)
        {
            ContaContabilProdutoNaoEmitidoNaoPagoDeb = value;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilProdutoNaoEmitidoNaoPagoCred(string value)
        {
            ContaContabilProdutoNaoEmitidoNaoPagoCred = value;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilRecReceitaDeb(string value)
        {
            ContaContabilRecReceitaDeb = value;
            return this;
        }

        public FinancialAccountBuilder WithContaContabilRecReceitaCred(string value)
        {
            ContaContabilRecReceitaCred = value;
            return this;
        }

        public Domain.Config.FinancialAccountDate.FinancialAccount Build()
            => new Domain.Config.FinancialAccountDate.FinancialAccount(Id, ServiceCode, ServiceName, FaturamentoFAT, FaturamentoAJU, DescontoFAT,
                ContaContabilFATCred, ContaContabilFATDeb, ContaContabilContestacaoCred, ContaContabilContestacaoDeb,
                BoletoRetificadoDeb, BoletoRetificadoCred, ContaContabilIMPDEB, ContaContabilIMPCRED, CompensacaoAJU, ContaFuturaAJUDeb,
                ContaFuturaAJUCred, ContaContabilAjusteCompetenciaDeb, ContaContabilAjusteCompetenciaCred, ContaContabilEstimativaCicloDeb,
                ContaContabilEstimativaCicloCred, MultaQuebraContFAT, ContaContabilMultaContDeb, ContaContabilMultaContCred, ContaContabilMultaContPagaDeb,
                ContaContabilMultaContPagaCred, ContaContabilMultaContNpagaDeb, ContaContabilMultaContNpagaCred, ContaContabilMultaEstimativaCicloDeb,
                ContaContabilMultaEstimativaCicloCred,
                ContaFaturaEstornoContestacao, ContaContabilESTCredFuturoValorNUTILDeb, ContaContabilESTCredFuturoValorNUTILCred,
                ContaContabilESTCredFuturoValorUTILDeb, ContaContabilESTCredFuturoValorUTILCred, EstBoletoRetificadoDeb,
                EstBoletoRetificadoCred, ContaFaturaDebitoConcedido, ContaContabilDebitoConcedidoDeb,
                ContaContabilDebitoConcedidoCred, ContaContabilProdutoNaoEmitidoPagoDeb, ContaContabilProdutoNaoEmitidoPagoCred,
                ContaContabilProdutoNaoEmitidoNaoPagoDeb, ContaContabilProdutoNaoEmitidoNaoPagoCred,
                ContaContabilRecReceitaDeb, ContaContabilRecReceitaCred, DateIncluded, LastUpdateDate, IsDeleted, StoreType);
    }
}