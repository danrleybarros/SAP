using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class PaymentFeedDocMap : IEntityTypeConfiguration<PaymentFeedDoc>
    {
        public void Configure(EntityTypeBuilder<PaymentFeedDoc> builder)
        {
            builder.ToTable("PaymentFeed", "JsdnBill");
            builder.HasKey(d => d.Id);
        }
    }
}