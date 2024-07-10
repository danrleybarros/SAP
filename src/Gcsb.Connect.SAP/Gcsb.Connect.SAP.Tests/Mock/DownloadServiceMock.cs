using System;
using System.Collections.Generic;
using System.Text;
using Gcsb.Connect.SAP.Application.Repositories.Download;
using Moq;

namespace Gcsb.Connect.SAP.Tests.Mock
{
    public class DownloadServiceMock
    {
        public Mock<IDownloadService> Execute()
        { 
            var mock = new Mock<IDownloadService>();
            
            mock
                .Setup(s => s.DownloadZip(It.IsAny<List<string>>(), It.IsAny<string>()))
                .Returns(Encoding.ASCII.GetBytes("Test"));

            return mock;        
        }
    }
}
