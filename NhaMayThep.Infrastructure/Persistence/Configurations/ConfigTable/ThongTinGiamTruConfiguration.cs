using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class ThongTinGiamTruConfiguration : IEntityTypeConfiguration<ThongTinGiamTruEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinGiamTruEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaGiamTru");
            builder.Property(x => x.Name)
                .HasColumnName("TenMaGiamTru");



        }
    }
}
