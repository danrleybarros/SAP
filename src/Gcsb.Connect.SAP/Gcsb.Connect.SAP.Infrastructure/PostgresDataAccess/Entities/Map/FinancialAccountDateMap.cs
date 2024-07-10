using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class FinancialAccountDateMap : IEntityTypeConfiguration<FinancialAccountDate>
    {
        public void Configure(EntityTypeBuilder<FinancialAccountDate> builder)
        {
            builder.ToTable("FinancialAccountDate", "JsdnBill");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.StoreType).HasDefaultValue(StoreType.TBRA);
        }
    }
}