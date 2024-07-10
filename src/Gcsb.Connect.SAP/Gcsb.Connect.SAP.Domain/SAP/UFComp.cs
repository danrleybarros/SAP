using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Domain.SAP
{
    public class UFComp
    {
        public string Uf { get; private set; }
        public string State { get; private set; }
        public string InternalOrder { get; private set; }

        public UFComp(string uf, string state, string internalOrder)
        {
            Uf = uf;
            State = state;
            InternalOrder = internalOrder;
        }

        
    }
}
