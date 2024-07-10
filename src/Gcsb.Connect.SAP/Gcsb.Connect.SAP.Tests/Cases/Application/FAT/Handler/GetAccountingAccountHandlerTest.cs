using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;
using Gcsb.Connect.SAP.Tests.Builders.FinancialAccountsClient;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.FAT.Handler
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class GetAccountingAccountHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private GetAccountingAccountHandler GetAccountingAccountHandler;

        public GetAccountingAccountHandlerTest(Fixture.ApplicationFixture fixture)
        {
            this.GetAccountingAccountHandler = fixture.Container.Resolve<GetAccountingAccountHandler>();
        }

        [Fact]
        public void ShouldAddAccouningAccount()
        {
            var financialAccount = new List<FinancialAccount>()
           {
                FinancialAccountBuilder.New()
                    .WithStoreAcronym("CloudCo")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("CloudCo")
                    .WithHaveIntercompany(false)
                    .WithInterfaceType("Billed")
                    .WithAccountType("Billed")
                    .WithFinancialAccountType("FATO365CSPGW")
                    .WithFinancialAccountDeb("41435025")
                    .WithFinancialAccountCred("11215115")
                    .Build(),

                FinancialAccountBuilder.New()
                    .WithStoreAcronym("CloudCo")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("CloudCo")
                    .WithHaveIntercompany(false)
                    .WithInterfaceType("Billed")
                    .WithAccountType("Billed")
                    .WithFinancialAccountType("FATCLOUDAWSGW")
                    .WithFinancialAccountDeb("41431077")
                    .WithFinancialAccountCred("11215115")
                    .Build(),

                FinancialAccountBuilder.New()
                    .WithStoreAcronym("CloudCo")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("CloudCo")
                    .WithHaveIntercompany(false)
                    .WithInterfaceType("Billed")
                    .WithAccountType("Discount")
                    .WithFinancialAccountType("DESCO365CSPGW")
                    .WithFinancialAccountDeb("41435025")
                    .WithFinancialAccountCred("11215115")
                    .Build(),

                FinancialAccountBuilder.New()
                    .WithStoreAcronym("CloudCo")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("CloudCo")
                    .WithHaveIntercompany(false)
                    .WithInterfaceType("Billed")
                    .WithAccountType("Discount")
                    .WithFinancialAccountType("DESCCLOUDAWSGW")
                    .WithFinancialAccountDeb("41435025")
                    .WithFinancialAccountCred("11215115")
                    .Build()
            };

            var request = new SAP.Application.UseCases.FAT.FATRequest(Messaging.Messages.File.Enum.TypeRegister.FAT, Guid.NewGuid(), DateTime.UtcNow)
            {
                FinancialAccounts = financialAccount
            };

            GetAccountingAccountHandler.ProcessRequest(request);

            request.AccountingEntriesFaturamento.Should().HaveCountGreaterThan(0);
            request.AccountingEntriesFaturamento.Should().HaveCount(4);
            request.AccountingEntriesDesconto.Should().HaveCountGreaterThan(0);
            request.AccountingEntriesDesconto.Should().HaveCount(4);
        }
    }
}
