using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class ThongTinCapDangVienConfiguration : IEntityTypeConfiguration<ThongTinCapDangVienEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinCapDangVienEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaCapDangVien");
            builder.Property(x => x.Name)
                .HasColumnName("TenCapDangVien");
        }
    }
}
