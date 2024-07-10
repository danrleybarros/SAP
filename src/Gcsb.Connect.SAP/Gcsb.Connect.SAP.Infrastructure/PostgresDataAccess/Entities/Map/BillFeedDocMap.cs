using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class BillFeedDocMap : IEntityTypeConfiguration<BillFeedDoc>
    {
        public void Configure(EntityTypeBuilder<BillFeedDoc> builder)
        {
            builder.ToTable("BillFeed", "JsdnBill");
            builder.HasKey(d => d.Id);
        }
    }
}
