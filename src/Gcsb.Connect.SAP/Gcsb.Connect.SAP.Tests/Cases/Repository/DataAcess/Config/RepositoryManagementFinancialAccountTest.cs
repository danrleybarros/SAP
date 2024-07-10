using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.DataAcess.Config
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class RepositoryManagementFinancialAccountTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IManagementFinancialAccountReadOnlyRepository managementFinancialAccountReadOnlyRepository;
        private readonly IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteOnlyRepository;
        private readonly static Guid Id = Guid.NewGuid();

        public RepositoryManagementFinancialAccountTest(Fixture.ApplicationFixture fixture)
        {
            this.managementFinancialAccountReadOnlyRepository = fixture.Container.Resolve<IManagementFinancialAccountReadOnlyRepository>();
            this.managementFinancialAccountWriteOnlyRepository = fixture.Container.Resolve<IManagementFinancialAccountWriteOnlyRepository>();
        }


        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(0)]
        public void ShouldCreateManagementFinancialAccount()
        {
            var model = ManagementFinancialAccountBuilder.New().WithId(Id).Build();

            Guid ret = managementFinancialAccountWriteOnlyRepository.Add(model);

            Assert.True(ret != Guid.Empty);
        }

        [Fact]
        [Trait("Action", "Read")]
        [TestPriority(1)]
        public void ShouldReadManagementFinancialAccount()
        {
            Assert.True(managementFinancialAccountReadOnlyRepository.Get() != null);
        }

        [Fact]
        [Trait("Action", "Update")]
        [TestPriority(3)]
        public void ShouldUpdateManagementFinancialAccount()
        {          
            var managementFinancialAccount = ManagementFinancialAccountBuilder.New().WithId(Id)
                .WithARR(ARRBuilder.New()
                .WithBoleto(BoletoBuilder.New()
                .WithFinancialAccount("ARRBOLETO").WithAccountingAccount(AccountingAccountBuilder.New()
                .WithCredit("CREDIT001").WithDebit("DEBIT001").Build()).Build())
                .WithCreditCard(CreditCardBuilder.New()
                .WithFinancialAccount("ARRBCREDICARD")
                .WithAccountingAccount(AccountingAccountBuilder.New()
                .WithCredit("CREDIT002").WithDebit("DEBIT002").Build()).Build()).Build())
                .WithCritic(CriticBuilder.New()
                .WithFinancialAccount("CRITIC001").WithAccountingAccount(AccountingAccountBuilder.New()
                .WithCredit("CREDIT003").WithDebit("DEBIT003").Build()).Build())
                .WithTransfer(TransferBuilder.New()
                .WithFinancialAccount("TRANSFER001").WithAccountingAccount(AccountingAccountBuilder.New()
                .WithCredit("CREDIT004").WithDebit("DEBIT004").Build()).Build())
                .WithUnassigned(UnassignedBuilder.New().WithFinancialAccount("UNASSIGNED001")
                .WithAccountingAccount(AccountingAccountBuilder.New()
                .WithCredit("CREDIT005").WithDebit("DEBIT005").Build()).Build())
                .Build();

            var ret = managementFinancialAccountWriteOnlyRepository.Update(managementFinancialAccount);
            Assert.True(ret > 0);
        }

        [Fact]
        [Trait("Action", "Delete")]
        [TestPriority(4)]
        public void ShouldRemoveManagementFinancialAccount()
        {
            var model = managementFinancialAccountReadOnlyRepository.Get();
            var ret = managementFinancialAccountWriteOnlyRepository.Remove(model);
            Assert.True(ret > 0);
        }
    }
}
