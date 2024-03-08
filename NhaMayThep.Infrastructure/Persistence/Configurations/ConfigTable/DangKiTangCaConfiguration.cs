using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class DangKiTangCaConfiguration : IEntityTypeConfiguration<DangKiTangCaEntity>
    {
        public void Configure(EntityTypeBuilder<DangKiTangCaEntity> builder)
        {
            builder.ToTable("DangKiTangCa");

            // Assuming MaTangCa is intended to be the primary key
            builder.HasKey(e => e.MaTangCa);

            builder.Property(e => e.MaSoNhanVien).IsRequired();
            builder.HasOne(d => d.NhanVien)
                .WithMany()
                .HasForeignKey(d => d.MaSoNhanVien)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(e => e.NgayLamTangCa).IsRequired();

            builder.Property(e => e.CaDangKi).IsRequired();
            builder.HasOne(e => e.MaDangKiCaLam)
                   .WithMany() // Specify the navigation property in the MaDangKiCaLamEntity if there is one
                   .HasForeignKey(e => e.CaDangKi);

            builder.Property(e => e.LiDoTangCa).IsRequired();
            builder.Property(e => e.ThoiGianCaLamBatDau);
            builder.Property(e => e.ThoiGianCaLamKetThuc);

            builder.Property(e => e.SoGioTangCa).IsRequired();

            builder.Property(e => e.HeSoLuongTangCa).IsRequired();

            builder.Property(e => e.TrangThaiDuyet).IsRequired();

            builder.Property(e => e.NguoiDuyet).IsRequired();
            builder.HasOne(d => d.NguoiDuyetNhanVien)
                .WithMany()
                .HasForeignKey(d => d.NguoiDuyet)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
