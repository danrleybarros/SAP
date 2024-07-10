using Newtonsoft.Json;

namespace Gcsb.Connect.SAP.Infrastructure.ApiClients.GF.Model
{
    public partial class DneResponse
    {
        [JsonProperty("CepOutput")]
        public CepOutput CepOutput { get; set; }
    }

    public partial class CepOutput
    {
        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("nomeLocalidade")]
        public string NomeLocalidade { get; set; }

        [JsonProperty("codigoIbge")]
        public int? CodigoIbge { get; set; }

        [JsonProperty("tipoLogradouro")]
        public string TipoLogradouro { get; set; }

        [JsonProperty("nomeLogradouro")]
        public string NomeLogradouro { get; set; }

        [JsonProperty("complementoLogradouro")]
        public string ComplementoLogradouro { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }
    }

    public partial class UfOutput
    {
        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("cep")]
        public string Cep { get; set; }
    }

    public partial class CodIbgeOutput
    {
        [JsonProperty("codigoIbge")]
        public int? CodIbge { get; set; }

        [JsonProperty("cep")]
        public string Cep { get; set; }
    }
}