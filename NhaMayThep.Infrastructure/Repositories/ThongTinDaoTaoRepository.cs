using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMapThep.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class ThongTinDaoTaoRepository : RepositoryBase<ThongTinDaoTaoEntity, ThongTinDaoTaoEntity, ApplicationDbContext>, IThongTinDaoTaoRepository
    {
        public ThongTinDaoTaoRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        

    }
}
