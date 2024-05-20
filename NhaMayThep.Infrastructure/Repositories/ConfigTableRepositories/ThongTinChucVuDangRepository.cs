using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories
{
    public class ThongTinChucVuDangRepository : RepositoryBase<ThongTinChucVuDangEntity, ThongTinChucVuDangEntity, ApplicationDbContext>, IThongTinChucVuDangRepository
    {
        public ThongTinChucVuDangRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
