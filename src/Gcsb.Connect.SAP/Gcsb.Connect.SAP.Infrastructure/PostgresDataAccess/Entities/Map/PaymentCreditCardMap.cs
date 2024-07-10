using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class PaymentCreditCardMap : IEntityTypeConfiguration<PaymentCreditCard>
    {
        public void Configure(EntityTypeBuilder<PaymentCreditCard> builder)
        {
            builder.ToTable("PaymentCreditCard", "JsdnBill");



        }
    }
}
