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
    public class ChiTietNhanVienConfiguration : IEntityTypeConfiguration
        <ChiTietNhanVienEntity>
    {
        public void Configure(EntityTypeBuilder<ChiTietNhanVienEntity> builder)
        {
           builder.HasOne<NhanVienEntity>()
                .WithMany()
                .HasForeignKey(x => x.ID)
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
