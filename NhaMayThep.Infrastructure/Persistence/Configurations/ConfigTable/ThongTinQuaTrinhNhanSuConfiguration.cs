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
    public class ThongTinQuaTrinhNhanSuConfiguration : IEntityTypeConfiguration<ThongTinQuaTrinhNhanSuEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinQuaTrinhNhanSuEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaQuaTrinhNhanSu");
            builder.Property(x => x.Name)
                .HasColumnName("TenMaQuaTrinhNhanSu");
        }
    }
}
