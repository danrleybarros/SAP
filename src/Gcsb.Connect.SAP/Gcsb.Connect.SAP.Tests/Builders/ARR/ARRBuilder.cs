using Gcsb.Connect.Messaging.Messages.File;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Tests.Builders.ARR
{
    public partial class ARRBuilder : Builder<Gcsb.Connect.SAP.Domain.ARR.CreditCard.ARRCreditCard>
    {
        public ARRBuilder()
        {
            Defaults();
        }

        public File File;
        public Domain.ARR.CreditCard.IdentificationRegisterCreditCard IdentificationRegister;
        public Domain.ARR.Header Header;
        public List<Domain.ARR.LaunchItem> LaunchItems;
        public Domain.ARR.CreditCard.FooterCreditCard Footer;

        public ARRBuilder WithFile(File file)
        {
            File = file;
            return this;
        }

        public ARRBuilder WithIdentificationRegister(Gcsb.Connect.SAP.Domain.ARR.CreditCard.IdentificationRegisterCreditCard identificationregister)
        {
            IdentificationRegister = identificationregister;
            return this;
        }

        public ARRBuilder WithHeader(Domain.ARR.Header header)
        {
            Header = header;
            return this;
        }

        public ARRBuilder WithLaunchItems(System.Collections.Generic.List<Gcsb.Connect.SAP.Domain.ARR.LaunchItem> launchitems)
        {
            LaunchItems = launchitems;
            return this;
        }

        public ARRBuilder WithLaunchItems(params Gcsb.Connect.SAP.Domain.ARR.LaunchItem[] launchitems)
        {
            LaunchItems = launchitems.ToList();
            return this;
        }

        public ARRBuilder WithLaunchItems(params Action<LaunchItemBuilder>[] builders)
        {
            var launchitems = new System.Collections.Generic.List<Gcsb.Connect.SAP.Domain.ARR.LaunchItem>();

            foreach (var builder in builders)
            {
                var b = new LaunchItemBuilder();
                builder.Invoke(b);
                launchitems.Add(b.Build());
            }

            LaunchItems = launchitems;

            return this;
        }

        public ARRBuilder WithFooter(Domain.ARR.CreditCard.FooterCreditCard footer)
        {
            Footer = footer;
            return this;
        }

        public new Domain.ARR.CreditCard.ARRCreditCard Build()
        {
            return new Domain.ARR.CreditCard.ARRCreditCard(IdentificationRegister, Header, LaunchItems, File);
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
