using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Domain.AJU;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Tests.Builders.AJU
{
    public class AJUBuilder
    {
        public AJUBuilder()
        {
            Defaults();
        }

        public File File;
        public IdentificationRegister IdentificationRegister;
        public Header Header;
        public List<Launch> Launches;
        public Footer Footer;

        public AJUBuilder WithFile(File file)
        {
            File = file;
            return this;
        }

        public AJUBuilder WithIdentificationRegister(IdentificationRegister identificationregister)
        {
            IdentificationRegister = identificationregister;
            return this;
        }

        public AJUBuilder WithHeader(Header header)
        {
            Header = header;
            return this;
        }

        public AJUBuilder WithLaunches(List<Launch> launches)
        {
            Launches = launches;
            return this;
        }

        public AJUBuilder WithFooter(Footer footer)
        {
            Footer = footer;
            return this;
        }

        public void Defaults()
        {
            IdentificationRegister = new IdentificationRegisterBuilder().Build();
            Header = HeaderBuilder.New().Build();
            File = FileBuilder.New().WithFileName(IdentificationRegister.FileName).WithType(TypeRegister.AJU).Build();
            Launches = new List<Launch>();

            for (var i = 0; i < 5; i++)
                Launches.Add(new LaunchBuilder()
                    .WithFinancialAccount($"ARR0000{i}")
                    .WithLaunchValue(new Random().Next(50, 100000))
                    .WithLineNumber(i + 1)
                    .Build());

            Footer = FooterBuilder.New().WithTotalReleases(5).WithTotalReleasesValue(Launches.Sum(s => s.LaunchValue)).Build();
        }

        public Domain.AJU.AJU Build()
            => new Domain.AJU.AJU(File, IdentificationRegister, Header, Launches, Footer);
    }
}
