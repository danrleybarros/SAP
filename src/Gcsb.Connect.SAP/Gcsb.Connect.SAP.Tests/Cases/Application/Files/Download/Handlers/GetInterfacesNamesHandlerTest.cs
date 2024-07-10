using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using FluentAssertions;
using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Files.Download;
using Gcsb.Connect.SAP.Application.UseCases.Files.Download.Handlers;
using Gcsb.Connect.SAP.Tests.Builders;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.Download;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Files.Download.Handlers
{
    
    public class GetInterfacesNamesHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly GetInterfacesNamesHandler getInterfacesNamesHandler;
        private readonly IOutputPort<DownloadOutput> outputPort;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        private static Guid idFile = Guid.Parse("4f7d07bc-c36e-4530-9c18-436cde991eb6");

        public GetInterfacesNamesHandlerTest(Fixture.ApplicationFixture fixture)
        {
            this.getInterfacesNamesHandler = fixture.Container.Resolve<GetInterfacesNamesHandler>();
            this.outputPort = fixture.Container.Resolve<IOutputPort<DownloadOutput>>();
            this.fileWriteOnlyRepository = fixture.Container.Resolve<IFileWriteOnlyRepository>();            
        }

        [Fact]
        [TestPriority(0)]
        public void ShouldAddFile()
        {
            File file = FileBuilder.New().Build();

            fileWriteOnlyRepository.Add(file).Should().BeGreaterThan(0);

        }

        [Fact]
        [TestPriority(1)]
        public void ShouldValidate()
        {
            var request = new DownloadUseCaseRequest(idFile);
            getInterfacesNamesHandler.ProcessRequest(request);

            request.Interfaces.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldNotValidate()
        {
            var request = new DownloadUseCaseRequest(Guid.NewGuid());
            getInterfacesNamesHandler.ProcessRequest(request);
                                  
            (outputPort is OkObjectResult).Should().BeFalse();
            request.Interfaces.Count.Should().Be(0);

        }

    }
}
