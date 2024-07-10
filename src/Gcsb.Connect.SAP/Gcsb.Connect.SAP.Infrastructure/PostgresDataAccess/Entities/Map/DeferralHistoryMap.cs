using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Deferral;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class DeferralHistoryMap : IEntityTypeConfiguration<DeferralHistory>
    {
        public void Configure(EntityTypeBuilder<DeferralHistory> builder)
        {
            builder.ToTable("DeferralHistory", "JsdnBill");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.OrderId).IsRequired();
            builder.Property(d => d.OrderCreationDate).IsRequired();
            builder.Property(d => d.CompanyName).IsRequired();
            builder.Property(d => d.ServiceName).IsRequired();
            builder.Property(d => d.ServiceCode).IsRequired();
            builder.Property(d => d.GrandTotalRetailPrice).IsRequired();
            builder.Property(d => d.TotalRetailPrice).IsRequired();
            builder.Property(d => d.Receivable).IsRequired();
            builder.Property(d => d.PaymentMethod).IsRequired();
            builder.Property(d => d.PaymentOption).IsRequired();
            builder.Property(d => d.CostCenter).IsRequired();
            builder.Property(d => d.InternalOrder).IsRequired();
            builder.Property(d => d.BusinessLocation).IsRequired();
            builder.Property(d => d.FilialCode).IsRequired();
            builder.Property(d => d.UF).IsRequired();
            builder.Property(d => d.ServiceType).IsRequired();
            builder.Property(d => d.ProductStatus).IsRequired();
            builder.Property(d => d.FinancialAccount).IsRequired();
            builder.Property(d => d.NumberOfInstallments).IsRequired();
            builder.Property(d => d.DeferralDescriptionInstallment).IsRequired();
            builder.Property(d => d.ContractDeadline).IsRequired();
            builder.Property(d => d.DateStartedContract).IsRequired();
            builder.Property(d => d.StoreAcronymServiceProvider).IsRequired();
            builder.Property(d => d.CnpjServiceProviderCompany).IsRequired();
            builder.Property(d => d.NumberOfInstallments).IsRequired();
            builder.Property(d => d.DeferralType).IsRequired().HasConversion<string>();

        }

    }
}

