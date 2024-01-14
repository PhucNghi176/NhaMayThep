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
    public class LichSuNghiPhepNhanVienConfiguration : IEntityTypeConfiguration<LichSuNghiPhepNhanVienEntity>
    {
        public void Configure(EntityTypeBuilder<LichSuNghiPhepNhanVienEntity> builder)
        {
            builder.HasOne(x=>x.NguoiDuyetNhanVien)
               .WithOne()
               .HasForeignKey<LichSuNghiPhepNhanVienEntity>(x => x.NguoiDuyet)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
