using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class ThongTinGiamTruGiaCanhRepository : RepositoryBase<ThongTinGiamTruGiaCanhEntity, ThongTinGiamTruGiaCanhEntity, ApplicationDbContext>,
        IThongTinGiamTruGiaCanhRepository
    {
        public ThongTinGiamTruGiaCanhRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
