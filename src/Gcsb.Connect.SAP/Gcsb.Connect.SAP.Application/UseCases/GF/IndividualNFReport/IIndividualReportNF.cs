using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualNFReport
{
    public interface IIndividualReportNFUseCase
    {
        void Execute(IndividualReportRequestNF request);        
    }
}
