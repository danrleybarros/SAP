using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Application.UseCases.Deferral
{
    public interface IDeferralUseCase
    {
        void Execute(DeferralRequest request);
    }
}
