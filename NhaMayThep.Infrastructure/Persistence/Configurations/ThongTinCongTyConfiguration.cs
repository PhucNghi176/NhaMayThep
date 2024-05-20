using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class ThongTinCongTyConfiguration : IEntityTypeConfiguration<ThongTinCongTyEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinCongTyEntity> builder)
        {

        }
    }
}
