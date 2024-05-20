using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories
{
    public class ThongTinCapDangVienRepository : RepositoryBase<ThongTinCapDangVienEntity, ThongTinCapDangVienEntity, ApplicationDbContext>, IThongTinCapDangVienRepository
    {
        public ThongTinCapDangVienRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
