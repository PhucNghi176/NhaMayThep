using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class DangKiCaLamConfiguration : IEntityTypeConfiguration<DangKiCaLamEntity>
    {
        public void Configure(EntityTypeBuilder<DangKiCaLamEntity> builder)
        {


            builder.Property(x => x.MaSoNhanVien)
                .IsRequired()
                .HasColumnName("MaSoNhanVien");

            builder.Property(x => x.NgayDangKi)
                .IsRequired()
                .HasColumnName("NgayDangKi");

            builder.Property(x => x.CaDangKi)
                .IsRequired()
                .HasColumnName("CaDangKi");

            builder.Property(x => x.ThoiGianCaLamBatDau)
                .HasColumnName("ThoiGianCaLamBatDau");

            builder.Property(x => x.ThoiGianCaLamKetThuc)
                .HasColumnName("ThoiGianCaLamKetThuc");

            builder.Property(x => x.ThoiGianChamCongBatDau)
                .HasColumnName("ThoiGianChamCongBatDau");

            builder.Property(x => x.ThoiGianChamCongKetThuc)
                .HasColumnName("ThoiGianChamCongKetThuc");

            builder.Property(x => x.HeSoNgayCong)
                .IsRequired()
                .HasColumnName("HeSoNgayCong");

            builder.Property(x => x.MaSoNguoiQuanLy)
                .HasColumnName("MaSoNguoiQuanLy");

            builder.Property(x => x.TrangThai)
                .IsRequired()
                .HasColumnName("TrangThai");

            builder.Property(x => x.GhiChu)
                .HasColumnName("GhiChu");

            // Configure relationships
            builder.HasOne(x => x.NhanVien)
                .WithMany()
                .HasForeignKey(x => x.MaSoNhanVien)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.MaDangKiCaLam)
                .WithMany()
                .HasForeignKey(x => x.CaDangKi)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.NguoiQuanLy)
                .WithMany()
                .HasForeignKey(x => x.MaSoNguoiQuanLy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TrangThaiDangKiCaLamViec)
                .WithMany()
                .HasForeignKey(x => x.TrangThai)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
