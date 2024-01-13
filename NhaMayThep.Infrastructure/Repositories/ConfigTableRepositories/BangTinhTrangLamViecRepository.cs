using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories
{
    public class TinhTrangLamViecRepository : RepositoryBase<TinhTrangLamViecEntity, TinhTrangLamViecEntity, ApplicationDbContext>, ITinhTrangLamViecRepository
    {
        public TinhTrangLamViecRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
