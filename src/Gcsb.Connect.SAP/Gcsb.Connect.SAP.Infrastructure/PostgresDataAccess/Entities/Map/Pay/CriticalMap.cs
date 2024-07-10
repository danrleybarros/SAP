using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Pay;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map.Pay
{
    public class CriticalMap : IEntityTypeConfiguration<Critical>
    {
        public void Configure(EntityTypeBuilder<Critical> builder)
        {
            builder.ToTable("Critical", "JsdnBill");
            builder.HasKey(d => d.Id);

            builder.HasOne(i => i.File)
                .WithMany(w => w.Criticals).HasForeignKey(f => f.IdFile);
        }
    }
}
