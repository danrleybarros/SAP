using System.IO;
using Gcsb.Connect.SAP.Domain.Upload.Enum;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.Upload;
using Microsoft.AspNetCore.Http;

namespace Gcsb.Connect.SAP.Tests.Builders.Upload
{
    public class UploadRequestBuilder
    {
        public UploadTypeEnum UploadType;
        public string FileName;
        public string Base64;
        public string UserId;
        public IFormFile FileForm;

        
        public static UploadRequestBuilder New()
        {

            var dir = System.IO.Path.GetDirectoryName(typeof(UploadRequestBuilder).Assembly.Location);
            var pathShortSample = Path.Combine(dir, "InputFiles/File/placeholder.pdf");

            var stream = File.OpenRead(pathShortSample);


            return new UploadRequestBuilder()
            {
                UploadType = UploadTypeEnum.Billfeed,
                FileName = "Billfeed_05",
                Base64 = "1654asd564as89d",
                UserId = "maria.santos",
                FileForm = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
            };

        }

        public UploadRequestBuilder WithUploadType(UploadTypeEnum uploadType)
        {
            UploadType = uploadType;
            return this;
        }

        public UploadRequestBuilder WithFileName(string fileName)
        {
            FileName = fileName;
            return this;
        }

        public UploadRequestBuilder WithBase64(string base64)
        {
            Base64 = base64;
            return this;
        }

        public UploadRequestBuilder WithUserId(string userId)
        {
            UserId = userId;
            return this;
        }

        public FileInput Build()
        {
            return new FileInput()
            {
                Type = this.UploadType,
                File = this.FileForm                
            };
        }

        public FileInput64 Build64()
        {
            return new FileInput64()
            {
                Type = this.UploadType,
                Base64 = this.Base64,
                FileName = this.FileName,
            };
        }
    }
}
