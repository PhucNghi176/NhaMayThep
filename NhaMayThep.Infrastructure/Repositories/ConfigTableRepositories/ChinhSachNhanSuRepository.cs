using AutoMapper;
using NhaMapThep.Domain.Entities;
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
    public class ChinhSachNhanSuRepository : RepositoryBase<ChinhSachNhanSuEntity, ChinhSachNhanSuEntity, ApplicationDbContext>, IChinhSachNhanSuRepository
    {
        public ChinhSachNhanSuRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}
