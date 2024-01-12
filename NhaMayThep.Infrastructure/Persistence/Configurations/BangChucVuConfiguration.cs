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
    public class BangChucVuConfiguration : IEntityTypeConfiguration<BangChucVuEntity>
    {
        public void Configure(EntityTypeBuilder<BangChucVuEntity> builder)
        {           
            builder.HasKey(x => x.ID)
                .HasName("MaChucVuID");
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("TenMaChucVu");
        }
    }
}
