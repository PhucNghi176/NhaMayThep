﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable
{
    public class ThueSatConfiguration : IEntityTypeConfiguration<ThueSuatEntity>
    {
        public void Configure(EntityTypeBuilder<ThueSuatEntity> builder)
        {
            builder.HasKey(x => x.ID)
                .HasName("MaThueSuat");
            builder.Ignore(x => x.Name);
        }
    }
}