
using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class BaoHiemNhanVienRepository : RepositoryBase<BaoHiemNhanVienEntity, BaoHiemNhanVienEntity, ApplicationDbContext>, IBaoHiemNhanVienRepository
    {
        public BaoHiemNhanVienRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
