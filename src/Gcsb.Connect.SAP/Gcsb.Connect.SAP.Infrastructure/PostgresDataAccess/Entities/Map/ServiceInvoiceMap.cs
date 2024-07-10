using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.BillFeedSplit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class ServiceInvoiceMap : IEntityTypeConfiguration<ServiceInvoice>
    {
        public void Configure(EntityTypeBuilder<ServiceInvoice> builder)
        {
            builder.ToTable("ServiceInvoice", "JsdnBill");
            builder.HasKey(d => d.Id);
        }
    }
}
