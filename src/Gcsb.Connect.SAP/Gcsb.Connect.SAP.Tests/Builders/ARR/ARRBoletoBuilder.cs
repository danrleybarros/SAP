using Gcsb.Connect.Messaging.Messages.File;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Tests.Builders.ARR
{
    public partial class ARRBoletoBuilder : Builder<Domain.ARR.Boleto.ARRBoleto>
    {
        public ARRBoletoBuilder()
        {
            Defaults();
        }

        public File File;
        public Domain.ARR.Boleto.IdentificationRegisterBoleto IdentificationRegister;
        public Domain.ARR.Header Header;
        public List<Domain.ARR.LaunchItem> LaunchItems;
        public Domain.ARR.Boleto.FooterBoleto Footer;

        public ARRBoletoBuilder WithFile(File file)
        {
            File = file;
            return this;
        }

        public ARRBoletoBuilder WithIdentificationRegister(Domain.ARR.Boleto.IdentificationRegisterBoleto identificationregister)
        {
            IdentificationRegister = identificationregister;
            return this;
        }

        public ARRBoletoBuilder WithHeader(Domain.ARR.Header header)
        {
            Header = header;
            return this;
        }

        public ARRBoletoBuilder WithLaunchItems(List<Gcsb.Connect.SAP.Domain.ARR.LaunchItem> launchitems)
        {
            LaunchItems = launchitems;
            return this;
        }

        public ARRBoletoBuilder WithLaunchItems(params Domain.ARR.LaunchItem[] launchitems)
        {
            LaunchItems = launchitems.ToList();
            return this;
        }

        public ARRBoletoBuilder WithLaunchItems(params Action<ARRBOLETO.LaunchItemBuilder>[] builders)
        {
            var launchitems = new List<Domain.ARR.LaunchItem>();

            foreach (var builder in builders)
            {
                var b = new ARRBOLETO.LaunchItemBuilder();
                builder.Invoke(b);
                launchitems.Add(b.Build());
            }

            LaunchItems = launchitems;

            return this;
        }

        public ARRBoletoBuilder WithFooter(Domain.ARR.Boleto.FooterBoleto footer)
        {
            Footer = footer;
            return this;
        }

        public new Domain.ARR.Boleto.ARRBoleto Build()
        {
            return new Domain.ARR.Boleto.ARRBoleto(IdentificationRegister, Header, LaunchItems, File);
        }

        public new void Defaults()
        {
            IdentificationRegister = ARRBOLETO.IdentificationRegisterBuilder.New().Build();
            Header = HeaderBuilder.New().Build();
            LaunchItems = new List<Domain.ARR.LaunchItem>()
            {
                ARRBOLETO.LaunchItemBuilder.New().Build(),
            };
            Footer = ARRBOLETO.FooterBuilder.New().Build();
        }
    }
}
