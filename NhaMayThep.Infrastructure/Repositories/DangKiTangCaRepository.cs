using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class DangKiTangCaRepository : RepositoryBase<DangKiTangCaEntity, DangKiTangCaEntity, ApplicationDbContext>, IDangKiTangCaRepository

    {
        public DangKiTangCaRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}
