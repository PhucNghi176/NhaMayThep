using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories
{
    public class TinhTrangLamViec : RepositoryBase<TinhTrangLamViecEntity, TinhTrangLamViecEntity, ApplicationDbContext>, ITinhTrangLamViec
    {
        public TinhTrangLamViec(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<TinhTrangLamViecEntity?> GetTinhTrangLamViecById(int id, CancellationToken cancellationToken)
        {
            return await FindAsync(x => x.ID.Equals(id), cancellationToken);
        }
    }
}
