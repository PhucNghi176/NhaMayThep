using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class BangTinhTrangLamViecConfiguration : IEntityTypeConfiguration<BangTinhTrangLamViecEntity>
    {
        public void Configure(EntityTypeBuilder<BangTinhTrangLamViecEntity> builder)
        {
            builder.HasKey(x=>x.ID)
                .HasName("MaTinhTrangLamViecID");
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("TenMaTinhTrangLamViec");
        }
    }
}
