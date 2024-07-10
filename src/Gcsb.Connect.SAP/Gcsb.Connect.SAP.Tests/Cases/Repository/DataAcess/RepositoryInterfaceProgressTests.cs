using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.Upload;
using Gcsb.Connect.SAP.Domain.Upload;
using Gcsb.Connect.SAP.Tests.Builders.Upload;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.DataAcess
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class RepositoryInterfaceProgressTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IInterfaceProgressRepository interfaceProgressRepository;
        private static Guid idInterfaceProgress;

        public RepositoryInterfaceProgressTests(Fixture.ApplicationFixture fixture)
        {
            this.interfaceProgressRepository = fixture.Container.Resolve<IInterfaceProgressRepository>();
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddInterfaceProgress()
        {
            idInterfaceProgress = Guid.NewGuid();
            var model = InterfaceProgressBuilder.New().WithId(idInterfaceProgress).Build();

            var ret = interfaceProgressRepository.Add(model);

            Assert.True(ret > 0);
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddManyInterfaceProgress() 
        {
            var model = new List<InterfaceProgress> {
                InterfaceProgressBuilder.New().Build(),
                InterfaceProgressBuilder.New().Build(),
                InterfaceProgressBuilder.New().Build()
            };

            var ret = interfaceProgressRepository.Add(model);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldGetAllInterfaceProgress()
        {
            var models = interfaceProgressRepository.GetAll();
            models.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldGetInterfaceProgressByFilter()
        {
            var model = interfaceProgressRepository.GetByFilter(s => s.Id == idInterfaceProgress);
            model.Should().NotBeNull();
        }

        [Fact]
        [TestPriority(3)]
        public void ShouldUpdateInterfaceProgress()
        {
            var model = InterfaceProgressBuilder.New().WithId(idInterfaceProgress).Build();
            model.Should().NotBeNull();
            var newModel = InterfaceProgressBuilder.New().WithId(model.Id)
                .WithUploadType(SAP.Domain.Upload.Enum.UploadTypeEnum.Fat57_79).Build();
            interfaceProgressRepository.Update(newModel);
        }

        [Fact]
        [TestPriority(4)]
        public void ShouldDeleteInterfaceProgress()
        {
            var models = interfaceProgressRepository.GetAll();
            var ret = interfaceProgressRepository.Delete(models.First());
            ret.Should().Be(1);
        }
    }
}
