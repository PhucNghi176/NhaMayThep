using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class LoaiCongTacRepository : RepositoryBase<LoaiCongTacEntity, LoaiCongTacEntity, ApplicationDbContext>, ILoaiCongTacRepository
    {
        public LoaiCongTacRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
