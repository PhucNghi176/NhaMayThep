using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class LuongSanPhamRepository : RepositoryBase<LuongSanPhamEntity, LuongSanPhamEntity, ApplicationDbContext>, ILuongSanPhamRepository
    {
        public LuongSanPhamRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}