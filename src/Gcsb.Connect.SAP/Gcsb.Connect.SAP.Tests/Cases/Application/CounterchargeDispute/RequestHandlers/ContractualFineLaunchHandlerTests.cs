using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Tests.Builders.FinancialAccountsClient;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.CounterChargeDispute;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.CounterchargeDispute.RequestHandlers
{
    [UseAutofacTestFramework]
    public class ContractualFineLaunchHandlerTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IUniqueStoreFinancialAccount uniqueStoreFinancialAccount;

        public ContractualFineLaunchHandlerTests(Fixture.ApplicationFixture fixture)
        {
            this.uniqueStoreFinancialAccount = fixture.Container.Resolve<IUniqueStoreFinancialAccount>();
        }

        [Fact]
        public void ShouldReturnContractualFineLaunches()
        {
            var request = new CounterchargeDisputeRequest(new DateTime(2021, 07, 01), new DateTime(2021, 07, 31));

            var counterChargeDisputesAdjustment = new List<SAP.Domain.JSDN.CounterChargeDispute.CounterchargeDispute>()
            {
                CounterchargeDisputeBuilder.New()
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .WithCodigoServico("TESTESERVICE")
                    .WithTipoTransacao("Adjustment")
                    .WithActivityType("Contractual Fine")
                    .WithTipoDisputa("Future Account")
                    .WithValorContestado(30)
                    .Build(),
                CounterchargeDisputeBuilder.New()
                    .WithStoreAcronym("cloudCo")
                    .WithProviderCompanyAcronym("cloudCo")
                    .WithCodigoServico("TESTESERVICE")
                    .WithTipoTransacao("Adjustment")
                    .WithActivityType("Contractual Fine")
                    .WithTipoDisputa("Future Account")
                    .WithValorContestado(30)
                    .Build(),
                CounterchargeDisputeBuilder.New()
                    .WithStoreAcronym("IOTCo")
                    .WithProviderCompanyAcronym("IOTCo")
                    .WithCodigoServico("TESTESERVICE")
                    .WithTipoTransacao("Adjustment")
                    .WithActivityType("Contractual Fine")
                    .WithTipoDisputa("Future Account")
                    .WithValorContestado(30)
                    .Build(),
            };

            var counterChargeDisputesBilling = new List<SAP.Domain.JSDN.CounterChargeDispute.CounterchargeDispute>()
            {
                CounterchargeDisputeBuilder.New()
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .WithCodigoServico("TESTESERVICE")
                    .WithTipoTransacao("Billing")
                    .WithActivityType("Contractual Fine")
                    .WithTipoDisputa("Future Account")
                    .WithValorContestado(100)
                    .Build(),
                CounterchargeDisputeBuilder.New()
                    .WithStoreAcronym("cloudCo")
                    .WithProviderCompanyAcronym("cloudCo")
                    .WithCodigoServico("TESTESERVICE")
                    .WithTipoTransacao("Billing")
                    .WithActivityType("Contractual Fine")
                    .WithTipoDisputa("Future Account")
                    .WithValorContestado(100)
                    .Build(),
                CounterchargeDisputeBuilder.New()
                    .WithStoreAcronym("IOTCo")
                    .WithProviderCompanyAcronym("IOTCo")
                    .WithCodigoServico("TESTESERVICE")
                    .WithTipoTransacao("Billing")
                    .WithActivityType("Contractual Fine")
                    .WithTipoDisputa("Future Account")
                    .WithValorContestado(100)
                    .Build(),
            };


            var financialAccounts = new List<SAP.Domain.FinancialAccountsClient.FinancialAccount.FinancialAccount>()
            {
                FinancialAccountBuilder.New()
                    .WithStoreAcronym("telerese")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("telerese")
                    .WithHaveIntercompany(false)
                    .WithInterfaceType("Countercharge")
                    .WithAccountType("ContractualFinePaid")
                    .WithFinancialAccountType("MultaTBRA")
                    .WithFinancialAccountDeb("DebTBRA")
                    .WithFinancialAccountCred("CredTBRA")
                    .Build(),

                FinancialAccountBuilder.New()
                    .WithStoreAcronym("cloudCo")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("cloudCo")
                    .WithHaveIntercompany(false)
                    .WithInterfaceType("Countercharge")
                    .WithAccountType("ContractualFinePaid")
                    .WithFinancialAccountType("MultaTLF2")
                    .WithFinancialAccountDeb("DebTLF2")
                    .WithFinancialAccountCred("CredTLF2")
                    .Build(),
                
                FinancialAccountBuilder.New()
                    .WithStoreAcronym("IOTCo")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("IOTCo")
                    .WithHaveIntercompany(false)
                    .WithInterfaceType("Countercharge")
                    .WithAccountType("ContractualFinePaid")
                    .WithFinancialAccountType("MultaTLF3")
                    .WithFinancialAccountDeb("DebTLF3")
                    .WithFinancialAccountCred("CredTLF3")
                    .Build(),

                FinancialAccountBuilder.New()
                    .WithStoreAcronym("telerese")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("telerese")
                    .WithHaveIntercompany(false)
                    .WithInterfaceType("Countercharge")
                    .WithAccountType("ContractualFineUnpaid")
                    .WithFinancialAccountType("MultaTBRA")
                    .WithFinancialAccountDeb("DebTBRA")
                    .WithFinancialAccountCred("CredTBRA")
                    .Build(),

                FinancialAccountBuilder.New()
                    .WithStoreAcronym("cloudCo")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("cloudCo")
                    .WithHaveIntercompany(false)
                    .WithInterfaceType("Countercharge")
                    .WithAccountType("ContractualFineUnpaid")
                    .WithFinancialAccountType("MultaTLF2")
                    .WithFinancialAccountDeb("DebTLF2")
                    .WithFinancialAccountCred("CredTLF2")
                    .Build(),

                FinancialAccountBuilder.New()
                    .WithStoreAcronym("IOTCo")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("IOTCo")
                    .WithHaveIntercompany(false)
                    .WithInterfaceType("Countercharge")
                    .WithAccountType("ContractualFineUnpaid")
                    .WithFinancialAccountType("MultaTLF3")
                    .WithFinancialAccountDeb("DebTLF3")
                    .WithFinancialAccountCred("CredTLF3")
                    .Build()
            };

            request.CounterchargeDisputesBilling.AddRange(counterChargeDisputesBilling);
            request.CounterchargeDisputesAdjustment.AddRange(counterChargeDisputesAdjustment);
            request.FinancialAccountsNew.AddRange(financialAccounts);
            request.CounterchargeDisputesBilling.ForEach(f => f.FinancialAccount = request.FinancialAccounts.Find(w => w.ServiceCode.Equals(f.CodigoServico)));
            request.CounterchargeDisputesAdjustment.ForEach(f => f.FinancialAccount = request.FinancialAccounts.Find(w => w.ServiceCode.Equals(f.CodigoServico)));            
            new GetContractualFineAccountingEntryHandler().ProcessRequest(request);
            new ContractualFineLaunchHandler(uniqueStoreFinancialAccount).ProcessRequest(request);
            
            var linesTBRA = request.Lines[StoreType.TBRA];            
            linesTBRA.FindAll(l => l.FinancialAccount.Equals("MultaTBRA")).Count.Should().Be(4);
                                    
            var linesTLF2 = request.Lines[StoreType.TLF2];
            linesTLF2.FindAll(l => l.FinancialAccount.Equals("MultaTLF2")).Count.Should().Be(4);

            var linesTLF3 = request.Lines[StoreType.IOTCo];
            linesTLF3.FindAll(l => l.FinancialAccount.Equals("MultaTLF3")).Count.Should().Be(4);

        }
    }
}
