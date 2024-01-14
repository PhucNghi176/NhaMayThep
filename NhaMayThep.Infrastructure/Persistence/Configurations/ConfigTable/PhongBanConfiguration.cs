using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class PhongBanConfiguration : IEntityTypeConfiguration<PhongBanEntity>
    {
        public void Configure(EntityTypeBuilder<PhongBanEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaPhongBan");
            builder.Property(x => x.Name)
                .HasColumnName("TenPhongBan");
        }
    }
}
