using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Persistence.Configurations
{
    public class QuaTrinhNhanSuConfiguration : IEntityTypeConfiguration<QuaTrinhNhanSuEntity>
    {
        public void Configure(EntityTypeBuilder<QuaTrinhNhanSuEntity> builder)
        {
           builder.HasOne(x=>x.ChucVu)
                .WithOne()
                .HasForeignKey<QuaTrinhNhanSuEntity>(x => x.ChucVuID)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
