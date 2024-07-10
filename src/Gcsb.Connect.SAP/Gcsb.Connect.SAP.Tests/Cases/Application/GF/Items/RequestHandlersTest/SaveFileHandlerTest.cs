using Xunit;
using Gcsb.Connect.SAP.Application.UseCases.GF.Items.RequestHandlers;
using Autofac;
using Gcsb.Connect.SAP.Application.UseCases.GF.Items;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using System;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF.Items.RequestHandlersTest
{
    public class SaveFileHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly SaveFileHandler saveFileHandler;
        private readonly GetFileNameHandler getFileNameHandle;

        public SaveFileHandlerTest(Fixture.ApplicationFixture fixture)
        {
            this.saveFileHandler = fixture.Container.Resolve<SaveFileHandler>();
            this.getFileNameHandle = fixture.Container.Resolve<GetFileNameHandler>();
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("GW_ITENS_01_042019.TXT")]
        public void ShouldSaveFile(string fileName)
        {
            var request = new ItemsRequest(Guid.NewGuid()) { Invoices = new List<Invoice>() { InvoiceBuilder.New().Build() } };
            var item = new ItemsBuilder().Build();         

            request.Items.Add(item);

            getFileNameHandle.ProcessRequest(request);
            saveFileHandler.ProcessRequest(request);

            Assert.NotNull(request.File);
            Assert.Equal(Status.Success, request.File.Status);
        }

        [Fact]
        [Trait("Action", "Exception")]
        public void ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => saveFileHandler.ProcessRequest(null));
        }
    }
}
