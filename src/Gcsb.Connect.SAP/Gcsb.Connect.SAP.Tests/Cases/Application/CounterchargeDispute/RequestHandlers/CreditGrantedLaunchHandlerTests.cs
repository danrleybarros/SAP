using FluentAssertions;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers;
using Gcsb.Connect.SAP.Domain.Config.CreditGrantedFinancialAccount;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Tests.Builders.AJU;
using Gcsb.Connect.SAP.Tests.Builders.Config.CreditGrantedFinancialAccount;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.CounterChargeDispute;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.CounterchargeDispute.RequestHandlers
{
    public class CreditGrantedLaunchHandlerTests
    {
        [Fact]
        public void ShouldReturnCreditGrantedLaunches()
        {
            var request = new CounterchargeDisputeRequest(new DateTime(2021, 07, 01), new DateTime(2021, 07, 31));
            var counterChargeDisputes = new List<SAP.Domain.JSDN.CounterChargeDispute.CounterchargeDispute>()
            {
                 CounterchargeDisputeBuilder.New().WithActivityType("Credits").WithTipoDisputa("Future Account").WithValorContestado(100).Build(),
                 CounterchargeDisputeBuilder.New().WithActivityType("Interest").WithTipoDisputa("Future Account").WithValorContestado(25).Build(),
                 CounterchargeDisputeBuilder.New().WithActivityType("Fines").WithTipoDisputa("Future Account").WithValorContestado(50).Build(),
            };
            
            var creditGrantedFinancialAccounts = new List<CreditGrantedFinancialAccount>()
            {
                CreditGrantedFinancialAccountBuilder.New().Build(),
                CreditGrantedFinancialAccountBuilder.New().WithStoreAcronym(StoreType.TLF2).Build()
            };

            request.CounterchargeDisputesBilling.AddRange(counterChargeDisputes);
            request.CreditGrantedFinancialAccounts.AddRange(creditGrantedFinancialAccounts);
            request.Lines.Add(StoreType.TBRA, new List<SAP.Domain.AJU.Launch>() { new LaunchBuilder().WithFinancialAccount("").WithAccountingAccount("00000").Build() });

            new CreditGrantedLaunchHandler().ProcessRequest(request);
            var lines = request.Lines[StoreType.TBRA];
            lines.Count.Should().Be(3);
            lines.Find(p => p.FinancialAccount.Equals("AJU") && p.TypeLaunchAccounting == "C").LaunchValue.Should().Be(175);
            lines.Find(p => p.FinancialAccount.Equals("AJU") && p.TypeLaunchAccounting == "D").LaunchValue.Should().Be(175);
        }
    }
}
