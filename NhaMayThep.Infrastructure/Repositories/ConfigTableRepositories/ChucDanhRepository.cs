using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories
{
    public class ChucDanhRepository : RepositoryBase<ThongTinChucDanhEntity, ThongTinChucDanhEntity, ApplicationDbContext>, IChucDanhRepository
    {
        public ChucDanhRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
