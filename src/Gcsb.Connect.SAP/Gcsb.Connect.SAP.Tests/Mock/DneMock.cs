using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Domain.GF;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Tests.Mock
{
    public class DneMock
    {
        public Mock<IDne> GetLocalizationMock()
        {
            var mock = new Mock<IDne>();

            mock.Setup(s => s.GetLogradouro(It.IsAny<string>())).Returns((string cep) => Task.FromResult(new CepOutputBuilder().WithCep(cep).Build()));
            mock.Setup(s => s.GetIbge(It.IsAny<string>())).Returns(Task.FromResult(40259));
            mock.Setup(s => s.GetUf(It.IsAny<string>())).Returns(Task.FromResult("SP"));

            mock.Setup(s => s.GetListUf(It.IsAny<List<string>>()))
                .Returns((List<string> ceps) => {
                    var ufs = new List<UfOutput>();
                    ceps.ForEach(f => ufs.Add(new UfOutputBuilder().WithCep(f).Build()));

                    return Task.FromResult(ufs);
                });

            mock.Setup(s => s.GetListIbge(It.IsAny<List<string>>()))
                .Returns((List<string> ceps) => {
                    var ufs = new List<CodIbgeOutput>();
                    ceps.ForEach(f => ufs.Add(new CodIbgeOutputBuilder().WithCep(f).Build()));

                    return Task.FromResult(ufs);
                });

            mock.Setup(s => s.GetListLogradouro(It.IsAny<List<string>>()))
                .Returns((List<string> ceps) => {
                    var ufs = new List<CepOutput>();
                    ceps.ForEach(f => ufs.Add(new CepOutputBuilder().WithCep(f).Build()));

                    return Task.FromResult(ufs);
                });

            return mock;
        }
    }
}
