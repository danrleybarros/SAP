using Gcsb.Connect.Messaging.Messages.File;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Domain.AJU
{
    public class AJU
    {
        public File File{ get; private set; }
        public IdentificationRegister IdentificationRegister { get; private set; }
        public Header Header { get; private set; }
        public List<Launch> Launches { get; private set; }
        public Footer Footer { get; private set; }

        public AJU(File file, IdentificationRegister identificationRegister, Header header, List<Launch> launches, Footer footer)
        {
            this.File = file;
            this.IdentificationRegister = identificationRegister;
            this.Header = header;
            this.Launches = launches;
            this.Footer = footer;
        }
    }
}