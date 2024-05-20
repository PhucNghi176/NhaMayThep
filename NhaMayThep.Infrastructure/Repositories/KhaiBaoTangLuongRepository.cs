using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class KhaiBaoTangLuongRepository : RepositoryBase<KhaiBaoTangLuongEntity, KhaiBaoTangLuongEntity, ApplicationDbContext>, IKhaiBaoTangLuongRepository
    {
        public KhaiBaoTangLuongRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
