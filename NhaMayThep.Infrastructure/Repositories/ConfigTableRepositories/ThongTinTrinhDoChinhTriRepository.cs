using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
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
    public class ThongTinTrinhDoChinhTriRepository : RepositoryBase<ThongTinTrinhDoChinhTriEntity, ThongTinTrinhDoChinhTriEntity, ApplicationDbContext>, IThongTinTrinhDoChinhTriRepository
    {
        public ThongTinTrinhDoChinhTriRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
