using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetOrdemInterna
{
    public class GetOrdemInternaResponse
    {
        public List<UFCompResponse> OrdensInterna { get; private set; }

        public GetOrdemInternaResponse(List<UFCompResponse> ordensInterna)
        {
            OrdensInterna = ordensInterna;
        }
    }

    public class UFCompResponse
    {
        public string UF { get; private set; }
        public string Estado { get; private set; }
        public string OrdemInterna { get; private set; }

        public UFCompResponse(string uF, string estado, string ordemInterna)
        {
            UF = uF;
            Estado = estado;
            OrdemInterna = ordemInterna;
        }
    }
}
