using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.BillFeedSplit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class InvoiceMap: IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoice", "JsdnBill");
            builder.HasKey(d => d.InvoiceNumber);
            
            builder.HasMany(i => i.PaymentFeedsCredit)
                .WithOne(w => w.Invoice).HasForeignKey(f=> f.InvoiceNumberJsdn);

            builder.HasMany(i => i.PaymentFeedsBoleto)
                .WithOne(w => w.Invoice).HasForeignKey(f => f.InvoiceNumberJsdn);
        }
    }
}