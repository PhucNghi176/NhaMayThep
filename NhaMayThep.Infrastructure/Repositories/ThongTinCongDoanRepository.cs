using AutoMapper;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class ThongTinCongDoanRepository : RepositoryBase<ThongTinCongDoanEntity, ThongTinCongDoanEntity, ApplicationDbContext>,
        IThongTinCongDoanRepository
    {
        public ThongTinCongDoanRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
