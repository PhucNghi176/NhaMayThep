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
    public class ChiTietBaoHiemConfiguration : IEntityTypeConfiguration<ChiTietBaoHiemEntity>
    {
        public void Configure(EntityTypeBuilder<ChiTietBaoHiemEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaBHCT");
        }
    }
}
