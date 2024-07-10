using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.UseCases.Files.Download;
using Gcsb.Connect.SAP.Application.UseCases.Files.Download.Handlers;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Files.Download.Handlers
{
    
    public class ConvertBase64HandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        public ConvertBase64Handler convertBase64Handler;

        public ConvertBase64HandlerTest(Fixture.ApplicationFixture fixture)
        {            
            this.convertBase64Handler = fixture.Container.Resolve<ConvertBase64Handler>();
        }

        [Fact]
        public void ShouldValidate()
        {
            string str = "Hello World!";
            byte[] TestByte = Encoding.ASCII.GetBytes(str);

            var request = new DownloadUseCaseRequest(Guid.NewGuid());
            request.BytesZip = TestByte;

            convertBase64Handler.ProcessRequest(request);

            request.Logs.Any(a => a.TypeLog == Messaging.Messages.Log.Enum.TypeLog.Error).Should().BeFalse();

        }

        [Fact]
        public void ShouldNotValidate()
        {
                        
            var request = new DownloadUseCaseRequest(Guid.NewGuid());
            Action act = () => convertBase64Handler.ProcessRequest(request);

            act.Should().Throw<ArgumentNullException>();
            
        }
    }
}
