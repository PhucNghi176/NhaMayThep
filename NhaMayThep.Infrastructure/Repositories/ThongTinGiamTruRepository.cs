using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
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
    public class ThongTinGiamTruRepository : RepositoryBase<ThongTinGiamTruEntity, ThongTinGiamTruEntity, ApplicationDbContext>, IThongTinGiamTruRepository
    {
        public ThongTinGiamTruRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<List<ThongTinGiamTruEntity>?> FindAll(CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(cancellationToken);
        }
        public async Task<ThongTinGiamTruEntity?> FindById(int Id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.ID == Id, cancellationToken);
        }
    }
}
