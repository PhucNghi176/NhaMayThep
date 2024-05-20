using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class ChiTietNgayNghiPhepRepository : RepositoryBase<ChiTietNgayNghiPhepEntity, ChiTietNgayNghiPhepEntity, ApplicationDbContext>, IChiTietNgayNghiPhepRepository
    {
        public ChiTietNgayNghiPhepRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }


    }
}
