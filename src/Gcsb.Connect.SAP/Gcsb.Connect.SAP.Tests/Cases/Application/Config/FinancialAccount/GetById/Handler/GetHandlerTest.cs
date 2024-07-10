using Autofac;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories.Config;
using Gcsb.Connect.SAP.Application.UseCases.Config.FinancialAccount.GetById;
using Gcsb.Connect.SAP.Application.UseCases.Config.FinancialAccount.GetById.Handler;
using Gcsb.Connect.SAP.Tests.Builders.Config;
using System;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.FinancialAccount.GetById.Handler
{
    public class GetHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly GetHandler getHandler;
        private readonly IFinancialAccountWriteOnlyRepository financialAccountWriteOnlyRepository;
        private readonly Guid Id = Guid.NewGuid();

        public GetHandlerTest(Fixture.ApplicationFixture fixture)
        {
            getHandler = fixture.Container.Resolve<GetHandler>();
            this.financialAccountWriteOnlyRepository = fixture.Container.Resolve<IFinancialAccountWriteOnlyRepository>();
        }

        private void Mock()
        {
            var model = FinancialAccountBuilder.New().WithIdFinancialAccount(Id).Build();

            financialAccountWriteOnlyRepository.Add(model);
        }

        [Theory]
        [InlineData("123")]
        public void ShouldExecuteGetHandler(string userId)
        {
            Mock();

            var request = new FinancialAccountRequest(userId, Id);

            getHandler.ProcessRequest(request);

            Assert.True(request.FinancialAccount != null);
        }      

    }
}
