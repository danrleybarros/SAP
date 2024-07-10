using System;
using Gcsb.Connect.SAP.Domain.LEI1601;

namespace Gcsb.Connect.SAP.Tests.Builders.LEIS.Lei1601
{
    public class IdentificationRegisterBuilder
    {
        public string Filename;
        public DateTime ReferenceDate;
        public DateTime ProcessDate;
        public int Sequence;

        public static IdentificationRegisterBuilder New()
        {
            return new IdentificationRegisterBuilder
            {
                ReferenceDate = DateTime.UtcNow.AddDays(-1),
                ProcessDate = DateTime.Now,
                Sequence = 1
            };
        }

        public IdentificationRegisterBuilder WithSequence(int sequence)
        {
            Sequence = sequence;
            return this;
        }

        public IdentificationRegister Build()
        {
            return new IdentificationRegister
                (
                    refDate: ReferenceDate,
                    processDate: ProcessDate,
                    sequential: Sequence
                );
        }
    }
}
