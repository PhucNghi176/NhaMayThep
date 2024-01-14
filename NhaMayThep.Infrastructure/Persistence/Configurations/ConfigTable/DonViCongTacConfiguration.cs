using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class DonViCongTacConfiguration : IEntityTypeConfiguration<DonViCongTacEntity>
    {
        public void Configure(EntityTypeBuilder<DonViCongTacEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaSoDonViCongTac");
            builder.Property(x => x.Name)
                .HasColumnName("TenDonViCongTac");
        }
    }
}
