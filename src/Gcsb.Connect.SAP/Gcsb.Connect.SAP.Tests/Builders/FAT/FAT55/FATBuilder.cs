using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Tests.Builders.FAT.FAT55
{

    public partial class FATBuilder : Builder<Domain.FAT.FATFaturado.FATFaturado>
    {
        public FATBuilder()
        {
            Defaults();
        }

        public Domain.FAT.FATFaturado.IdentificationRecordFaturado IdentificationRecord;
        public Domain.FAT.FATBase.Header Header;
        public List<Domain.FAT.IFAT.ILaunch> Launchs;
        public Domain.FAT.FATBase.Footer Footer;

        public FATBuilder WithIdentificationRecord(Domain.FAT.FATFaturado.IdentificationRecordFaturado identificationrecord)
        {
            IdentificationRecord = identificationrecord;
            return this;
        }
        public FATBuilder WithHeader(Domain.FAT.FATBase.Header header)
        {
            Header = header;
            return this;
        }
        public FATBuilder WithLaunchs(List<Domain.FAT.FATFaturado.LaunchFaturado> launchs)
        {
            Launchs = ListIlaunch(launchs);
            return this;
        }

        public FATBuilder WithLaunchs(params Domain.FAT.FATFaturado.LaunchFaturado[] launchs)
        {
            Launchs = (launchs as Domain.FAT.IFAT.ILaunch[]).ToList();
            return this;
        }

        public FATBuilder WithLaunchs(params Action<LaunchBuilder>[] builders)
        {
            var launchs = new List<Domain.FAT.FATFaturado.LaunchFaturado>();

            foreach (var builder in builders)
            {
                var b = new LaunchBuilder();
                builder.Invoke(b);
                launchs.Add(b.Build());
            }

            Launchs = ListIlaunch(launchs);

            return this;
        }
        public FATBuilder WithFooter(Domain.FAT.FATBase.Footer footer)
        {
            Footer = footer;
            return this;
        }

        public new Domain.FAT.FATFaturado.FATFaturado Build()
        {
            return new Domain.FAT.FATFaturado.FATFaturado(
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

        private List<Domain.FAT.IFAT.ILaunch> ListIlaunch (List<Domain.FAT.FATFaturado.LaunchFaturado> launchs)
        {
            var listILaunchs = new List<Domain.FAT.IFAT.ILaunch>();
            foreach(var launch in launchs)
            {
                listILaunchs.Add(launch as Domain.FAT.IFAT.ILaunch);
            }

            return listILaunchs;
        }
    }
}
