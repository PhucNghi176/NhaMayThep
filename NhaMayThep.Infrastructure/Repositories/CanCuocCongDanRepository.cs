using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class CanCuocCongDanRepository : RepositoryBase<CanCuocCongDanEntity, CanCuocCongDanEntity, ApplicationDbContext>, ICanCuocCongDanRepository
    {
        public CanCuocCongDanRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
