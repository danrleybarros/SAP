using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class CreditGrantedFinancialAccountMap : IEntityTypeConfiguration<CreditGrantedFinancialAccount>
    {
        public void Configure(EntityTypeBuilder<CreditGrantedFinancialAccount> builder)
        {
            builder.ToTable("CreditGrantedFinancialAccount", "JsdnBill");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.StoreAcronym).IsRequired().HasConversion<string>();
            builder.Property(c => c.AccountingAccountCred).IsRequired().HasMaxLength(15);
            builder.Property(c => c.AccountingAccountDeb).IsRequired().HasMaxLength(15);
            builder.Property(c => c.CreditGrantedAJU).IsRequired().HasMaxLength(15);
        }
    }
}
