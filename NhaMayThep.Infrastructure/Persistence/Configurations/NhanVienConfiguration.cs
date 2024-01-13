using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.Mapping;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class NhanVienConfiguration : IEntityTypeConfiguration<NhanVienEntity>
    {
        public void Configure(EntityTypeBuilder<NhanVienEntity> builder)
        {
            
        }
       
    }
}
