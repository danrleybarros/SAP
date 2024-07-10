using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Client.RequestHandlers
{
    public class ClientObj
    {
        public List<Domain.GF.Client> Clients { get; private set; }        

        public ClientObj(List<Domain.GF.Client> clients)
        {
            this.Clients = clients;
        }
    }
}
