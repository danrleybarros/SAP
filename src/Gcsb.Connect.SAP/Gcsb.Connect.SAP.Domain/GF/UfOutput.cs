namespace Gcsb.Connect.SAP.Domain.GF
{
    public class UfOutput
    {
        public string Uf { get; set; }
        public string Cep { get; set; }

        public UfOutput(string uf, string cep)
        {
            Uf = uf;
            Cep = cep;
        }
    }
}