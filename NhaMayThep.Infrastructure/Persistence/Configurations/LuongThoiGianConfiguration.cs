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
    public class LuongThoiGianConfiguration : IEntityTypeConfiguration<LuongThoiGianEntity>
    {
        public void Configure(EntityTypeBuilder<LuongThoiGianEntity> builder)
        {
            builder.Property(x => x.NgayApDung)
                .HasColumnName("NgayApDungLuongThoiGian");
        }
    }
}
