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
    public class ThongTinPhuCap : RepositoryBase<ThongTinPhuCapEntity, ThongTinPhuCapEntity, ApplicationDbContext>, IThongTinPhuCap
    {
        public ThongTinPhuCap(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<ThongTinPhuCapEntity?> GetThongTinPhuCapById(int id, CancellationToken cancellationToken)
        {
            return await FindAsync(x => x.ID.Equals(id), cancellationToken);
        }
    }
}
