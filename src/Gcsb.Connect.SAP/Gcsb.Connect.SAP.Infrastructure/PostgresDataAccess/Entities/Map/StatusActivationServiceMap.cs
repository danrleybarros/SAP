using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class StatusActivationServiceMap : IEntityTypeConfiguration<Entities.StatusActivationService>
    {
        public void Configure(EntityTypeBuilder<StatusActivationService> builder)
        {
            builder.ToTable("StatusActivationService", "JsdnBill");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.OrderNumber).IsRequired();
            builder.Property(d => d.CustomerCode).IsRequired();
            builder.Property(d => d.ServiceCode).IsRequired();
            builder.Property(d => d.OfferCode).IsRequired();
            builder.Property(d => d.PurchaseDate).IsRequired();
            builder.Property(d => d.ActivationStatus).IsRequired().HasConversion<string>();                    

        }
    }
}
