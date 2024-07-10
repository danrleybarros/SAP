using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.Repositories.Pay.Critical
{
    public interface ICriticaReadRepository
    {
        List<Domain.PAY.Critical> get(Guid idPayment);
    }
}
