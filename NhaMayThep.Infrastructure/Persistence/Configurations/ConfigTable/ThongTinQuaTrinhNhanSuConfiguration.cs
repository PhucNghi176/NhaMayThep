using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class ThongTinQuaTrinhNhanSuConfiguration : IEntityTypeConfiguration<ThongTinQuaTrinhNhanSuEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinQuaTrinhNhanSuEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaQuaTrinhNhanSu");
            builder.Property(x => x.Name)
                .HasColumnName("TenMaQuaTrinhNhanSu");
        }
    }
}
