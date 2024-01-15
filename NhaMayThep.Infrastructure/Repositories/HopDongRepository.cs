using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class HopDongRepository : RepositoryBase<HopDongEntity, HopDongEntity, ApplicationDbContext>, IHopDongRepository
    {
        public HopDongRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

        public async Task<HopDongEntity?> FindByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.ID == id, cancellationToken);
        }
    }
}
