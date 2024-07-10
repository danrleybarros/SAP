namespace Gcsb.Connect.SAP.Tests.Builders.PAS
{
    public class FooterBuilder
    {
        public string TR;
        public int QtdeRegistros;

        public static FooterBuilder New()
        {
            return new FooterBuilder
            {
                TR = "SA",
                QtdeRegistros = 10
            };        
        }
     
        public FooterBuilder ComQtdeRegistros(int qtdeRegistros)
        {
            QtdeRegistros = qtdeRegistros;
            return this;
        }

        public Domain.PAS.Footer Build()
        {
            return new Domain.PAS.Footer(QtdeRegistros);
        }
    }
}
