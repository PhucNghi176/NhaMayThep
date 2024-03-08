using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class ThongTinCapDangVienConfiguration : IEntityTypeConfiguration<ThongTinCapDangVienEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinCapDangVienEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaCapDangVien");
            builder.Property(x => x.Name)
                .HasColumnName("TenCapDangVien");
        }
    }
}
