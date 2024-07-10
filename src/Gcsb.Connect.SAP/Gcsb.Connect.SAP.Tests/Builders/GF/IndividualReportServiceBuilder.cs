using System;

namespace Gcsb.Connect.SAP.Tests.Builders.GF
{
	public partial class IndividualReportServiceBuilder
	{
		public DateTime UpdateDataService;
	
		public IndividualReportServiceBuilder WithUpdateDataService(DateTime updatedataservice)
		{
			UpdateDataService = updatedataservice;
			return this;
		}
	
		public Domain.GF.IndividualReportService Build()
		    => new Domain.GF.IndividualReportService(UpdateDataService);

        public static IndividualReportServiceBuilder New()
        {
            var dateNow = DateTime.Now.AddMonths(-1);
            var lastDay = DateTime.DaysInMonth(dateNow.Year, dateNow.Month);

            return new IndividualReportServiceBuilder
            {
                UpdateDataService = new DateTime(dateNow.Year, dateNow.Month, lastDay)
            };
        }
	}
}
