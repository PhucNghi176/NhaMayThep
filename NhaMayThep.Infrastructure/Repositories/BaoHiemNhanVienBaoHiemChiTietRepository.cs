using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class BaoHiemNhanVienBaoHiemChiTietRepository : RepositoryBase<BaoHiemNhanVienBaoHiemChiTietEntity, BaoHiemNhanVienBaoHiemChiTietEntity, ApplicationDbContext>, IBaoHiemNhanVienBaoHiemChiTietRepository
    {
        public BaoHiemNhanVienBaoHiemChiTietRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
