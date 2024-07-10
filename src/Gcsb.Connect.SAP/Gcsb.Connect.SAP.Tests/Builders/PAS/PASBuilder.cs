using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Tests.Builders.PAS
{
    public partial class PASBuilder : Builder<Gcsb.Connect.SAP.Domain.PAS.PAS>
    {
        public PASBuilder()
        {
            Defaults();
        }

        public System.Collections.Generic.List<Gcsb.Connect.SAP.Domain.PAS.Body> Lines;

        public PASBuilder WithLines(System.Collections.Generic.List<Gcsb.Connect.SAP.Domain.PAS.Body> lines)
        {
            Lines = lines;
            return this;
        }

        public PASBuilder WithLines(params Gcsb.Connect.SAP.Domain.PAS.Body[] lines)
        {
            Lines = lines.ToList();
            return this;
        }

        public PASBuilder WithLines(params Action<BodyBuilder>[] builders)
        {
            var lines = new System.Collections.Generic.List<Gcsb.Connect.SAP.Domain.PAS.Body>();

            foreach (var builder in builders)
            {
                var b = new BodyBuilder();
                builder.Invoke(b);
                lines.Add(b.Build());
            }

            Lines = lines;

            return this;
        }

        public new Gcsb.Connect.SAP.Domain.PAS.PAS Build()
        {
            return new Gcsb.Connect.SAP.Domain.PAS.PAS(
                                DateTime.UtcNow,
                                Lines,
                                StoreType.TBRA);
        }

        public new void Defaults()
        {
            Lines = new List<Domain.PAS.Body>();

            int lenght = new Random().Next(50, 100);
            for (int i = 0; i < lenght; i++)
            {
                Lines.Add(Builders.Build.PasBody.Build());
            }
        }
    }
}
