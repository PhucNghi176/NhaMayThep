using NhaMayThep.Infrastructure.Persistence;

namespace NhaMapThep.Domain.Repositories
{
    public interface IThongTinCongDoanRepository : IEFRepository<ThongTinCongDoanEntity, ThongTinCongDoanEntity>,
        IRepository<ThongTinCongDoanEntity>
    {
    }
}
