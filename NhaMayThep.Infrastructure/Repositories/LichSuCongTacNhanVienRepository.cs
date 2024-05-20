using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class LichSuCongTacNhanVienRepository : RepositoryBase<LichSuCongTacNhanVienEntity, LichSuCongTacNhanVienEntity, ApplicationDbContext>, ILichSuCongTacNhanVienRepository
    {
        public LichSuCongTacNhanVienRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
