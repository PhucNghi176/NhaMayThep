using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class ThongTinCongTyRepository : RepositoryBase<ThongTinCongTyEntity, ThongTinCongTyEntity, ApplicationDbContext>,
        IThongTinCongTyRepository
    {
        public ThongTinCongTyRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}