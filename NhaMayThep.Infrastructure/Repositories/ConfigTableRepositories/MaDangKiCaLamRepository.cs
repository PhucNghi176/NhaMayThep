using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories
{
    public class MaDangKiCaLamRepository : RepositoryBase<MaDangKiCaLamEntity, MaDangKiCaLamEntity, ApplicationDbContext>, IMaDangKiCaLamRepository
    {
        public MaDangKiCaLamRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
