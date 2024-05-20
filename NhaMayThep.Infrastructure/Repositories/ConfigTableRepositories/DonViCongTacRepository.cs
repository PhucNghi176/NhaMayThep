using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories
{
    public class DonViCongTacRepository : RepositoryBase<DonViCongTacEntity, DonViCongTacEntity, ApplicationDbContext>, IDonViCongTacRepository
    {
        public DonViCongTacRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
