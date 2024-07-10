using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.GF
{
    public class CodIbgeOutput
    {
        public int? CodIbge { get; set; }

        [Required]
        public string Cep { get; set; }

        public CodIbgeOutput(int? codIbge, string cep)
        {
            CodIbge = codIbge;
            Cep = cep;
        }
    }
}
