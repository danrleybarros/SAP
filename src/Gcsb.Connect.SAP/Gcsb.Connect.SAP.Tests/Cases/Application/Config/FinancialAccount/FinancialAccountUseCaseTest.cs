using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.Config;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Tests.Builders.Config;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering; 
using System.Linq;
using Xunit;
   
namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("C")]
    public class FinancialAccountUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        public readonly IFinancialAccountSaveUseCase arrUseCaseSave;
        public readonly IFinancialAccountSearchUseCase arrUseCaseSearch;
        public readonly IFinancialAccountDeleteUseCase arrUseCaseDelete;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;

        public FinancialAccountUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            this.arrUseCaseSave = fixture.Container.Resolve<IFinancialAccountSaveUseCase>();
            this.arrUseCaseSearch = fixture.Container.Resolve<IFinancialAccountSearchUseCase>();
            this.arrUseCaseDelete = fixture.Container.Resolve<IFinancialAccountDeleteUseCase>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(0)]
        public void ARRUseCaseTestAddExecute()
        {
            FinancialAccountResult request = new FinancialAccountResult(FinancialAccountBuilder.New().WithServiceCode("0000001").Build());
            var arr = arrUseCaseSave.Execute(request, "teste", "teste");
            Assert.True(arr == 1);
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(1)]
        public void ARRUseCaseNullTest()
        {
            Assert.Throws<System.ArgumentException>(() => arrUseCaseSave.Execute(null, "teste", "teste"));
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(1)]
        public void ARRUseCaseServiceCodeNullTest()
        {
            FinancialAccountResult request = new FinancialAccountResult(FinancialAccountBuilder.New().WithServiceCode(null).Build());
            Assert.Throws<System.ArgumentException>(() => arrUseCaseSave.Execute(request, "teste", "teste"));
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(2)]
        public void ARRUseCaseTestAddRepeatServiceCodeExecute()
        {
            FinancialAccountResult request = new FinancialAccountResult(FinancialAccountBuilder.New().WithServiceCode("0000001").Build());
            Assert.Throws<System.ArgumentException>(() => arrUseCaseSave.Execute(request, "teste", "teste"));
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(3)]
        public void ARRUseCaseTestAddFinancialAccountFaturamentoFatEmptyExecute()
        {
            FinancialAccountResult request = new FinancialAccountResult(FinancialAccountBuilder.New().WithServiceCode("0000002").WithFaturamentoFAT("").Build());
            Assert.Throws<System.ArgumentException>(() => arrUseCaseSave.Execute(request, "teste", "teste"));
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(3)]
        public void ARRUseCaseTestAddFinancialAccountFaturamentoFatNullExecute()
        {
            FinancialAccountResult request = new FinancialAccountResult(FinancialAccountBuilder.New().WithServiceCode("0000002").WithFaturamentoFAT(null).Build());
            Assert.Throws<System.ArgumentException>(() => arrUseCaseSave.Execute(request, "teste", "teste"));
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(4)]
        public void ARRUseCaseTestAddFinancialAccountFaturamentoAJUEmptyExecute()
        {
            FinancialAccountResult request = new FinancialAccountResult(FinancialAccountBuilder.New().WithServiceCode("0000003").WithFaturamentoAJU("").Build());
            Assert.Throws<System.ArgumentException>(() => arrUseCaseSave.Execute(request, "teste", "teste"));
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(4)]
        public void ARRUseCaseTestAddFinancialAccountFaturamentoAJUNullExecute()
        {
            FinancialAccountResult request = new FinancialAccountResult(FinancialAccountBuilder.New().WithServiceCode("0000003").WithFaturamentoAJU(null).Build());
            Assert.Throws<System.ArgumentException>(() => arrUseCaseSave.Execute(request, "teste", "teste"));
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(5)]
        public void ARRUseCaseTestAddFinancialAccountDescontoFATEmptyExecute()
        {
            FinancialAccountResult request = new FinancialAccountResult(FinancialAccountBuilder.New().WithServiceCode("0000004").WithDescontoFAT("").Build());
            Assert.Throws<System.ArgumentException>(() => arrUseCaseSave.Execute(request, "teste", "teste"));
        } 

        [Fact]
        [Trait("Action", "Search")]
        [TestPriority(8)]
        public void ARRUseCaseTestSearchServiceCodeExecute()
        {
            Assert.True(arrUseCaseSearch.Execute(new FinancialAccountRequest("0000001", "", StoreType.TBRA)).Count > 0);
        }

        [Fact]
        [Trait("Action", "Search")]
        [TestPriority(8)]
        public void ARRUseCaseTestSearchFaturamentoFATExecute()
        {
            Assert.True(arrUseCaseSearch.Execute(new FinancialAccountRequest("", "00000001", StoreType.TBRA)).Count > 0);
        }

        [Fact]
        [Trait("Action", "Search")]
        [TestPriority(8)]
        public void ARRUseCaseTestSearchFaturamentoAJUExecute()
        {
            Assert.True(arrUseCaseSearch.Execute(new FinancialAccountRequest("", "00000002", StoreType.TBRA)).Count > 0);
        }

        [Fact]
        [Trait("Action", "Search")]
        [TestPriority(8)]
        public void ARRUseCaseTestSearchDescontoFATExecute()
        {
            Assert.True(arrUseCaseSearch.Execute(new FinancialAccountRequest("", "00000003", StoreType.TBRA)).Count > 0);
        }       

        [Fact]
        [Trait("Action", "Delete")]
        [TestPriority(9)]
        public void ARRUseCaseTestDeleteExecute()
        {
            FinancialAccountResult financialAccount = arrUseCaseSearch.Execute(new FinancialAccountRequest("", "00000002",StoreType.TBRA)).FirstOrDefault();
            var arr = arrUseCaseDelete.Execute(financialAccount.Id.Value, "teste", "teste");
            Assert.True(arr == 1 && arrUseCaseSearch.Execute(new FinancialAccountRequest("", "00000002", StoreType.TBRA)).Count == 0);
        }

        [Fact]
        [Trait("Action", "Delete")]
        [TestPriority(10)]
        public void ARRUseCaseTestDeleteServiceCodeAgainExecute()
        {
            FinancialAccountResult financialAccount = arrUseCaseSearch.Execute(new FinancialAccountRequest("", "00000002", SAP.Domain.JSDN.Stores.StoreType.TBRA)).FirstOrDefault();
            Assert.Throws<System.NullReferenceException>(() => arrUseCaseDelete.Execute(financialAccount.Id.Value, "teste", "teste"));
        }

        [Fact]
        [Trait("Action", "Delete")]
        [TestPriority(11)]
        public void DigestInvoices()
        {
            invoiceWriteOnlyRepository.DeleteAll();
        }
    }
}
