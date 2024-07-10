using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class FinancialAccountMap : IEntityTypeConfiguration<Entities.FinancialAccount>
    {
        public void Configure(EntityTypeBuilder<FinancialAccount> builder)
        {
            builder.ToTable("FinancialAccount", "JsdnBill");
            builder.HasKey(d => d.Id);
            builder.HasIndex(d => d.ServiceCode);
            builder.Property(d => d.StoreType).HasDefaultValue(StoreType.TBRA);
        }
    }
}
