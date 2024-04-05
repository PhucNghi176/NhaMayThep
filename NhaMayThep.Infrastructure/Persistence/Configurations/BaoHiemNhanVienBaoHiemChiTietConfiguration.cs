using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class BaoHiemNhanVienBaoHiemChiTietConfiguration : IEntityTypeConfiguration<BaoHiemNhanVienBaoHiemChiTietEntity>
    {
        public void Configure(EntityTypeBuilder<BaoHiemNhanVienBaoHiemChiTietEntity> builder)
        {
            builder.HasKey(x => new { x.BHCT, x.BHNV });

            builder.HasOne(x => x.BaoHiemNhanVienEntity)
                .WithMany(x => x.BaoHiemNhanViens)
                .HasForeignKey(x => x.BHNV)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ChiTietBaoHiemEntity)
                .WithMany(x => x.BaoHiemNhanViens)
                .HasForeignKey(x => x.BHCT)
                .OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("BaoHiemNhanVien_ChiTietBaoHiem");
        }
    }
}
