using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualReportService.RequestHandlers
{
    public class ISIObj
    {
        public List<Domain.GF.IndividualReportService> individualReportServices;

        public ISIObj(List<Domain.GF.IndividualReportService> individualReportServices)
        {
            this.individualReportServices = individualReportServices;
        }
    }
}
