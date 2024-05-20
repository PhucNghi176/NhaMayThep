using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories
{
    public class PhongBanRepository : RepositoryBase<PhongBanEntity, PhongBanEntity, ApplicationDbContext>, IPhongBanRepository
    {
        public PhongBanRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}
