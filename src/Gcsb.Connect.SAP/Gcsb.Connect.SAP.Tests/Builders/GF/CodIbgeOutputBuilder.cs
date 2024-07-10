namespace Gcsb.Connect.SAP.Tests.Builders.GF
{
    public class CodIbgeOutputBuilder
    {
        public CodIbgeOutputBuilder()
        {
            Defaults();
        }

        public int? CodIbge;
        public string Cep;

        public CodIbgeOutputBuilder WithCodIbge(int? codibge)
        {
            CodIbge = codibge;
            return this;
        }

        public CodIbgeOutputBuilder WithCep(string cep)
        {
            Cep = cep;
            return this;
        }

        public Domain.GF.CodIbgeOutput Build()
            => new Domain.GF.CodIbgeOutput(CodIbge, Cep);

        public void Defaults()
        {
            Cep = "09321040";
            CodIbge = 3529401;
        }
    }
}
