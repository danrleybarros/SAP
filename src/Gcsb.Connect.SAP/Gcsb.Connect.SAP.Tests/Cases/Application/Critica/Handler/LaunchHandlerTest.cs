using Gcsb.Connect.SAP.Application.UseCases.Critical;
using Gcsb.Connect.SAP.Application.UseCases.Critical.RequestHandlers;
using Gcsb.Connect.SAP.Tests.Builders.Critica;
using Gcsb.Connect.SAP.Tests.Builders.PAY;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Critica.Handler
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("I")]
    public class LaunchHandlerTest
    {
        [Fact]
        public void ReturnTwoLinesForOneCodeBank()
        {
            var registerDate = DateTime.Now;
            var request = new CriticaRequest(Guid.NewGuid());

            request.AccountingEntriesCritica = new List<SAP.Domain.Critical.AccountingEntry>
            {
                AccountingEntryBuilder.New().WithAccountingEntryType("C").WithAccountingAccount("CriticaCre").Build(),
                AccountingEntryBuilder.New().WithAccountingEntryType("D").WithAccountingAccount("CriticaDeb").Build(),
            };

            request.Criticas = new List<SAP.Domain.PAY.Critical>
            {
                CriticalBuilder.New().WithBankCode("002").WithInvoiceAmount(150).Build(),
                CriticalBuilder.New().WithBankCode("002").WithInvoiceAmount(50).Build(),
            };

            new LaunchHandler().ProcessRequest(request);

            Assert.True(request.LaunchItems.Count == 2);
            Assert.True(request.LaunchItems.Exists(f => f.LaunchDate.Date == registerDate.Date));
            Assert.True(request.LaunchItems.Find(p => p.Type == "BCO002" && p.AccountingEntry == "C").LaunchValue == 200);
            Assert.True(request.LaunchItems.Find(p => p.Type == "BCO002" && p.AccountingEntry == "D").LaunchValue == 200);
        }

        [Fact]
        public void ReturnFourLinesForTwoCodeBank()
        {
            var registerDate = DateTime.Now;
            var request = new CriticaRequest(Guid.NewGuid());

            request.AccountingEntriesCritica = new List<SAP.Domain.Critical.AccountingEntry>
            {
                AccountingEntryBuilder.New().WithAccountingEntryType("C").WithAccountingAccount("CriticaCre").Build(),
                AccountingEntryBuilder.New().WithAccountingEntryType("D").WithAccountingAccount("CriticaDeb").Build(),
            };

            request.Criticas = new List<SAP.Domain.PAY.Critical>
            {
                CriticalBuilder.New().WithBankCode("002").WithInvoiceAmount(150).Build(),
                CriticalBuilder.New().WithBankCode("002").WithInvoiceAmount(50).Build(),
                CriticalBuilder.New().WithBankCode("050").WithInvoiceAmount(300).Build(),
                CriticalBuilder.New().WithBankCode("050").WithInvoiceAmount(80).Build(),
            };

            new LaunchHandler().ProcessRequest(request);

            Assert.True(request.LaunchItems.Count == 4);
            Assert.True(request.LaunchItems.Exists(f => f.LaunchDate.Date == registerDate.Date));
            Assert.True(request.LaunchItems.Find(p => p.Type == "BCO002" && p.AccountingEntry == "C").LaunchValue == 200);
            Assert.True(request.LaunchItems.Find(p => p.Type == "BCO002" && p.AccountingEntry == "D").LaunchValue == 200);
            Assert.True(request.LaunchItems.Find(p => p.Type == "BCO050" && p.AccountingEntry == "C").LaunchValue == 380);
            Assert.True(request.LaunchItems.Find(p => p.Type == "BCO050" && p.AccountingEntry == "D").LaunchValue == 380);
        }
    }
}
