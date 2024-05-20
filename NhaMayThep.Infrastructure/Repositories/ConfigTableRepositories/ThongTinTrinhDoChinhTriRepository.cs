using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories
{
    public class ThongTinTrinhDoChinhTriRepository : RepositoryBase<ThongTinTrinhDoChinhTriEntity, ThongTinTrinhDoChinhTriEntity, ApplicationDbContext>, IThongTinTrinhDoChinhTriRepository
    {
        public ThongTinTrinhDoChinhTriRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
