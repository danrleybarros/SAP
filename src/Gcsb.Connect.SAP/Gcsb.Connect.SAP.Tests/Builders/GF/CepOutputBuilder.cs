using Gcsb.Connect.SAP.Domain.GF;

namespace Gcsb.Connect.SAP.Tests.Builders.GF
{
    public class CepOutputBuilder
    {
        public CepOutputBuilder()
        {
            Defaults();
        }

        public string Uf;
        public string NomeLocalidade;
        public int? CodigoIbge;
        public string TipoLogradouro;
        public string NomeLogradouro;
        public string ComplementoLogradouro;
        public string Bairro;
        public string Cep;

        public CepOutputBuilder WithUf(string uf)
        {
            Uf = uf;
            return this;
        }

        public CepOutputBuilder WithNomeLocalidade(string nomelocalidade)
        {
            NomeLocalidade = nomelocalidade;
            return this;
        }

        public CepOutputBuilder WithCodigoIbge(int? codigoibge)
        {
            CodigoIbge = codigoibge;
            return this;
        }

        public CepOutputBuilder WithTipoLogradouro(string tipologradouro)
        {
            TipoLogradouro = tipologradouro;
            return this;
        }

        public CepOutputBuilder WithNomeLogradouro(string nomelogradouro)
        {
            NomeLogradouro = nomelogradouro;
            return this;
        }

        public CepOutputBuilder WithComplementoLogradouro(string complementologradouro)
        {
            ComplementoLogradouro = complementologradouro;
            return this;
        }

        public CepOutputBuilder WithBairro(string bairro)
        {
            Bairro = bairro;
            return this;
        }

        public CepOutputBuilder WithCep(string cep)
        {
            Cep = cep;
            return this;
        }

        public CepOutput Build()
           => new CepOutput(Uf, NomeLocalidade, CodigoIbge, TipoLogradouro, NomeLogradouro, ComplementoLogradouro, Bairro, Cep);

        public void Defaults()
        {
            Uf = "SP";
            NomeLocalidade = "Mauá";
            CodigoIbge = 3529401;
            TipoLogradouro = "Rua";
            NomeLogradouro = "Helena Bodo Bengue";
            ComplementoLogradouro = "";
            Bairro = "Jardim Zaira";
            Cep = "09321040";
        }
    }
}
