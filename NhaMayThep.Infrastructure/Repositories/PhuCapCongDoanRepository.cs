using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class PhuCapCongDoanRepository : RepositoryBase<PhuCapCongDoanEntity, PhuCapCongDoanEntity, ApplicationDbContext>, IPhuCapCongDoanRepository
    {
        public PhuCapCongDoanRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}
