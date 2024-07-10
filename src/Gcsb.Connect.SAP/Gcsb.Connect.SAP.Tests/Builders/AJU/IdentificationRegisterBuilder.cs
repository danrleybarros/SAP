using Gcsb.Connect.SAP.Domain.AJU;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.AJU
{

    public class IdentificationRegisterBuilder
    {
        public IdentificationRegisterBuilder()
        {
            Defaults();
        }

        public int Sequence;
        public DateTime BillingCycleDate;
        public StoreType StoreType;

        public IdentificationRegisterBuilder WithSequence(int sequence)
        {
            Sequence = sequence;
            return this;
        }

        public IdentificationRegisterBuilder WithBillingCycleDate(DateTime billingcycledate)
        {
            BillingCycleDate = billingcycledate;
            return this;
        }

        public IdentificationRegister Build()
        {
            return new IdentificationRegister(Sequence, BillingCycleDate, StoreType);
        }

        public void Defaults()
        {
            Sequence = 1;
            BillingCycleDate = DateTime.UtcNow;
            StoreType = StoreType.TBRA;
        }
    }
}
