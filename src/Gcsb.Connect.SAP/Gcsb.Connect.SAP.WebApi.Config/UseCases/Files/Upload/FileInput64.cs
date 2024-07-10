using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.Upload
{
    public class FileInput64
    {
        [Required]
        public Domain.Upload.Enum.UploadTypeEnum? Type { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string Base64 { get; set; }
    }
}
