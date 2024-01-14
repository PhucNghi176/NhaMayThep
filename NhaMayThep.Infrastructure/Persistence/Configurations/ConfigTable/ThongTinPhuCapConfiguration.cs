using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class ThongTinPhuCapConfiguration : IEntityTypeConfiguration<ThongTinPhuCapEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinPhuCapEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaSoPhuCap");
            builder.Property(x => x.Name)
                .HasColumnName("TenPhuCap");

        }
    }
}
