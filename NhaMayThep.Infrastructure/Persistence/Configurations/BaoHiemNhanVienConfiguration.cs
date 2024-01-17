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
    public class BaoHiemNhanVienConfiguration : IEntityTypeConfiguration<BaoHiemNhanVienEntity>
    {
        public void Configure(EntityTypeBuilder<BaoHiemNhanVienEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaBHNV");
            builder.Ignore(x => x.Name);
        }
    }
}
