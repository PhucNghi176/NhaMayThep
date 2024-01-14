using Microsoft.EntityFrameworkCore;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class LoaiNghiPhepConfiguration : IEntityTypeConfiguration<LoaiNghiPhepEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LoaiNghiPhepEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaLoaiNghiPhep");
            builder.Property(x => x.Name)
                .HasColumnName("TenLoaiNghiPhep");
        }
    }
}
