using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.ApiClientsTests
{
    public class DneTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IDne dne;

        public DneTests(Fixture.ApplicationFixture fixture)
        {
            this.dne = fixture.Container.Resolve<IDne>();
        }

        [Theory]
        [Trait("Action", "Integrate")]
        [InlineData("09321040")]
        public async void ShouldGetIbgeCode(string cep)
        {
            var ibgeCode = await dne.GetIbge(cep);
            Assert.True(ibgeCode != 0);
        }

        [Theory]
        [Trait("Action", "Integrate")]
        [InlineData("09321040", "SP")]
        public async void ShouldGetLogradouro(string cep, string uf)
        {
            var cepOutputLogradouro = await dne.GetLogradouro(cep);

            Assert.NotNull(cepOutputLogradouro);
            Assert.Equal(uf, cepOutputLogradouro.Uf);
        }

        [Theory]
        [Trait("Action", "Integrate")]
        [InlineData("09321040", "SP")]
        public async void ShouldGetUf(string cep, string uf)
        {
            var ufRetorno = await dne.GetUf(cep);

            Assert.True(!string.IsNullOrEmpty(ufRetorno));
            Assert.Equal(uf, ufRetorno);
        }

        [Theory]
        [Trait("Action", "Integrate")]
        [InlineData("09321040")]
        public async void ShouldGetListUf(params string[] ceps)
        {
            var ret = await dne.GetListUf(ceps.ToList());

            Assert.NotNull(ret);
            Assert.Equal("SP", ret[0].Uf);
        }

        [Theory]
        [Trait("Action", "Integrate")]
        [InlineData("09321040", "69945000")]
        public async void ShouldGetListIbge(params string[] ceps)
        {
            var ret = await dne.GetListIbge(ceps.ToList());

            Assert.NotNull(ret);
            Assert.Equal(3529401, ret[0].CodIbge);
        }

        [Theory]
        [Trait("Action", "Integrate")]
        [InlineData("09321040", "69945000", "05797200", "06436180", "01330010")]
        public async void ShouldGetListLogradouro(params string[] ceps)
        {
            var ret = await dne.GetListLogradouro(ceps.ToList());

            Assert.NotNull(ret);

            var retCep = ret.Select(s => s.Cep).ToList();
            var exist1 = retCep.Contains("09321040");
            var exist2 = retCep.Contains("69945000");
            var exist3 = retCep.Contains("05797200");
            var exist4 = retCep.Contains("06436180");
            var exist5 = retCep.Contains("01330010");

            Assert.True(exist1);
            Assert.True(exist2);
            Assert.True(exist3);
            Assert.True(exist4);
            Assert.True(exist5);
        }
    }
}