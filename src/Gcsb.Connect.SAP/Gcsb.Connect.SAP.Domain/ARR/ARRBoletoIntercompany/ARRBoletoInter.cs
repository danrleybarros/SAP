using Gcsb.Connect.Messaging.Messages.File;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Domain.ARR.ARRBoletoIntercompany
{
    public class ARRBoletoInter : ARRDomain
    {
        public IdentificationRegisterBoleto IdentificationRegister { get; set; }
        public Header Header { get; set; }
        public List<LaunchItem> LaunchItems { get; set; }
        public FooterBoleto Footer { get; set; }

        public ARRBoletoInter(File file) : base(file)
        {
            Header = new Header("", "");
            LaunchItems = new List<LaunchItem>();
            Footer = new FooterBoleto(0, "", "", 0);
        }

        public ARRBoletoInter(IdentificationRegisterBoleto identificationRegister, Header header, List<LaunchItem> launchItems, File file) : base(file)
        {
            this.IdentificationRegister = identificationRegister;
            this.Header = header;
            this.LaunchItems = launchItems;
            this.Footer = new FooterBoleto(launchItems.Count, "", "", launchItems.Sum(s => s.LaunchValue));
        }
    }
}
