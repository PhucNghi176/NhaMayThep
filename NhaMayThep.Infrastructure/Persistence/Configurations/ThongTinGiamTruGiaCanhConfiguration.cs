using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class ThongTinGiamTruGiaCanhConfiguration : IEntityTypeConfiguration<ThongTinGiamTruGiaCanhEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinGiamTruGiaCanhEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaSoNguoiPhuThuoc");
            builder.Property(x => x.MaGiamTruID)
                .HasColumnName("MaGiamTru");
            builder.Property(x => x.NhanVienID)
                .HasColumnName("MaSoNhanVien");
            builder.Property(x => x.DiaChiLienLac)
                .HasColumnName("DiaChi");
            builder.Property(x => x.CanCuocCongDan)
                .IsUnicode(false)
                .HasColumnName("CanCuocCongDanNguoiPhuThuoc");
            builder.Property(x => x.NgayXacNhanPhuThuoc)
                .HasColumnName("NgayXacNhanNguoiPhuThuoc");
        }
    }
}
