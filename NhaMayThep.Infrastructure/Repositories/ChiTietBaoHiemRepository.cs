using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class ChiTietBaoHiemRepository : RepositoryBase<ChiTietBaoHiemEntity, ChiTietBaoHiemEntity, ApplicationDbContext>, IChiTietBaoHiemRepository
    {
        public ChiTietBaoHiemRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
