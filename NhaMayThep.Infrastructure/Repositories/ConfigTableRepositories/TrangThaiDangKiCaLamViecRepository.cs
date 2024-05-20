using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories
{
    public class TrangThaiDangKiCaLamViecRepository : RepositoryBase<TrangThaiDangKiCaLamViecEntity, TrangThaiDangKiCaLamViecEntity, ApplicationDbContext>, ITrangThaiDangKiCaLamViecRepository
    {
        public TrangThaiDangKiCaLamViecRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
