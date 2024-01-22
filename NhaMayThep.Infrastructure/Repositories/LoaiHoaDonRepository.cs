using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class LoaiHoaDonRepository : RepositoryBase<LoaiHoaDonEntity, LoaiHoaDonEntity, ApplicationDbContext>, ILoaiHoaDonRepository
    {
        public LoaiHoaDonRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
