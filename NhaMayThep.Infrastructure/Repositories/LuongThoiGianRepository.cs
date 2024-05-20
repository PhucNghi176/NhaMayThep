using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class LuongThoiGianRepository : RepositoryBase<LuongThoiGianEntity, LuongThoiGianEntity, ApplicationDbContext>,
        ILuongThoiGianRepository
    {
        public LuongThoiGianRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
