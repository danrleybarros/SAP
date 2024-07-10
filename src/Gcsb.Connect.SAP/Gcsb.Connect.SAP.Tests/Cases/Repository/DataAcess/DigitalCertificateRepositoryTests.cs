using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories;
using System.Collections.Generic;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.DataAcess
{
    public class DigitalCertificateRepositoryTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IDigitalCertificateRepository digitalCertificateRepository;

        public DigitalCertificateRepositoryTests(Fixture.ApplicationFixture fixture)
        {
            this.digitalCertificateRepository = fixture.Container.Resolve<IDigitalCertificateRepository>();
        }

        [Fact]
        public void ShouldExecuteViewWithSucess()
        {
            var certificateLicense = digitalCertificateRepository.GetCerficateStatusLicense(new List<string> { "120000" });

            certificateLicense.Should().NotBeNull();
            certificateLicense.Should().HaveCountGreaterThan(0);
        }
    }
}
