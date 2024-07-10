using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class LogDetailMap : IEntityTypeConfiguration<LogDetail>
    {
        public void Configure(EntityTypeBuilder<LogDetail> builder)
        {
            builder.ToTable("LogDetail", "JsdnBill");
            builder.HasKey(d => d.Id);
        }
    }
}
