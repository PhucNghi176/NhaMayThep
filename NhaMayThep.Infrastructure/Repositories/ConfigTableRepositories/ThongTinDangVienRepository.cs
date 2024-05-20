using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories
{
    public class ThongTinDangVienRepository : RepositoryBase<ThongTinDangVienEntity, ThongTinDangVienEntity, ApplicationDbContext>, IThongTinDangVienRepository
    {
        public ThongTinDangVienRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}
