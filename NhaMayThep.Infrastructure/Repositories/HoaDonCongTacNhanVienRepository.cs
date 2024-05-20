using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class HoaDonCongTacNhanVienRepository : RepositoryBase<HoaDonCongTacNhanVienEntity, HoaDonCongTacNhanVienEntity, ApplicationDbContext>, IHoaDonCongTacNhanVienRepository
    {
        public HoaDonCongTacNhanVienRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
