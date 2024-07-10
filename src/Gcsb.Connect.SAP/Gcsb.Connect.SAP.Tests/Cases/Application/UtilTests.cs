using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application
{
    public class UtilTests
    {
        [Theory]
        [InlineData("Acre")]
        [InlineData("Alagoas")]
        [InlineData("Amapá")]
        [InlineData("Amazonas")]
        [InlineData("Bahia")]
        [InlineData("Ceará")]
        [InlineData("Distrito Federal")]
        [InlineData("Espírito Santo")]
        [InlineData("Goiás")]
        [InlineData("Maranhão")]
        [InlineData("Mato Grosso")]
        [InlineData("Mato Grosso do Sul")]
        [InlineData("Minas Gerais")]
        [InlineData("Pará")]
        [InlineData("Paraíba")]
        [InlineData("Paraná")]
        [InlineData("Pernambuco")]
        [InlineData("Piauí")]
        [InlineData("Rio de Janeiro")]
        [InlineData("Rio Grande do Norte")]
        [InlineData("Rio Grande do Sul")]
        [InlineData("Rondônia")]
        [InlineData("Roraima")]
        [InlineData("Santa Catarina")]
        [InlineData("São Paulo")]
        [InlineData("Sergipe")]
        [InlineData("Tocantins")]
        public void UpdateUFTests(string state)
        {
            var uf = SAP.Application.Util.GetUFByState(state, StoreType.TBRA);
            Assert.True(uf.Length == 2);
        }

        [Theory]
        [InlineData("á")]
        [InlineData("ã")]
        [InlineData("à")]
        [InlineData("â")]
        public void RemoveAccentsTests(string word)
        {
            var wordWithoutAccent = SAP.Application.Util.RemoveAccents(word);
            Assert.True(wordWithoutAccent == "a");
        }

    }
}
