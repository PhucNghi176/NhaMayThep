using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class HopDongConfiguration : IEntityTypeConfiguration<HopDongEntity>
    {
        public void Configure(EntityTypeBuilder<HopDongEntity> builder)
        {
            builder.HasOne(x=>x.ChucVu)
                .WithMany()
                .HasForeignKey(x=>x.ChucVuID)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
