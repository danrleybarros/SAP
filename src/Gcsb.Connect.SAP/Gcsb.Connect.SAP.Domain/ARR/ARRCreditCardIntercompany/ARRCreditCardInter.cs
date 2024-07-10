using System.Collections.Generic;
using System.Linq;
using Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Domain.ARR.ARRCreditCardIntercompany
{
    public class ARRCreditCardInter : ARRDomain
    {
        public IdentificationRegisterCreditCardInter IdentificationRegister { get; set; }
        public Header Header { get; set; }
        public List<LaunchItem> LaunchItems { get; set; }
        public FooterCreditCardInter Footer { get; set; }

        public ARRCreditCardInter(File file) : base(file)
        {
            Header = new Header("", "");
            LaunchItems = new List<LaunchItem>();
            Footer = new FooterCreditCardInter(0, "", "", 0);
        }

        public ARRCreditCardInter(IdentificationRegisterCreditCardInter identificationRegister, Header header, List<LaunchItem> launchItems, Messaging.Messages.File.File file) : base(file)
        {
            this.IdentificationRegister = identificationRegister;
            this.Header = header;
            this.LaunchItems = launchItems;
            this.Footer = new FooterCreditCardInter(launchItems.Count, "", "", launchItems.Sum(s => s.LaunchValue));

            int i = 1;

            launchItems.ForEach(f => {
                f.LineNumber = i;
                i++;
            });
        }
    }
}
