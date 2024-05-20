using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories
{
    public class ThongTinQuaTrinhNhanSuRepository : RepositoryBase<ThongTinQuaTrinhNhanSuEntity, ThongTinQuaTrinhNhanSuEntity, ApplicationDbContext>, IThongTinQuaTrinhNhanSuRepository
    {
        public ThongTinQuaTrinhNhanSuRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}
