using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class TrangThaiDangKiCaLamViecConfiguration : IEntityTypeConfiguration<TrangThaiDangKiCaLamViecEntity>
    {
        public void Configure(EntityTypeBuilder<TrangThaiDangKiCaLamViecEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaTrangThai");
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("TenTrangThai");
        }
    }
}
