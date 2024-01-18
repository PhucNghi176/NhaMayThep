using AutoMapper;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class ThongTinCongDoanRepository : RepositoryBase<ThongTinCongDoanEntity, ThongTinCongDoanEntity, ApplicationDbContext>,
        IThongTinCongDoanRepository
    {
        public ThongTinCongDoanRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
