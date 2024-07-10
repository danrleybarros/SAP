using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using System.Security.Principal;

namespace Gcsb.Connect.SAP.Tests.Mock
{
    public class HttpContextMock
    {
        public Mock<HttpContext> Execute()
        {
            var httpContextMock = new Mock<HttpContext>();
            var identity = new Mock<IIdentity>();
            var calimsMock = new Mock<ClaimsPrincipal>();

            httpContextMock.Setup(c => c.User).Returns(calimsMock.Object);

            return httpContextMock;
        }            
    }
}
