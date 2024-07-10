using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.Repositories.Pay.Critical
{
    public interface ICriticaWriteRepository
    {
        int Add(List<Domain.PAY.Critical> criticas);
    }
}
