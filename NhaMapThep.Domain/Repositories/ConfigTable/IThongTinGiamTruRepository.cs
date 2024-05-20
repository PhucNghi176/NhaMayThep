using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMapThep.Domain.Repositories.ConfigTable
{
    public interface IThongTinGiamTruRepository : IEFRepository<ThongTinGiamTruEntity, ThongTinGiamTruEntity>
    {
        public Task<ThongTinGiamTruEntity?> GetThongTinGiamTruById(int id, CancellationToken cancellationToken);
    }
}
