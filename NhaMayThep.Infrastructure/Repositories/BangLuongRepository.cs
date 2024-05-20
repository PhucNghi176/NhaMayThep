using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class BangLuongRepository : RepositoryBase<BangLuongEntity, BangLuongEntity, ApplicationDbContext>, IBangLuongRepository
    {
        public BangLuongRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
