
using Autofac;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories.Config;
using Gcsb.Connect.SAP.Application.UseCases.Config.FinancialAccount.GetById;
using Gcsb.Connect.SAP.Tests.Builders.Config;
using System;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.FinancialAccount.GetById
{
    public class FinancialAccountGetUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IFinancialAccountGetByIdUseCase financialAccountGetByIdUseCase;
        private readonly IFinancialAccountWriteOnlyRepository financialAccountWriteOnlyRepository;
        private readonly Guid Id = Guid.NewGuid();

        public FinancialAccountGetUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            this.financialAccountGetByIdUseCase = fixture.Container.Resolve<IFinancialAccountGetByIdUseCase>();
            this.financialAccountWriteOnlyRepository = fixture.Container.Resolve<IFinancialAccountWriteOnlyRepository>();
        }

        private void Mock()
        {
            var model = FinancialAccountBuilder.New().WithIdFinancialAccount(Id).Build();

            financialAccountWriteOnlyRepository.Add(model);
        }


        [Theory]
        [InlineData("123")]
        public void ShouldExecuteUseCase(string userId)
        {
            Mock();

            var request = new FinancialAccountRequest(userId, Id);

            financialAccountGetByIdUseCase.Execute(request);

            Assert.True(!request.Logs.Any(x => x.TypeLog.Equals(TypeLog.Error)));
            Assert.True(request.FinancialAccount != null);
        }


        [Theory]
        [InlineData("123", "No data found")]
        public void ShouldExecuteUseCaseReturnNotFound(string userId, string message)
        {
            var request = new FinancialAccountRequest(userId, Id);

            financialAccountGetByIdUseCase.Execute(request);

            Assert.False(!request.Logs.Any(x => x.TypeLog.Equals(TypeLog.Processing) && x.Message.Contains(message)));
        }
    }
}
