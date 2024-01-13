using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class LoaiHopDongConfiguration : IEntityTypeConfiguration<LoaiHopDongEntity>
    {
        public void Configure(EntityTypeBuilder<LoaiHopDongEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaHopDong");
            builder.Property(x => x.Name)
                .HasColumnName("TenHopDong");
        }
    }
}
