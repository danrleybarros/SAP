using Autofac;
using Gcsb.Connect.FakeEnv.Application.UseCases.Files.GetUploadType.Handlers;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.FAT;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATFaturadoRH;
using Gcsb.Connect.SAP.Application.UseCases.Files.UploadType;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Tests.Builders;
using Gcsb.Connect.SAP.Tests.Builders.Config;
using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Files.UploadType.Handlers
{
    public class GetUploadTypeHandlerTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly GetUploadTypeHandler getUploadTypeHandler;

        public GetUploadTypeHandlerTests(Fixture.ApplicationFixture fixture)
        {
            this.getUploadTypeHandler = fixture.Container.Resolve<GetUploadTypeHandler>();
        }

        [Fact (DisplayName = "Should execute Process Request")]
        [Trait("Action", "ProcessRequest")]
        public void ProcessRequest_ShouldExecuteWithSucess()
        {
            var request = new GetUploadTypeUseCaseRequest(1);
            
            getUploadTypeHandler.ProcessRequest(request);

            Assert.True(request.UploadTypes.Count > 0);
            Assert.True(request.HasExecuted);
        }

    }
}
