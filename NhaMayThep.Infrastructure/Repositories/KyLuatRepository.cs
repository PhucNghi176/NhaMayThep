using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class KyLuatRepository : RepositoryBase<KyLuatEntity, KyLuatEntity, ApplicationDbContext>, IKyLuatRepository
    {
        public KyLuatRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
