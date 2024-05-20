using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class PhuCapNhanVienRepository : RepositoryBase<PhuCapNhanVienEntity, PhuCapNhanVienEntity, ApplicationDbContext>,
        IPhuCapNhanVienRepository
    {
        public PhuCapNhanVienRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
