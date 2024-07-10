using System.Collections.Generic;
using System.Linq;
using Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Domain.ARR.CreditCard
{
    public class ARRCreditCard : ARRDomain
    {
        public IdentificationRegisterCreditCard IdentificationRegister { get; set; }
        public Header Header { get; set; }
        public List<LaunchItem> LaunchItems { get; set; }
        public FooterCreditCard Footer { get; set; }

        public ARRCreditCard(File file) : base(file)
        {
            Header = new Header("", "");
            LaunchItems = new List<LaunchItem>();
            Footer = new FooterCreditCard(0, "", "", 0);
        }

        public ARRCreditCard(IdentificationRegisterCreditCard identificationRegister, Header header, List<LaunchItem> launchItems, Messaging.Messages.File.File file) : base(file)
        {
            this.IdentificationRegister = identificationRegister;
            this.Header = header;
            this.LaunchItems = launchItems;
            this.Footer = new FooterCreditCard(launchItems.Count, "", "", launchItems.Sum(s => s.LaunchValue));
        
            int i = 1;

            launchItems.ForEach(f => {
                f.LineNumber = i;
                i++;
            });
        }
    }
}
