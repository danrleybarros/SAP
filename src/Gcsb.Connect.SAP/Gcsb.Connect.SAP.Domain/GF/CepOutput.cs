using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.GF
{
    public class CepOutput
    {
        [Required]
        [MaxLength(2)]
        public string Uf { get; private set; }

        [Required]
        public string NomeLocalidade { get; private set; }

        public int? CodigoIbge { get; private set; }

        [Required]
        public string TipoLogradouro { get; private set; }

        [Required]
        public string NomeLogradouro { get; private set; }

        public string ComplementoLogradouro { get; private set; }

        [Required]
        public string Bairro { get; private set; }

        [Required]
        public string Cep { get; set; }

        public CepOutput(string uf, string nomeLocalidade, int? codigoIbge, string tipoLogradouro, string nomeLogradouro, string complementoLogradouro, string bairro, string cep)
        {
            this.Uf = uf;
            this.NomeLocalidade = nomeLocalidade;
            this.CodigoIbge = codigoIbge;
            this.TipoLogradouro = tipoLogradouro;
            this.NomeLogradouro = nomeLogradouro;
            this.ComplementoLogradouro = complementoLogradouro;
            this.Bairro = bairro;
            this.Cep = cep;
        }
    }
}
