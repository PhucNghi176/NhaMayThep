using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class PhuCapNhanVienConfiguration : IEntityTypeConfiguration<PhuCapNhanVienEntity>
    {
        public void Configure(EntityTypeBuilder<PhuCapNhanVienEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaPCNV");


        }
    }
}
