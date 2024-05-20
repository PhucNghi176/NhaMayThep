using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class ThongTinDaoTaoRepository : RepositoryBase<ThongTinDaoTaoEntity, ThongTinDaoTaoEntity, ApplicationDbContext>, IThongTinDaoTaoRepository
    {
        public ThongTinDaoTaoRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }


    }
}
