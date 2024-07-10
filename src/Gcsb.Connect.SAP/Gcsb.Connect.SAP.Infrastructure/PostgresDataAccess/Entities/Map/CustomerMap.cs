using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.BillFeedSplit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "JsdnBill");
            builder.HasKey(d => d.Id);

            builder.HasOne(h => h.Invoice)
                .WithOne(w => w.Customer)
                .HasForeignKey<Customer>(f => f.InvoiceNumber);
        }
    }
}
