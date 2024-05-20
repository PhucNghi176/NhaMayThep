using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories
{
    public class BangChucVuRepository : RepositoryBase<ThongTinChucVuEntity, ThongTinChucVuEntity, ApplicationDbContext>, IChucVuRepository
    {
        public BangChucVuRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
