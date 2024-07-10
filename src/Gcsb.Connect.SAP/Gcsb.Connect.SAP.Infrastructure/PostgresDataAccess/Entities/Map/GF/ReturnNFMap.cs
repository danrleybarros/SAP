using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class ReturnNFMap : IEntityTypeConfiguration<Entities.ReturnNF>
    {
        public void Configure(EntityTypeBuilder<ReturnNF> builder)
        {
            builder.ToTable("ReturnNF", "JsdnBill");
            builder.HasKey(d => d.Id);
            builder.HasIndex(d => d.InvoiceID);
        }
    }
}
