using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class MucSanPhamConfiguration : IEntityTypeConfiguration<MucSanPhamEntity>
    {
        public void Configure(EntityTypeBuilder<MucSanPhamEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaMucSP");
        }
    }
}
