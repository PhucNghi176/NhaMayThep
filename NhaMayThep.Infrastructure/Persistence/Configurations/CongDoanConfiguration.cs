using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class CongDoanConfiguration : IEntityTypeConfiguration<ThongTinCongDoanEntity>
    {


        public void Configure(EntityTypeBuilder<ThongTinCongDoanEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaSoCongDoan");
            builder.Property(x => x.NhanVienID)
                .HasColumnName("MaSoNhanVien");
            builder.Property(x => x.ThuKiCongDoan)
               .HasColumnName("ThuKyCongDoan");
            builder.Property(x => x.NgayGiaNhap)
               .HasColumnName("NgayGiaNhapCongDoan");
        }
    }
}
