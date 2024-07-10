using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class PaymentBoletoMap : IEntityTypeConfiguration<PaymentBoleto>
    {
        public void Configure(EntityTypeBuilder<PaymentBoleto> builder)
        {
            builder.ToTable("PaymentBoleto", "JsdnBill");
        }
    }
}