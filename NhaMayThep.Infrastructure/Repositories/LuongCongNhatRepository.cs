using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class LuongCongNhatRepository : RepositoryBase<LuongCongNhatEntity, LuongCongNhatEntity, ApplicationDbContext>, ILuongCongNhatRepository
    {
        public LuongCongNhatRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}