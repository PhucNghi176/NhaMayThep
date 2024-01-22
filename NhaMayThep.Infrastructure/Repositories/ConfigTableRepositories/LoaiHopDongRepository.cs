using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class LoaiHopDongRepository : RepositoryBase<LoaiHopDongEntity, LoaiHopDongEntity, ApplicationDbContext>, ILoaiHopDongReposity
    {
        public LoaiHopDongRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
