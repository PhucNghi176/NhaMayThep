using NhaMapThep.Domain.Entities;

namespace NhaMapThep.Domain.Repositories
{
    public interface IThongTinCongTyRepository : IEFRepository<ThongTinCongTyEntity, ThongTinCongTyEntity>,
        IRepository<ThongTinCongTyEntity>
    {
    }
}