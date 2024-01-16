﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class LoaiCongTacConfiguration : IEntityTypeConfiguration<LoaiCongTacEntity>
    {
        public void Configure(EntityTypeBuilder<LoaiCongTacEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaLoaiCongTac");
            builder.Property(x => x.Name)
                .HasColumnName("TenLoaiCongTac");

        }
    }
}