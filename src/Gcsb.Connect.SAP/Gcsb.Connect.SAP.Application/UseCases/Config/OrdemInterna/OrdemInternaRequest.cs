using Gcsb.Connect.SAP.Application.Boundaries.OrdemInterna;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.OrdemInterna
{
    public class OrdemInternaRequest
    {
        public List<string> UFs { get; protected set; }
        public StoreType Store { get; private set; }
        public OrdemInternaOutput OrdemInternaOutput { get; set; }

        public OrdemInternaRequest(List<string> uFs, StoreType store)
        {
            UFs = uFs;
            Store = store;
        }
    }
}
