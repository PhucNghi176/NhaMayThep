using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories
{
    public class ThongTinGiamTruRepository : RepositoryBase<ThongTinGiamTruEntity, ThongTinGiamTruEntity, ApplicationDbContext>, IThongTinGiamTruRepository
    {
        public ThongTinGiamTruRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<ThongTinGiamTruEntity?> GetThongTinGiamTruById(int id, CancellationToken cancellationToken)
        {
            return await FindAsync(x => x.ID.Equals(id), cancellationToken);
        }
    }
}
