using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.Download
{
    public class FileInput
    {
        [Required]
        public Guid? FileId { get; set; }
    }
}