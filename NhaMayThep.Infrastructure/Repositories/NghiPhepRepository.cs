using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class NghiPhepRepository : RepositoryBase<NghiPhepEntity, NghiPhepEntity, ApplicationDbContext>, INghiPhepRepository
    {
        public NghiPhepRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}
