using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class QuaTrinhNhanSuConfiguration : IEntityTypeConfiguration<QuaTrinhNhanSuEntity>
    {
        public void Configure(EntityTypeBuilder<QuaTrinhNhanSuEntity> builder)
        {
            builder.HasOne(x => x.ChucVu)
                 .WithOne()
                 .HasForeignKey<QuaTrinhNhanSuEntity>(x => x.ChucVuID)
                 .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
