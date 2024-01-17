using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class ChinhSachNhanSuConfiguration : IEntityTypeConfiguration<ChinhSachNhanSuEntity>
    {
        public void Configure(EntityTypeBuilder<ChinhSachNhanSuEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("ChinhSachNhanSuID");
            builder.Property(x => x.Name)
                .HasColumnName("LoaiHinhThuc");

        }
    }
}
