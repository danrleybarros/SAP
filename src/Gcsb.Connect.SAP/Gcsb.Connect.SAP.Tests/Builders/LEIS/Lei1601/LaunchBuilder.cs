using System;
using Gcsb.Connect.SAP.Domain.Lei1601;
using Gcsb.Connect.SAP.Domain.LEI1601;

namespace Gcsb.Connect.SAP.Tests.Builders.LEIS.Lei1601
{
    public class LaunchBuilder
    {
        public string EmpsCod;
        public string FiliCod;
        public DateTime OipeDataOper;
        public string CatgCode;
        public string CadgCod;
        public string CatgCodIt;
        public string CadgCodIt;
        public string OipeTotVs;
        public decimal OipeTotIss;
        public string OipeTotOutros;
        public string BancoOrigPgto;
        public string SistemaOrigem;
        public PaymentMethod PaymentMethod;
        public Guid FileId;
        public int BankCode;
        public string BankName;

        public static LaunchBuilder New()
        {
            return new LaunchBuilder
            {
                FileId = Guid.NewGuid(),
                EmpsCod = "TBRA",
                FiliCod = "9141",
                OipeDataOper = DateTime.Now,
                CatgCode = string.Empty,
                CadgCod = "3012393",
                CatgCodIt = string.Empty,
                OipeTotVs = string.Empty,
                OipeTotIss = 100,
                OipeTotOutros = string.Empty,
                BankCode = 1,
                BankName = "BANCO DO BRASIL",
                BancoOrigPgto = "013CORREIOS",
                SistemaOrigem = "PLATAFORMA DIGITAL",
                PaymentMethod = PaymentMethod.Boleto
            };
        }

        public LaunchBuilder WithEmpsCod(string empsCod)
        {
            EmpsCod = empsCod;
            return this;
        }

        public LaunchBuilder WithFiliCod(string filiCod)
        {
            FiliCod = filiCod;
            return this;
        }

        public LaunchBuilder WithOipeDataOper(DateTime oipeDataOper)
        {
            OipeDataOper = oipeDataOper;
            return this;
        }

        public LaunchBuilder WithCatgCode(string catgCode)
        {
            CatgCode = catgCode;
            return this;
        }

        public LaunchBuilder WithCadgCod(string cadgCod)
        {
            CadgCod = cadgCod;
            return this;
        }

        public LaunchBuilder WithCatgCodIt(string catgCodIt)
        {
            CatgCodIt = catgCodIt;
            return this;
        }

        public LaunchBuilder WithCadgCodIt(string cadgCodIt)
        {
            CadgCodIt = cadgCodIt;
            return this;
        }

        public LaunchBuilder WithOipeTotVs(string oipeTotVs)
        {
            OipeTotVs = oipeTotVs;
            return this;
        }

        public LaunchBuilder WithOipeTotIss(decimal oipeTotIss)
        {
            OipeTotIss = oipeTotIss;
            return this;
        }

        public LaunchBuilder WithOipeTotOutros(string oipeTotOutros)
        {
            OipeTotOutros = oipeTotOutros;
            return this;
        }

        public LaunchBuilder WithBancoOrigPgto(string bancoOrigPgto)
        {
            BancoOrigPgto = bancoOrigPgto;
            return this;
        }

        public LaunchBuilder WithSistemaOrigem(string sistemaOrigem)
        {
            SistemaOrigem = sistemaOrigem;
            return this;
        }

        public LaunchBuilder WithFileId(Guid fileId)
        {
            FileId = fileId;
            return this;
        }

        public Launch Build()
            => new Launch
            (
                FileId,
                EmpsCod,
                FiliCod,
                OipeDataOper,
                OipeTotIss,
                BancoOrigPgto,
                PaymentMethod,
                BankCode
            );
    }
}
