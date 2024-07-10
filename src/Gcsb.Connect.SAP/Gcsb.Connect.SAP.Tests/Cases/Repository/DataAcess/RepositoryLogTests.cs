using Autofac;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.DataAcess
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class RepositoryLogTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public RepositoryLogTests(Fixture.ApplicationFixture fixture)
        {
            this.logWriteOnlyRepository = fixture.Container.Resolve<ILogWriteOnlyRepository>();
        }

        [Fact]
        [Trait("Action", "Create")]        
        public void RepoBillFeedAddManyTest()
        {            
            var listLog = new List<Log>
            {
                new Log("service", "message", TypeLog.Processing),
                new Log("BillFeed Ingest", $"The fihas already been processed", TypeLog.Error, "stacktrace")
            };            
            logWriteOnlyRepository.Add(listLog);            
        }
    }
}
