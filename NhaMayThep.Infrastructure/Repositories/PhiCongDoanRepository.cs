using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class PhiCongDoanRepository : RepositoryBase<PhiCongDoanEntity, PhiCongDoanEntity, ApplicationDbContext>, IPhiCongDoanRepository
    {
        public PhiCongDoanRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
