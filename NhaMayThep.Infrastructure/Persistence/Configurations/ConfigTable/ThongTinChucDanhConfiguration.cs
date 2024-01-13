using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class ThongTinChucDanhConfiguration : IEntityTypeConfiguration<ThongTinChucDanhEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinChucDanhEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaChucDanh");
            builder.Property(x => x.Name)
                .HasColumnName("TenChucDanh");
        }
    }

}

