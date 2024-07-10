using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Deferral;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class DeferralOfferMap : IEntityTypeConfiguration<DeferralOffer>
    {
        public void Configure(EntityTypeBuilder<DeferralOffer> builder)
        {
            builder.ToTable("DeferralOffer", "JsdnBill");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.CycleDate).IsRequired();
            builder.Property(d => d.ServiceCode).IsRequired();
            builder.Property(d => d.CustomerCode).IsRequired();
            builder.Property(d => d.OrderNumber).IsRequired();
            builder.Property(d => d.ProviderStoreAcronym).IsRequired();                  
            builder.Property(d => d.StoreAcronym).IsRequired();
            builder.Property(d => d.BillingStateOrProvince).IsRequired();
            builder.Property(d => d.PaymentMethod).IsRequired();
            builder.Property(d => d.ServiceType).IsRequired();
            builder.Property(d => d.TotalShortBalance).IsRequired();
            builder.Property(d => d.TotalLongBalance).IsRequired();
            builder.Property(d => d.TotalBalance).IsRequired();
            builder.Property(d => d.InstallmentAmount).IsRequired();
            builder.Property(d => d.NumberOfInstallments).IsRequired();
            builder.Property(d => d.CurrentInstallment).IsRequired();
            builder.Property(d => d.DeferralCreationDate).IsRequired();
            builder.Property(d => d.PurchaseDate).IsRequired();
            builder.Property(d => d.LastUpdatedDate).IsRequired();
            builder.Property(d => d.DeferralStarted).IsRequired();
            builder.Property(d => d.IsIncomeRecognized).IsRequired();
            builder.Property(d => d.IsActive).IsRequired();
            builder.Property(d => d.IsNFEmitted).IsRequired();
            builder.Property(d => d.HasDiscount).IsRequired();
            builder.Property(d => d.IsProvisioned).IsRequired();
            builder.Property(d => d.DeferralType).HasConversion<string>();
            builder.Property(d => d.DeferralStatus).IsRequired().HasConversion<string>();
            builder.Property(d => d.ContractPeriod).IsRequired();
        }

    }
}

