using System;
using System.Linq;
using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.UseCases.Files.Download;
using Gcsb.Connect.SAP.Application.UseCases.Files.Download.Handlers;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Files.Download.Handlers
{
    
    public class DownloadInterfacesHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {

        private readonly DownloadInterfacesHandler downloadInterfacesHandler;

        public DownloadInterfacesHandlerTest(Fixture.ApplicationFixture fixture)
        {
            this.downloadInterfacesHandler = fixture.Container.Resolve<DownloadInterfacesHandler>();
        }

        [Fact]
        public void ShouldValidate()
        {
            var request = new DownloadUseCaseRequest(Guid.NewGuid());
            downloadInterfacesHandler.ProcessRequest(request);

            request.Logs.Any(a => a.TypeLog == Messaging.Messages.Log.Enum.TypeLog.Error).Should().BeFalse();
        }
    }
}
