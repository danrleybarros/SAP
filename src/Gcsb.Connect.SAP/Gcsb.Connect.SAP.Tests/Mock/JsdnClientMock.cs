using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using Moq;

namespace Gcsb.Connect.SAP.Tests.Mock
{
    public class JsdnClientMock
    {
        public Mock<IJsdnService> Execute()
        {
            var mockJsdnService = new Mock<IJsdnService>();

            mockJsdnService.Setup(s => s.GetServices(It.IsAny<string>()))
                           .Returns(Task.FromResult(new List<Domain.JSDN.Service>
                           {
                               new ServiceBuilder().Build()
                           }));

            return mockJsdnService;
        }
    }
}
