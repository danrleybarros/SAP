using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class FileMap : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.ToTable("File", "JsdnBill");
            builder.HasKey(d => d.Id);
        }
    }
}
