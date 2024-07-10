using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.Upload;
using Gcsb.Connect.SAP.Tests.Builders.Upload;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.DataAcess
{

    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Trait("Upload", "Repository")]
    public class RepositoryUploadTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IUploadReadOnlyRepository uploadReadOnlyRepository;
        private readonly IUploadWriteOnlyRepository uploadWriteOnlyRepository;
        private static Guid idUpload;

        public RepositoryUploadTests(Fixture.ApplicationFixture fixture)
        {
            this.uploadReadOnlyRepository = fixture.Container.Resolve<IUploadReadOnlyRepository>();
            this.uploadWriteOnlyRepository = fixture.Container.Resolve<IUploadWriteOnlyRepository>();
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddUpload()
        {
            idUpload = Guid.NewGuid();
            var model = UploadBuilder.New().WithId(idUpload).Build();

            var ret = uploadWriteOnlyRepository.Add(model);

            Assert.True(ret > 0);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldGetAll()
        {
            var models = uploadReadOnlyRepository.GetAll();
            models.Should().HaveCountGreaterThan(0);
        }


    }
}
