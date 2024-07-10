using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class InterfaceProgressMap : IEntityTypeConfiguration<Entities.InterfaceProgress>
    {
        public void Configure(EntityTypeBuilder<Entities.InterfaceProgress> builder)
        {
            builder.ToTable("InterfaceProgress", "JsdnBill");
            builder.HasKey(s => s.Id);
            builder.Property(d => d.IdParent);
            builder.Property(d => d.StatusType).IsRequired();
            builder.Property(d => d.RegisterDate).IsRequired();
            builder.Property(d => d.UploadType).IsRequired();            
        }
    }
}
