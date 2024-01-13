using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class TinhTrangLamViecConfiguration : IEntityTypeConfiguration<TinhTrangLamViecEntity>
    {
        public void Configure(EntityTypeBuilder<TinhTrangLamViecEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaTinhTrangLamViecID");
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("TenMaTinhTrangLamViec");
        }
    }
}
