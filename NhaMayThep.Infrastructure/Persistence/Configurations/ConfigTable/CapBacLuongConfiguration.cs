using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class CapBacLuongConfiguration : IEntityTypeConfiguration<CapBacLuongEntity>
    {
        public void Configure(EntityTypeBuilder<CapBacLuongEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaSoCapBacLuong");
            builder.Property(x => x.Name)
                .HasColumnName("TenCapBacLuong");

        }
    }
}
