using NhaMapThep.Domain.Entities;

namespace NhaMapThep.Domain.Repositories
{
    public interface IThongTinCongDoanRepository : IEFRepository<ThongTinCongDoanEntity, ThongTinCongDoanEntity>,
        IRepository<ThongTinCongDoanEntity>
    {
    }
}
