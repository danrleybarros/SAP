using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.PAS
{
    public class Footer
    {
        private const string tr = "TR";
        private const string countFormat = "{0:0000000}";
        [Required]
        [MaxLength(2)]
        public string TR { get { return tr; } }
        [Required]
        [Range(1, 9999999)]
        [Format(countFormat)]
        public int CountLines { get; private set; }
        public Footer(int countLines)
        {
            CountLines = countLines;
        }
    }
}
