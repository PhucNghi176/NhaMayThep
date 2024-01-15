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
    public class ThongTinQuaTrinhNhanSuRepository : RepositoryBase<ThongTinQuaTrinhNhanSuEntity, ThongTinQuaTrinhNhanSuEntity, ApplicationDbContext>, IThongTinQuaTrinhNhanSuRepository
    {
        public ThongTinQuaTrinhNhanSuRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            
        }
    }
}
