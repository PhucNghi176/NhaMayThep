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
    public class ThongTinGiamTruRepository : RepositoryBase<ThongTinGiamTruEntity, ThongTinGiamTruEntity, ApplicationDbContext>, IThongTinGiamTruRepository
    {
        public ThongTinGiamTruRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<ThongTinGiamTruEntity?> GetThongTinGiamTruById(int id, CancellationToken cancellationToken)
        {
            return await FindAnyAsync(x => x.ID.Equals(id), cancellationToken);
        }
    }
}
