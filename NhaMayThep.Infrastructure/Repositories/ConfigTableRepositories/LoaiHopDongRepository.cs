using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories
{
    public class LoaiHopDongRepository : RepositoryBase<LoaiHopDongEntity, LoaiHopDongEntity, ApplicationDbContext>, ILoaiHopDongReposity
    {
        public LoaiHopDongRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
