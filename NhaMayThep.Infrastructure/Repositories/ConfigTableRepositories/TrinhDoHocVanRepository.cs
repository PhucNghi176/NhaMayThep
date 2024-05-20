using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories
{
    public class TrinhDoHocVanRepository : RepositoryBase<TrinhDoHocVanEntity, TrinhDoHocVanEntity, ApplicationDbContext>, ITrinhDoHocVanRepository
    {
        public TrinhDoHocVanRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
