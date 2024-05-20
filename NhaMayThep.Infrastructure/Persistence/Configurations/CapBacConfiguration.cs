using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class CapBacConfiguration : IEntityTypeConfiguration<CapBacEntity>
    {
        public void Configure(EntityTypeBuilder<CapBacEntity> builder)
        {

        }
    }
}
