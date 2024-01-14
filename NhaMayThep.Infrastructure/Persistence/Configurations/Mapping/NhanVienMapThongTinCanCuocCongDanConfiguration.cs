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
            builder.HasOne(nv => nv.NhanVienNavigation)
                 .WithMany()
                 .HasForeignKey(nv => nv.MaSoNhanVien);

            builder.HasOne(tt => tt.ThongTinGiamTruGiaCanhNavigation)
            .WithOne()
            .HasPrincipalKey<ThongTinGiamTruGiaCanhEntity>(tt => tt.CanCuocCongDan);
        }
    }
}
