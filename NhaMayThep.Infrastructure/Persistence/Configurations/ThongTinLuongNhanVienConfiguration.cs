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
    public class ThongTinLuongNhanVienConfiguration : IEntityTypeConfiguration<ThongTinLuongNhanVienEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinLuongNhanVienEntity> builder)
        {
            

            builder.HasOne(x=>x.NhanVien)
                .WithMany()
                .HasForeignKey(x=>x.MaSoNhanVien)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}
