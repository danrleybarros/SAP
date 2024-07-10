using System;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Client
{
    public class ClientRequest
    {
        public Guid IdFileNF { get; private set; }

        public ClientRequest(Guid idFileNF)
        {
            this.IdFileNF = idFileNF;
        }
    }
}