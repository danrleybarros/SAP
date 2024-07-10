using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.Boundaries.OrdemInterna
{
    public class OrdemInternaOutput
    {
        public List<UFCompOutput> OrdensInterna { get; set; }

        public OrdemInternaOutput(List<UFCompOutput> ordensInterna)
        {
            OrdensInterna = ordensInterna;
        }
    }

    public class UFCompOutput
    {
        public string UF { get; private set; }
        public string Estado { get; private set; }
        public string OrdemInterna { get; private set; }

        public UFCompOutput(string uF, string estado, string ordemInterna)
        {
            UF = uF;
            Estado = estado;
            OrdemInterna = ordemInterna;
        }
    }
}
