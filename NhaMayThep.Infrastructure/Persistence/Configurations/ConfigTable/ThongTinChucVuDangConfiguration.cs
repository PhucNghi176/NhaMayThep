using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class ThongTinChucVuDangConfiguration : IEntityTypeConfiguration<ThongTinChucVuDangEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinChucVuDangEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaChucVuDang");
            builder.Property(x => x.Name)
                .HasColumnName("TenChucVuDang");
        }
    }
}
