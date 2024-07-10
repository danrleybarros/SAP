using System;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute;
using Xunit;
using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.Config;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using Gcsb.Connect.SAP.Application.Repositories.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Tests.Builders.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.Repositories.Config.CreditGrantedFinancialAccount;
using Gcsb.Connect.SAP.Tests.Builders.Config.CreditGrantedFinancialAccount;
using System.Linq;
using Gcsb.Connect.SAP.Tests.Builders.FinancialAccountsClient;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.CounterchargeDispute
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class CounterchargeDisputeUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly ICounterchargeDisputeUseCase counterchargeDisputeUseCase;

        public CounterchargeDisputeUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            counterchargeDisputeUseCase = fixture.Container.Resolve<CounterchargeDisputeUseCase>();                        
        }

        [Fact]
        [Trait("Action", "Create")]        
        public void ShouldExecuteUseCase()
        {
            var dateNow = DateTime.UtcNow;
            var request = new CounterchargeDisputeRequest(dateNow.AddDays(-1), dateNow.AddDays(1));

            counterchargeDisputeUseCase.Execute(request);

            Assert.True(!request.Logs.Exists(f => f.TypeLog == Messaging.Messages.Log.Enum.TypeLog.Error));
        }
    }
}
