using Gcsb.Connect.SAP.Tests.Builders.PAS;
using System.Diagnostics;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.PAS
{
    public class BodyTests
    {
        #region Create Tests
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateBody()
        {
            var model = Builders.Build.PasBody.Build();  //Builders.Build.PasBody.Build();            
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        #endregion

        #region Tests With Null And Empty 

        [Theory]
        [Trait("Action", "None")]
        [InlineData(int.MinValue)]
        public void NullOrEmptyShouldNotCreateWithNumeroRegistro(int valor)
        {
            var model = Builders.Build.PasBody.WithLineNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(null)]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithNomeCliente(string valor)
        {
            var model = Builders.Build.PasBody.WithCustomerName(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(null)]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithEndereco(string valor)
        {
            var model = Builders.Build.PasBody.WithAddress(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(null)]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithCidade(string valor)
        {
            var model = Builders.Build.PasBody.WithCity(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(null)]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithEstado(string valor)
        {
            var model = Builders.Build.PasBody.WithState(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithDadosFiscais(string valor)
        {
            var model = Builders.Build.PasBody.WithDoc(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(long.MinValue)]
        public void NullOrEmptyShouldNotCreateWithValor(decimal valor)
        {
            var model = Builders.Build.PasBody.WithValue(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(null)]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithCartaoCredito(string valor)
        {
            var model = Builders.Build.PasBody.WithCreditCard(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(long.MinValue)]
        public void NullOrEmptyShouldNotCreateWithNSU(long valor)
        {
            var model = Builders.Build.PasBody.WithNSU(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(null)]
        [InlineData("")]
        public void NullOrEmptyShouldNotCreateWithCodAutorizacao(string valor)
        {            
            var model = Builders.Build.PasBody.WithAutorizationCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion

        #region Tests With MaxLenght

        [Theory]
        [Trait("Action", "None")]
        [InlineData(9999999)]
        public void MaxLenght6NumeroRegistro(int valor)
        {
            var model = Builders.Build.PasBody.WithLineNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem Ipsum is simply dummy text of something")]
        public void MaxLenght35NomeCliente(string valor)
        {
            var model = Builders.Build.PasBody.WithCustomerName(valor).Build();
            Assert.True(model.CustomerName.Length.Equals(35));
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem Ipsum is simply dummy text of something or another")]
        public void MaxLenght50Endereco(string valor)
        {
            var model = Builders.Build.PasBody.WithAddress(valor).Build();
            Assert.True(model.Address.Length.Equals(50));
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem Ipsum is simply dummy text")]
        public void MaxLenght30Cidade(string valor)
        {
            var model = Builders.Build.PasBody.WithCity(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("SSP")]
        public void MaxLenght2Estado(string valor)
        {
            var model = Builders.Build.PasBody.WithState(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(1234567894564)]
        public void MaxLenght10CEP(long valor)
        {
            var model = Builders.Build.PasBody.WithCEP(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("123456789456123")]
        public void MaxLenght14DadosFiscais(string valor)
        {
            var model = Builders.Build.PasBody.WithDoc(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
 
        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem Ipsum is simply")]
        public void MaxLenght20CartaoCredito(string valor)
        {
            var model = Builders.Build.PasBody.WithCreditCard(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(long.MaxValue)]
        public void MaxLenght30NSU(long valor)
        {
            var model = Builders.Build.PasBody.WithNSU(valor + 1).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem Ipsum is")]
        public void MaxLenght12CodAutorizacao(string valor)
        {
            var model = Builders.Build.PasBody.WithAutorizationCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion

        #region Tests With Invalid Formats

        [Theory]
        [Trait("Action", "None")]
        [InlineData("77870851050110")]
        [InlineData("87567405267")]        
        public void InvalidArgumentDadosFiscais(string cpfOrCnpj)
        {
            var model = Builders.Build.PasBody.WithDoc(cpfOrCnpj).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        #endregion

        #region Tests With Constants

        [Theory]
        [Trait("Action", "None")]
        [InlineData("29TR018233", null, "11211411")]
        public void ShouldMatchConstantsBody(string centroCusto, string ordemInterna,string accountingAccount)
        {
            var model = Builders.Build.PasBody;            
            Assert.True(model.CostCenter == centroCusto);
            Assert.True(model.InternalOrder == ordemInterna);
            Assert.True(model.AccountingAccount == accountingAccount);
        }
        #endregion   
    }
}
