using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class CanCuocCongDanConfiguration : IEntityTypeConfiguration<CanCuocCongDanEntity>
    {
        public void Configure(EntityTypeBuilder<CanCuocCongDanEntity> builder)
        {
            
        }     
    }
}
