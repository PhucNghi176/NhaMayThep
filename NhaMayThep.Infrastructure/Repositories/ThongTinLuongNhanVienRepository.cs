using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class ThongTinLuongNhanVienRepository : RepositoryBase<ThongTinLuongNhanVienEntity, ThongTinLuongNhanVienEntity, ApplicationDbContext>, IThongTinLuongNhanVienRepository
    {
        public ThongTinLuongNhanVienRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}
