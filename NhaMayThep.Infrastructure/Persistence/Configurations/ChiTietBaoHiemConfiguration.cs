using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class ChiTietBaoHiemConfiguration : IEntityTypeConfiguration<ChiTietBaoHiemEntity>
    {
        public void Configure(EntityTypeBuilder<ChiTietBaoHiemEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaBHCT");
        }
    }
}
