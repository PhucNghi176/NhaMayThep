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
    public class ThongTinChucVuDangConfiguration : IEntityTypeConfiguration<ThongTinChucVuDangEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinChucVuDangEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaChucVuDang");
            builder.Property(x => x.Name)
                .HasColumnName("TenChucVuDang");
        }
    }
}
