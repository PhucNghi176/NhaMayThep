using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;
namespace NhaMayThep.Infrastructure.Repositories;
public class LoaiNghiPhepRepository : RepositoryBase<LoaiNghiPhepEntity, LoaiNghiPhepEntity, ApplicationDbContext>, ILoaiNghiPhepRepository
{
    public LoaiNghiPhepRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }


}
