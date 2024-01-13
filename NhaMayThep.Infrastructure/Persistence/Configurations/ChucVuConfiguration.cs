using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class ChucVuConfiguration : IEntityTypeConfiguration<ThongTinChucVuEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinChucVuEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaChucVuID");
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("TenMaChucVu");
        }
    }
}
