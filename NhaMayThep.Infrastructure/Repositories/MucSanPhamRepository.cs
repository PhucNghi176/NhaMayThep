using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class MucSanPhamRepository : RepositoryBase<MucSanPhamEntity, MucSanPhamEntity, ApplicationDbContext>, IMucSanPhamRepository
    {
        public MucSanPhamRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}
