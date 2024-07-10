using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Tests.Builders.FAT.FAT56
{

    public partial class FAT56Builder : Builder<Domain.FAT.FATaFaturarACM.FATaFaturarACM>
    {
        public FAT56Builder()
        {
            Defaults();
        }

        public Domain.FAT.FATaFaturarACM.IdentificationRecordACM IdentificationRecord;
        public Domain.FAT.FATBase.Header Header;
        public List<Domain.FAT.IFAT.ILaunch> Launchs;
        public Domain.FAT.FATBase.Footer Footer;

        public FAT56Builder WithIdentificationRecord(Domain.FAT.FATaFaturarACM.IdentificationRecordACM identificationrecord)
        {
            IdentificationRecord = identificationrecord;
            return this;
        }
        public FAT56Builder WithHeader(Domain.FAT.FATBase.Header header)
        {
            Header = header;
            return this;
        }
        public FAT56Builder WithLaunchs(List<Domain.FAT.FATaFaturarACM.LaunchACM> launchs)
        {
            Launchs = ListIlaunch(launchs);
            return this;
        }

        public FAT56Builder WithLaunchs(params Domain.FAT.FATaFaturarACM.LaunchACM[] launchs)
        {
            Launchs = (launchs as Domain.FAT.IFAT.ILaunch[]).ToList();
            return this;
        }

        public FAT56Builder WithLaunchs(params Action<LaunchBuilder>[] builders)
        {
            var launchs = new List<Domain.FAT.FATaFaturarACM.LaunchACM>();

            foreach (var builder in builders)
            {
                var b = new LaunchBuilder();
                builder.Invoke(b);
                launchs.Add(b.Build());
            }

            Launchs = ListIlaunch(launchs);

            return this;
        }
        public FAT56Builder WithFooter(Domain.FAT.FATBase.Footer footer)
        {
            Footer = footer;
            return this;
        }

        public new Domain.FAT.FATaFaturarACM.FATaFaturarACM Build()
        {
            return new Domain.FAT.FATaFaturarACM.FATaFaturarACM(
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
            Launchs = new List<Domain.FAT.IFAT.ILaunch> {
                LaunchBuilder.New().Build(),
                LaunchBuilder.New().Build(),
                LaunchBuilder.New().Build(),
                LaunchBuilder.New().Build(),
            };
            Footer = FATBase.FooterBuilder.New().Build();
            // Set Default Values
        }

        private List<Domain.FAT.IFAT.ILaunch> ListIlaunch(List<Domain.FAT.FATaFaturarACM.LaunchACM> launchs)
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
