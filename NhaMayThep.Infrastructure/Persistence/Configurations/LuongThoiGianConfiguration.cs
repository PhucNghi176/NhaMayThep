using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class LuongThoiGianConfiguration : IEntityTypeConfiguration<LuongThoiGianEntity>
    {
        public void Configure(EntityTypeBuilder<LuongThoiGianEntity> builder)
        {
            builder.Property(x => x.NgayApDung)
                .HasColumnName("NgayApDungLuongThoiGian");
        }
    }
}
