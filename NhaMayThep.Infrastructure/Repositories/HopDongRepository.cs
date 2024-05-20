using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class HopDongRepository : RepositoryBase<HopDongEntity, HopDongEntity, ApplicationDbContext>, IHopDongRepository
    {
        public HopDongRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
