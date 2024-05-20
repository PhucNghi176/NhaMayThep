using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class PhuCapConfiguration : IEntityTypeConfiguration<PhuCapEntity>
    {
        public void Configure(EntityTypeBuilder<PhuCapEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaPhuCap");
            builder.Property(x => x.Name)
                .HasColumnName("TenPhuCap");
        }
    }
}
