using System.Collections.Generic;
using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Domain.LEI1601;

namespace Gcsb.Connect.SAP.Tests.Builders.LEIS.Lei1601
{
    public class Lei1601Builder
    {
        public File File;
        public IdentificationRegister IdentificationRegister;
        public List<Launch> Launches;

        public static Lei1601Builder New()
        {
            return new Lei1601Builder
            {
                File = FileBuilder.New().Build(),
                IdentificationRegister = IdentificationRegisterBuilder.New().Build(),
                Launches = new List<Launch>() { LaunchBuilder.New().Build() }
            };
        }

        public Domain.LEI1601.Lei1601 Build()
        {
            return new Domain.LEI1601.Lei1601
                (
                    file: File,
                    identificationRegister: IdentificationRegister,
                    launches: Launches
                );
        }
    }
}
