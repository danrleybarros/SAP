using Gcsb.Connect.SAP.Tests.Builders.Config;
using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Tests.Builders
{

    public class Build
    {
        public static ServiceBuilder Service { get { return new ServiceBuilder(); } }
        public static ServiceFinancialAccountBuilder ServiceFinancialAccount { get { return new ServiceFinancialAccountBuilder(); } }
        public static FAT.FAT55.FATBuilder FAT { get { return new FAT.FAT55.FATBuilder(); } }
        public static FAT.FAT56.FAT56Builder FAT56 { get { return new FAT.FAT56.FAT56Builder(); } }
        public static FAT.FAT58.FAT58Builder FAT58 { get { return new FAT.FAT58.FAT58Builder(); } }
        public static ARR.ARRBuilder ARR { get { return new ARR.ARRBuilder(); } }
        public static ARRBOLETO.ARRBuilder ARRBoleto { get { return new ARRBOLETO.ARRBuilder(); } }
        public static PAS.PASBuilder PAS { get { return new PAS.PASBuilder(); } }
        public static PAS.BodyBuilder PasBody { get { return new PAS.BodyBuilder(); } }
        public static GF.CISSBuilder CISS { get { return new GF.CISSBuilder(); } }
        public static GF.IndividualReportServiceBuilder ISI { get { return new GF.IndividualReportServiceBuilder(); } }
        public static AJU.AJUBuilder AJU { get => new AJU.AJUBuilder(); }
        public static AccountDetailsBuilder AccountDetails { get { return new AccountDetailsBuilder(); } }
        public static AccountDetailsHistoryBuilder AccountDetailsHistory { get { return new AccountDetailsHistoryBuilder(); } }

    }

    public abstract class Builder<TDomain>
    {
        protected TDomain tdomain;

        public Builder()
        {
            Defaults();
        }

        public virtual void Defaults()
        {
        }

        public TDomain Build()
        {
            return tdomain;
        }
    }
}
