using Microsoft.EntityFrameworkCore;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class LoaiNghiPhepConfiguration : IEntityTypeConfiguration<LoaiNghiPhepEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LoaiNghiPhepEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaLoaiNghiPhep");
            builder.Property(x => x.Name)
                .HasColumnName("TenLoaiNghiPhep");
        }
    }
}
