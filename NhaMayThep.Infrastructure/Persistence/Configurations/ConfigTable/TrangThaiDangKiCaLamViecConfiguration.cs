using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class TrangThaiDangKiCaLamViecConfiguration :IEntityTypeConfiguration<TrangThaiDangKiCaLamViecEntity>
    {
        public void Configure(EntityTypeBuilder<TrangThaiDangKiCaLamViecEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaTrangThai");
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("TenTrangThai");
        }
    }
}
