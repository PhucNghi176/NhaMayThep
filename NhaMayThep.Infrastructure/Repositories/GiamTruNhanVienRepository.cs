using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class GiamTruNhanVienRepository : RepositoryBase<GiamTruNhanVienEntity, GiamTruNhanVienEntity, ApplicationDbContext>, IGiamTruNhanVienRepository

    {
        public GiamTruNhanVienRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}
