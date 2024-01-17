using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class ChinhSachNhanSuConfiguration : IEntityTypeConfiguration<ChinhSachNhanSuEntity>
    {
        public void Configure(EntityTypeBuilder<ChinhSachNhanSuEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("ChinhSachNhanSuID");
            builder.Property(x => x.Name)
                .HasColumnName("LoaiHinhThuc");

        }
    }
}
