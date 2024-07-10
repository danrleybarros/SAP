using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Tests.Builders.ARRBOLETO
{
    public partial class ARRBuilder : Builder<Domain.ARR.Boleto.ARRBoleto>
    {
        public ARRBuilder()
        {
            Defaults();
        }

        public Gcsb.Connect.Messaging.Messages.File.File File;
        public Domain.ARR.Boleto.IdentificationRegisterBoleto IdentificationRegister;
        public Domain.ARR.Header Header;
        public List<Domain.ARR.LaunchItem> LaunchItems;
        public Domain.ARR.Boleto.FooterBoleto Footer;

        public ARRBuilder WithFile(Messaging.Messages.File.File file)
        {
            File = file;
            return this;
        }

        public ARRBuilder WithIdentificationRegister(Domain.ARR.Boleto.IdentificationRegisterBoleto identificationregister)
        {
            IdentificationRegister = identificationregister;
            return this;
        }

        public ARRBuilder WithHeader(Domain.ARR.Header header)
        {
            Header = header;
            return this;
        }

        public ARRBuilder WithLaunchItems(List<Domain.ARR.LaunchItem> launchitems)
        {
            LaunchItems = launchitems;
            return this;
        }

        public ARRBuilder WithLaunchItems(params Domain.ARR.LaunchItem[] launchitems)
        {
            LaunchItems = launchitems.ToList();
            return this;
        }

        public ARRBuilder WithLaunchItems(params Action<LaunchItemBuilder>[] builders)
        {
            var launchitems = new List<Domain.ARR.LaunchItem>();

            foreach (var builder in builders)
            {
                var b = new LaunchItemBuilder();
                builder.Invoke(b);
                launchitems.Add(b.Build());
            }

            LaunchItems = launchitems;

            return this;
        }

        public ARRBuilder WithFooter(Domain.ARR.Boleto.FooterBoleto footer)
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
            IdentificationRegister = IdentificationRegisterBuilder.New().Build();
            Header = HeaderBuilder.New().Build();
            LaunchItems = new List<Domain.ARR.LaunchItem>()
            {
                LaunchItemBuilder.New().Build(),
            };
            Footer = FooterBuilder.New().Build();
        }
    }
}
