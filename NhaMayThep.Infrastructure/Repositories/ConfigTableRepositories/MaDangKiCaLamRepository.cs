using AutoMapper;
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
    public class MaDangKiCaLamRepository : RepositoryBase<MaDangKiCaLamEntity, MaDangKiCaLamEntity, ApplicationDbContext>, IMaDangKiCaLamRepository
    {
        public MaDangKiCaLamRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
