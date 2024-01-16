using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class ThongTinLuongConfiguration : IEntityTypeConfiguration<ThongTinLuongNhanVienEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinLuongNhanVienEntity> builder)
        {
            builder.HasOne(x => x.MaSoNhanVien)
                .WithOne()
                .HasForeignKey<ThongTinLuongNhanVienEntity>(x => x.NhanVien)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
