using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class LoaiTangCaRepository : RepositoryBase<LoaiTangCaEntity, LoaiTangCaEntity, ApplicationDbContext>, ILoaiTangCaRepository
    {
        public LoaiTangCaRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}