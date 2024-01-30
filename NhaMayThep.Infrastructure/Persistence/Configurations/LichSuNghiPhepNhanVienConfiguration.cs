using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class LichSuNghiPhepNhanVienConfiguration : IEntityTypeConfiguration<LichSuNghiPhepNhanVienEntity>
    {
        public void Configure(EntityTypeBuilder<LichSuNghiPhepNhanVienEntity> builder)
        {
            builder.HasOne(x => x.NguoiDuyetNhanVien)
               .WithMany()
               .HasForeignKey(x => x.NguoiDuyet)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
