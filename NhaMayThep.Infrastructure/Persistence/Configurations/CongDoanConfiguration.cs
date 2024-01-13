using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class CongDoanConfiguration : IEntityTypeConfiguration<ThongTinCongDoanEntity>
    {


        public void Configure(EntityTypeBuilder<ThongTinCongDoanEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaSoCongDoan");


        }
    }
}
