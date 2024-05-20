using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class BaoHiemNhanVienConfiguration : IEntityTypeConfiguration<BaoHiemNhanVienEntity>
    {
        public void Configure(EntityTypeBuilder<BaoHiemNhanVienEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaBHNV");
            builder.Property(x => x.MaSoNhanVien)
                .HasColumnName("MSNV");

        }
    }
}
