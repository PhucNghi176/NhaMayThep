using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class CanCuocCongDanConfiguration : IEntityTypeConfiguration<CanCuocCongDanEntity>
    {
        public void Configure(EntityTypeBuilder<CanCuocCongDanEntity> builder)
        {
        }
    }
}
