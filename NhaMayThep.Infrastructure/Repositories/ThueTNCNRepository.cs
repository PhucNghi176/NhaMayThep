using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class ThueTNCNRepository : RepositoryBase<ThueTNCNEntity, ThueTNCNEntity, ApplicationDbContext>, IThueTNCNRepository
    {
        public ThueTNCNRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}
