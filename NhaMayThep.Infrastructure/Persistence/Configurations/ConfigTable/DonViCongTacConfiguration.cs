using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class DonViCongTacConfiguration : IEntityTypeConfiguration<DonViCongTacEntity>
    {
        public void Configure(EntityTypeBuilder<DonViCongTacEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaSoDonViCongTac");
            builder.Property(x => x.Name)
                .HasColumnName("TenDonViCongTac");
        }
    }
}
