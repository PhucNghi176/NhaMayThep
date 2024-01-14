using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class TrinhDoHocVanConfiguration : IEntityTypeConfiguration<TrinhDoHocVanEntity>
    {
        public void Configure(EntityTypeBuilder<TrinhDoHocVanEntity> builder)
        {
            builder.HasKey(x => x.ID)
                 .HasName("MaTrinhDoHocVan");
            builder.Property(t => t.Name)
                .HasColumnName("TenTrinhDo");
        }
    }
}
