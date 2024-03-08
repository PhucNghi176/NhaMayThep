using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class CapBacConfiguration : IEntityTypeConfiguration<CapBacEntity>
    {
        public void Configure(EntityTypeBuilder<CapBacEntity> builder)
        {

        }
    }
}
