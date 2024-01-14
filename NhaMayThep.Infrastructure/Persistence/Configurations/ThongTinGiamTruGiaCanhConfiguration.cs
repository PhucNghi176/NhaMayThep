using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class ThongTinGiamTruGiaCanhConfiguration : IEntityTypeConfiguration<ThongTinGiamTruGiaCanhEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinGiamTruGiaCanhEntity> builder)
        {
            builder.HasOne(x => x.SoCanCuoc)
                   .WithOne(c => c.ThongTinGiamTruGiaCanh)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.NhanVienMapThongTinCanCuocCongDan)
                    .WithOne(t => t.ThongTinGiamTruGiaCanhNavigation)
                    .HasPrincipalKey<NhanVienMapThongTinCanCuocCongDan>(t => t.CanCuocCongDan);
        }
    }
}
