using Xunit;
using Gcsb.Connect.SAP.Tests.Builders.Config;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.Config
{
    public class FinancialAccountTests
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreate()
        {
            var model = FinancialAccountBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyServiceoNameNotCreate(string serviceName)
        {
            var model = FinancialAccountBuilder.New().WithServiceName(serviceName).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        public void MaxLength15ServiceCode()
        {
            string serviceCode = string.Empty;
            while (serviceCode.Length < 16) serviceCode += serviceCode + "A";
            var model = FinancialAccountBuilder.New().WithServiceCode(serviceCode).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        public void MaxLength50ServiceName()
        {
            string serviceName = string.Empty;
            while (serviceName.Length < 51) serviceName += serviceName + "A";
            var model = FinancialAccountBuilder.New().WithServiceName(serviceName).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        public void MaxLength15FaturamentoFAT()
        {
            string faturamentoFAT = string.Empty;
            while (faturamentoFAT.Length < 16) faturamentoFAT += faturamentoFAT + "A";
            var model = FinancialAccountBuilder.New().WithFaturamentoFAT(faturamentoFAT).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        public void MaxLength15FaturamentoAJU()
        {
            string faturamentoAJU = string.Empty;
            while (faturamentoAJU.Length < 16) faturamentoAJU += faturamentoAJU + "A";
            var model = FinancialAccountBuilder.New().WithFaturamentoAJU(faturamentoAJU).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        public void MaxLength15DescontoFAT()
        {
            string descontoFAT = string.Empty;
            while (descontoFAT.Length < 16) descontoFAT += descontoFAT + "A";
            var model = FinancialAccountBuilder.New().WithDescontoFAT(descontoFAT).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyContaContabilAjusteCompetenciaDeb(string ajusteCompetenciaDeb)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilAjusteCompetenciaDeb(ajusteCompetenciaDeb).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyContaContabilAjusteCompetenciaCred(string ajusteCompetenciaCred)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilAjusteCompetenciaCred(ajusteCompetenciaCred).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyContaContabilEstimativaCicloDeb(string estimativaCicloDeb)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilAjusteCompetenciaDeb(estimativaCicloDeb).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyContaContabilEstimativaCicloCred(string estimativaCicloCred)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilAjusteCompetenciaCred(estimativaCicloCred).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("ajusteCompetenciaDeb")]
        public void MaxLength8AjusteCompetenciaDeb(string ajusteCompetenciaDeb)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilAjusteCompetenciaDeb(ajusteCompetenciaDeb).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("ajusteCompetenciaCred")]
        public void MaxLength8AjusteCompetenciaCred(string ajusteCompetenciaCred)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilAjusteCompetenciaCred(ajusteCompetenciaCred).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("estimativaCicloDeb")]
        public void MaxLength8EstimativaCicloDeb(string estimativaCicloDeb)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilEstimativaCicloDeb(estimativaCicloDeb).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("estimativaCicloCred")]
        public void MaxLength8EstimativaCicloCred(string estimativaCicloCred)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilEstimativaCicloCred(estimativaCicloCred).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        public void MaxLength15MultaQuebraContFAT()
        {
            string multaQuebraContFAT = string.Empty;
            while (multaQuebraContFAT.Length < 16) multaQuebraContFAT += multaQuebraContFAT + "A";
            var model = FinancialAccountBuilder.New().WithMultaQuebraContFAT(multaQuebraContFAT).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("contaContabilMultaContDeb")]
        public void MaxLength8ContaContabilMultaContDeb(string contaContabilMultaContDeb)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilMultaContDeb(contaContabilMultaContDeb).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("contaContabilMultaContCred")]
        public void MaxLength8ContaContabilMultaContCred(string contaContabilMultaContCred)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilMultaContCred(contaContabilMultaContCred).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("contaContabilMultaContPagaDeb")]
        public void MaxLength8ContaContabilMultaContPagaDeb(string contaContabilMultaContPagaDeb)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilMultaContPagaDeb(contaContabilMultaContPagaDeb).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("contaContabilMultaContPagaCred")]
        public void MaxLength8ContaContabilMultaContPagaCred(string contaContabilMultaContPagaCred)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilMultaContPagaCred(contaContabilMultaContPagaCred).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("contaContabilMultaContNpagaDeb")]
        public void MaxLength8ContaContabilMultaContNpagaDeb(string contaContabilMultaContNpagaDeb)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilMultaContNpagaDeb(contaContabilMultaContNpagaDeb).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("contaContabilMultaContNpagaCred")]
        public void MaxLength8ContaContabilMultaContNpagaCred(string contaContabilMultaContNpagaCred)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilMultaContNpagaCred(contaContabilMultaContNpagaCred).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("contaContabilMultaEstimativaCicloDeb")]
        public void MaxLength8ContaContabilMultaEstimativaCicloDeb(string contaContabilMultaEstimativaCicloDeb)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilMultaEstimativaCicloDeb(contaContabilMultaEstimativaCicloDeb).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("contaContabilMultaEstimativaCicloCred")]
        public void MaxLength8ContaContabilMultaEstimativaCicloCred(string contaContabilMultaEstimativaCicloCred)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilMultaEstimativaCicloCred(contaContabilMultaEstimativaCicloCred).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Fact]
        [Trait("Action", "None")]
        public void MaxLength15ContaFaturaEstornoContestacao()
        {
            string contaFaturaEstornoContestacao = string.Empty;
            while (contaFaturaEstornoContestacao.Length < 16) contaFaturaEstornoContestacao += contaFaturaEstornoContestacao + "A";
            var model = FinancialAccountBuilder.New().WithContaFaturaEstornoContestacao(contaFaturaEstornoContestacao).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("contaContabilESTCredFuturoValorNUTILDeb")]
        public void MaxLength8ContaContabilESTCredFuturoValorNUTILDeb(string contaContabilESTCredFuturoValorNUTILDeb)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilESTCredFuturoValorNUTILDeb(contaContabilESTCredFuturoValorNUTILDeb).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("contaContabilESTCredFuturoValorNUTILCred")]
        public void MaxLength8ContaContabilESTCredFuturoValorNUTILCred(string contaContabilESTCredFuturoValorNUTILCred)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilESTCredFuturoValorNUTILCred(contaContabilESTCredFuturoValorNUTILCred).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("contaContabilESTCredFuturoValorUTILDeb")]
        public void MaxLength8ContaContabilESTCredFuturoValorUTILDeb(string contaContabilESTCredFuturoValorUTILDeb)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilESTCredFuturoValorUTILDeb(contaContabilESTCredFuturoValorUTILDeb).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("contaContabilESTCredFuturoValorUTILCred")]
        public void MaxLength8ContaContabilESTCredFuturoValorUTILCred(string contaContabilESTCredFuturoValorUTILCred)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilESTCredFuturoValorUTILCred(contaContabilESTCredFuturoValorUTILCred).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("estBoletoRetificadoDeb")]
        public void MaxLength8EstBoletoRetificadoDeb(string estBoletoRetificadoDeb)
        {
            var model = FinancialAccountBuilder.New().WithEstBoletoRetificadoDeb(estBoletoRetificadoDeb).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("estBoletoRetificadoCred")]
        public void MaxLength8EstBoletoRetificadoCred(string estBoletoRetificadoCred)
        {
            var model = FinancialAccountBuilder.New().WithEstBoletoRetificadoCred(estBoletoRetificadoCred).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Fact]
        [Trait("Action", "None")]
        public void MaxLength15ContaContabilDebitoConcedidoDeb()
        {
            string contaContabilDebitoConcedidoDeb = string.Empty;
            while (contaContabilDebitoConcedidoDeb.Length < 16) contaContabilDebitoConcedidoDeb += contaContabilDebitoConcedidoDeb + "A";
            var model = FinancialAccountBuilder.New().WithContaContabilDebitoConcedidoDeb(contaContabilDebitoConcedidoDeb).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }


        [Theory]
        [Trait("Action", "None")]
        [InlineData("contaContabilDebitoConcedidoDeb")]
        public void MaxLength8ContaContabilDebitoConcedidoDeb(string contaContabilDebitoConcedidoDeb)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilDebitoConcedidoDeb(contaContabilDebitoConcedidoDeb).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);

        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("contaContabilDebitoConcedidoCred")]
        public void MaxLength8ContaContabilDebitoConcedidoCred(string contaContabilDebitoConcedidoCred)
        {
            var model = FinancialAccountBuilder.New().WithContaContabilDebitoConcedidoCred(contaContabilDebitoConcedidoCred).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);

        }
    }
}
