using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.Mapping
{
    public class NhanVienMapThongTinCanCuocCongDanConfiguration : IEntityTypeConfiguration<NhanVienMapThongTinCanCuocCongDan>
    {
        public void Configure(EntityTypeBuilder<NhanVienMapThongTinCanCuocCongDan> builder)
        {
            builder.HasOne(e => e.NhanvienNavigation)
                .WithMany()
                .HasForeignKey(e => e.MaSoNhanVien);

            builder.HasOne(e => e.ThongTinGiamTruGiaCanhNavigation)
                .WithOne(t => t.NhanVienMapThongTinCanCuocCongDan)
                .HasForeignKey<ThongTinGiamTruGiaCanhEntity>(e => e.CanCuocCongDan);


        }
    }
}
