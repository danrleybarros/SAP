using System.Collections.Generic;
using Gcsb.Connect.SAP.Application.Repositories;
using Moq;

namespace Gcsb.Connect.SAP.Tests.Mock
{
    public class DynamicServiceMock
    {
        public Mock<IDynamicService> Execute()
        {
            var mock = new Mock<IDynamicService>();

            mock.Setup(s => s.GetParticipantCode(It.IsAny<List<int>>()))
                 .Returns(new List<KeyValuePair<int, string>>
                 { new KeyValuePair<int, string>(1, "3389591") });

            return mock;
        }
    }

}
