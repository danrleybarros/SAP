using Gcsb.Connect.SAP.Domain.FAT.FATaFaturarECM;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Tests.Builders.FAT.FAT58
{
    public class FAT58Builder : Builder<FATaFaturarECM>
    {
        public FAT58Builder()
        {
            Defaults();
        }

        public IdentificationRecordECM IdentificationRecord;
        public Header Header;
        public List<Domain.FAT.IFAT.ILaunch> Launchs;
        public Footer Footer;

        public FAT58Builder WithIdentificationRecord(IdentificationRecordECM identificationRecord)
        {
            IdentificationRecord = identificationRecord;
            return this;
        }

        public FAT58Builder WithHeader(Header header)
        {
            Header = header;
            return this;
        }

        public FAT58Builder WithLaunchs(params LaunchECM[] launchs)
        {
            Launchs = (launchs as Domain.FAT.IFAT.ILaunch[]).ToList(); ;
            return this;
        }

        public FAT58Builder WithLaunchs(params Action<LaunchBuilder>[] builders)
        {
            var launchs = new List<LaunchECM>();

            foreach(var builder in builders)
            {
                var b = new LaunchBuilder();
                builder.Invoke(b);
                launchs.Add(b.Build());
            }

            Launchs = ListIlaunch(launchs);

            return this;
        }

        public FAT58Builder WithFooter(Footer footer)
        {
            Footer = footer;
            return this;
        }

        public new FATaFaturarECM Build()
        {
            return new FATaFaturarECM(
                IdentificationRecord,
                                Header,
                                Launchs,
                                null
                );
        }

        public new void Defaults()
        {
            IdentificationRecord = IdentificationRecordBuilder.New().Build();
            Header = FATBase.HeaderBuilder.New().Build();
            Launchs = new List<Domain.FAT.IFAT.ILaunch>
            {
                LaunchBuilder.New().Build(),
                LaunchBuilder.New().Build(),
                LaunchBuilder.New().Build(),
                LaunchBuilder.New().Build(),
            };
            Footer = FATBase.FooterBuilder.New().Build();
        }

        private List<Domain.FAT.IFAT.ILaunch> ListIlaunch(List<LaunchECM> launchs)
        {
            var listILaunchs = new List<Domain.FAT.IFAT.ILaunch>();
            foreach (var launch in launchs)
            {
                listILaunchs.Add(launch as Domain.FAT.IFAT.ILaunch);
            }

            return listILaunchs;
        }
    }
}
