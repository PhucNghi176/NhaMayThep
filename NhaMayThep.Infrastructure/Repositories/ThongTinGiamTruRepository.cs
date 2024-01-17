using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class ThongTinGiamTruRepository : RepositoryBase<ThongTinGiamTruEntity, ThongTinGiamTruEntity, ApplicationDbContext>, IThongTinGiamTruRepository
    {
        public ThongTinGiamTruRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
