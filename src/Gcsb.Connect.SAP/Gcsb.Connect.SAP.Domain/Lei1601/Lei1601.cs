using System.Collections.Generic;
using Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Domain.LEI1601
{
    public class Lei1601
    {
        public Lei1601(File file, IdentificationRegister identificationRegister, List<Launch> launches)
        {
            File = file;
            IdentificationRegister = identificationRegister;
            Launches = launches;
        }

        public File File { get; private set; }

        public IdentificationRegister IdentificationRegister { get; private set; }

        public List<Launch> Launches { get; private set; }
    }
}
