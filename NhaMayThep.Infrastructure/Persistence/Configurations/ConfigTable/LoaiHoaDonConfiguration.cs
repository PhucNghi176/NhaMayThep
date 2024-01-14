using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class LoaiHoaDonConfiguration : IEntityTypeConfiguration<LoaiHoaDonEntity>
    {
        public void Configure(EntityTypeBuilder<LoaiHoaDonEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaLoaiHoaDon");
            builder.Property(x => x.Name)
                .HasColumnName("TenLoaiHoaDon");

        }
    }

}

