using Gcsb.Connect.SAP.Domain.ARR;

namespace Gcsb.Connect.SAP.Tests.Builders.ARR
{
    public class HeaderBuilder
    {
        public string TypeLine;
        public string Source;
        public string Company;
        public string InitialStartDate;
        public string LateEndDate;
        public string CompetencePeriod;
        public string Division;
        
        public static HeaderBuilder New()
        {
            return new HeaderBuilder()
            {
                TypeLine = "HH",
                Source = "ARR55",
                Company = "TBRA",
                Division = "29SP",
                CompetencePeriod = "032019",
                InitialStartDate = "",
                LateEndDate = "",
            };
        }

        public HeaderBuilder WithTypeLine(string typeLine)
        {
            this.TypeLine = typeLine;
            return this;
        }

        public HeaderBuilder WithSource(string source)
        {
            this.Source = source;
            return this;
        }

        public HeaderBuilder WithCompany(string company)
        {
            this.Company = company;
            return this;
        }

        public HeaderBuilder WithInitialStartDate(string initialStartDate)
        {
            this.InitialStartDate = initialStartDate;
            return this;
        }

        public HeaderBuilder WithLateEndDate(string lateEndDate)
        {
            this.LateEndDate = lateEndDate;
            return this;
        }

        public HeaderBuilder WithCompetencePeriod(string competencePeriod)
        {
            this.CompetencePeriod = competencePeriod;
            return this;
        }

        public HeaderBuilder WithDivision(string division)
        {
            this.Division = division;
            return this;
        }

        public Header Build()
        {
            return new Header(InitialStartDate, LateEndDate);
        }
    }
}
