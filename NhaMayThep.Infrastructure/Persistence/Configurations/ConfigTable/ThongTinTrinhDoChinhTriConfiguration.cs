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
    public class ThongTinTrinhDoChinhTriConfiguration : IEntityTypeConfiguration<ThongTinTrinhDoChinhTriEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinTrinhDoChinhTriEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaTrinhDoChinhTri");
            builder.Property(x => x.Name)
                .HasColumnName("TenTrinhDoChinhTri");
        }
    }
}
