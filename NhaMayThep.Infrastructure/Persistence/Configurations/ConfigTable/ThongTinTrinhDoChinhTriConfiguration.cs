using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class ThongTinTrinhDoChinhTriConfiguration : IEntityTypeConfiguration<ThongTinTrinhDoChinhTriEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinTrinhDoChinhTriEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaTrinhDoChinhTri");
            builder.Property(x => x.Name)
                .HasColumnName("TenTrinhDoChinhTri");
        }
    }
}
