using Gcsb.Connect.SAP.Domain.Upload.Enum;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.Upload
{
    public class FileInput
    {
        [Required]
        public Domain.Upload.Enum.UploadTypeEnum? Type { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }    
}
