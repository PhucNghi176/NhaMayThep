using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories
{
    public class ChinhSachNhanSuRepository : RepositoryBase<ChinhSachNhanSuEntity, ChinhSachNhanSuEntity, ApplicationDbContext>, IChinhSachNhanSuRepository
    {
        public ChinhSachNhanSuRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}
