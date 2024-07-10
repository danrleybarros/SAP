using Gcsb.Connect.SAP.Application.Repositories.Upload;
using Gcsb.Connect.SAP.Domain.Upload;
using Gcsb.Connect.SAP.Domain.Upload.Enum;
using Gcsb.Connect.SAP.Tests.Builders.Upload;
using Moq;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Tests.Mock
{
    public class UploadStatusMock
    {
        public Mock<IUploadReadOnlyRepository> Execute()
        {
            var mock = new Mock<IUploadReadOnlyRepository>();

            mock
                .Setup(s => s.GetAll())
                    .Returns(new List<Upload>
                    {
                      UploadBuilder.New().WithUploadType(UploadTypeEnum.Billfeed).Build(),
                      UploadBuilder.New().WithUploadType(UploadTypeEnum.ReturnNF).Build(),
                      UploadBuilder.New().WithUploadType(UploadTypeEnum.Fat57_79).Build(),
                      UploadBuilder.New().WithUploadType(UploadTypeEnum.PaymentFeedBoleto).Build(),
                    });

            return mock;
        }
    }
}

   
