using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.Config;
using Gcsb.Connect.SAP.Domain.Config;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Tests.Builders.Config;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.DataAcess.Config
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class RepositoryFinancialAccountTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IFinancialAccountReadOnlyRepository financialAccountReadOnlyRepository;
        private readonly IFinancialAccountWriteOnlyRepository financialAccountWriteOnlyRepository;
        private readonly static Guid ServiceCode = Guid.NewGuid();
        public RepositoryFinancialAccountTest(Fixture.ApplicationFixture fixture)
        {
            this.financialAccountReadOnlyRepository = fixture.Container.Resolve<IFinancialAccountReadOnlyRepository>();
            this.financialAccountWriteOnlyRepository = fixture.Container.Resolve<IFinancialAccountWriteOnlyRepository>();
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(0)]
        public void RepoFinancialAccountAddOneTest()
        {
            var model = FinancialAccountBuilder.New().WithIdFinancialAccount(Guid.NewGuid()).WithServiceCode(ServiceCode.ToString()).Build();
            Guid ret = financialAccountWriteOnlyRepository.Add(model);

            Assert.True(ret != Guid.Empty);
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(1)]
        public void RepoFinancialAccountAddManyTest()
        {
            int ret = financialAccountWriteOnlyRepository.Add(Fixture.ApplicationFixture.FinancialsAccounts);

            Assert.True(ret > 0);
        }

        [Fact]
        [Trait("Action", "Read")]
        [TestPriority(2)]
        public void ReadAllFinancialAccount()
        {
            Assert.True(financialAccountReadOnlyRepository.GetFinancialAccounts().Count > 0);
        }

        [Theory]
        [InlineData("")]
        [TestPriority(3)]
        public void ReadAllServiceCodeFinancialAccount(string financialAccount)
        {
            Assert.True(financialAccountReadOnlyRepository.GetFinancialAccounts(ServiceCode.ToString(), financialAccount, StoreType.TBRA).Count == 1);
        }

        [Theory]
        [InlineData("", "00000001")]
        [TestPriority(3)]
        public void ReadFinancialAccount(string serviceCode, string financialAccount)
        {
            Assert.True(financialAccountReadOnlyRepository.GetFinancialAccounts(serviceCode, financialAccount, StoreType.TBRA).Count > 0);
        }

        [Theory]
        [Trait("Action", "Delete")]
        [InlineData("")]
        [TestPriority(4)]
        public void DeleteFinancialAccount(string financialAccount)
        {
            FinancialAccount result = financialAccountReadOnlyRepository.GetFinancialAccounts(ServiceCode.ToString(), financialAccount, StoreType.TBRA).FirstOrDefault();
            var arr = financialAccountWriteOnlyRepository.Delete(result.Id);
            Assert.True(arr == 1 && financialAccountReadOnlyRepository.GetFinancialAccounts(ServiceCode.ToString(), financialAccount, StoreType.TBRA).Count == 0);
        }
    }
}
