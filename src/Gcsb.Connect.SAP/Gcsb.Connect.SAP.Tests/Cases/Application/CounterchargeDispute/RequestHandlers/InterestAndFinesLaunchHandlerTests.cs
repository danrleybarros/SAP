using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Tests.Builders.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.CounterChargeDispute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.CounterchargeDispute.RequestHandlers
{
    public class InterestAndFinesLaunchHandlerTests
    {
        [Fact]
        public void ShouldAddInterestAndFineLaunches()
        {
            var request = new CounterchargeDisputeRequest(new DateTime(2021, 07, 01), new DateTime(2021, 07, 31));
            var counterChargeDisputes = new List<SAP.Domain.JSDN.CounterChargeDispute.CounterchargeDispute>()
            {
                 CounterchargeDisputeBuilder.New().WithActivityType("interest").WithValorContestado(25).Build(),
                 CounterchargeDisputeBuilder.New().WithActivityType("fines").WithValorContestado(50).Build(),
                 CounterchargeDisputeBuilder.New().WithStoreAcronym("cloudco").WithActivityType("interest").WithValorContestado(15).Build(),
                 CounterchargeDisputeBuilder.New().WithStoreAcronym("cloudco").WithActivityType("fines").WithValorContestado(30).Build(),
            };
            request.CounterchargeDisputesAdjustment.AddRange(counterChargeDisputes);

            var interestAccount = AccountBuilder.New().WithFinancialAccount("ACInterest").Build();
            var finesAccount = AccountBuilder.New().WithFinancialAccount("ACFines").Build();

            request.InterestAndFineFinancialAccounts = new List<SAP.Domain.Config.InterestAndFineFinancialAccount.InterestAndFineFinancialAccount>()
            {
                InterestAndFineFinancialAccountBuilder.New().Build(),
                InterestAndFineFinancialAccountBuilder.New().WithStore(StoreType.TLF2).WithInterest(interestAccount).WithFine(finesAccount).Build()
            };

            new InterestAndFineLaunchHandler().ProcessRequest(request);

            Assert.True(request.Lines.Count > 0);

            var lines = request.Lines[StoreType.TBRA];
            lines.Find(p => p.FinancialAccount.Equals("123456789") && p.TypeLaunchAccounting == "C").LaunchValue.Should().Be(25);
            lines.Find(p => p.FinancialAccount.Equals("123456789") && p.TypeLaunchAccounting == "D").LaunchValue.Should().Be(25);
            lines.Find(p => p.FinancialAccount.Equals("987654321") && p.TypeLaunchAccounting == "C").LaunchValue.Should().Be(50);
            lines.Find(p => p.FinancialAccount.Equals("987654321") && p.TypeLaunchAccounting == "D").LaunchValue.Should().Be(50);

            lines = request.Lines[StoreType.TLF2];
            lines.Find(p => p.FinancialAccount.Equals("ACInterest") && p.TypeLaunchAccounting == "C").LaunchValue.Should().Be(15);
            lines.Find(p => p.FinancialAccount.Equals("ACInterest") && p.TypeLaunchAccounting == "D").LaunchValue.Should().Be(15);
            lines.Find(p => p.FinancialAccount.Equals("ACFines") && p.TypeLaunchAccounting == "C").LaunchValue.Should().Be(30);
            lines.Find(p => p.FinancialAccount.Equals("ACFines") && p.TypeLaunchAccounting == "D").LaunchValue.Should().Be(30);
        }
    }
}
