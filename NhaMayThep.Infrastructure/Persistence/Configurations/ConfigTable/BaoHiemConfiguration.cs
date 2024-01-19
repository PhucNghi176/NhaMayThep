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
    public class BaoHiemConfiguration : IEntityTypeConfiguration<BaoHiemEntity>
    {
        public void Configure(EntityTypeBuilder<BaoHiemEntity> builder) 
        {
            builder.HasKey(x => x.ID)
                .HasName("MaBaoHiem");
            builder.Property(x => x.ID)
                .HasColumnOrder(1);
            builder.Property(x => x.Name)
                .HasColumnName("TenLoaiBaoHiem")
                .HasColumnOrder(2);
            builder.Property(x => x.PhanTramKhauTru)
                .HasColumnOrder(6);
        }
    }
}
