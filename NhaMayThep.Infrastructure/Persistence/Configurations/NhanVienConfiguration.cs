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
    public class NhanVienConfiguration : IEntityTypeConfiguration<NhanVienEntity>
    {
        public void Configure(EntityTypeBuilder<NhanVienEntity> builder)
        {
            builder.Property(x => x.NguoiTao);

            builder.Property(x => x.NguoiCapNhap);

            builder.HasOne(x => x.ChucVu)
                .WithMany()
                .HasForeignKey(x => x.ChucVuID)
                .OnDelete(DeleteBehavior.Restrict);
           
            builder.HasOne<NhanVienEntity>()
                .WithMany()
                .HasForeignKey(x => x.NguoiTao)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<NhanVienEntity>()
                .WithMany()
                .HasForeignKey(x => x.NguoiCapNhap)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
