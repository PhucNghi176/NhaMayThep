using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Persistence;

public class LichSuNghiPhepRepository : RepositoryBase<LichSuNghiPhepNhanVienEntity, LichSuNghiPhepNhanVienEntity, ApplicationDbContext>, ILichSuNghiPhepRepository
{
    public LichSuNghiPhepRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

   

}
