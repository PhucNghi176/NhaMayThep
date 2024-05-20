using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class KhenThuongRepository : RepositoryBase<KhenThuongEntity, KhenThuongEntity, ApplicationDbContext>, IKhenThuongRepository
    {
        public KhenThuongRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
