using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Gcsb.Connect.SAP.Tests.Builders.StatusActivationService;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.StatusActivationService
{
    public class StatusActivationServiceTest
    {
        [Fact]
        public void ShouldCreateStatusActivationService()
        {
            var model = StatusActivationServiceBuilder.New().Build();

            model.Should().NotBeNull();
        }
    }
}
