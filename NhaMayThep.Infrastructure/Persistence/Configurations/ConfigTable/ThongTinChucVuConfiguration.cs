using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class ThongTinChucVuConfiguration : IEntityTypeConfiguration<ThongTinChucVuEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinChucVuEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaChucVu");
            builder.Property(x => x.Name)
                .HasColumnName("TenChucVu");
        }
    }
}
