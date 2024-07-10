namespace Gcsb.Connect.SAP.Tests.Builders.GF
{
    public class UfOutputBuilder
    {
        public UfOutputBuilder()
        {
            Defaults();
        }

        public string Uf;
        public string Cep;

        public UfOutputBuilder WithUf(string uf)
        {
            Uf = uf;
            return this;
        }

        public UfOutputBuilder WithCep(string cep)
        {
            Cep = cep;
            return this;
        }

        public Domain.GF.UfOutput Build()
            => new Domain.GF.UfOutput(Uf, Cep);

        public void Defaults()
        {
            Cep = "09321040";
            Uf = "SP";
        }
    }
}
