using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class UploadMap : IEntityTypeConfiguration<Entities.Upload>
    {
        public void Configure(EntityTypeBuilder<Entities.Upload> builder)
        {
            builder.ToTable("Upload", "JsdnBill");
            builder.HasKey(s => s.Id);
            builder.Property(d => d.UploadType).IsRequired();
            builder.Property(d => d.UserId).IsRequired();
            builder.Property(d => d.UploadDate).IsRequired();
            builder.Property(d => d.FileName).IsRequired();
            builder.Property(d => d.StatusType).IsRequired();
        }
    }
}
