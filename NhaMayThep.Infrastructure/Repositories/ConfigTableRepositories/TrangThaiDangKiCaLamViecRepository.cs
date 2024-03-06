﻿using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories
{
    public class TrangThaiDangKiCaLamViecRepository : RepositoryBase<TrangThaiDangKiCaLamViecEntity, TrangThaiDangKiCaLamViecEntity, ApplicationDbContext>, ITrangThaiDangKiCaLamViecRepository
    {
        public TrangThaiDangKiCaLamViecRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}