using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMapThep.Domain.Repositories.ConfigTable
{
    public interface ITinhTrangLamViecRepository : IEFRepository<TinhTrangLamViecEntity, TinhTrangLamViecEntity>
    {
        public Task<TinhTrangLamViecEntity?> GetTinhTrangLamViecById(int id, CancellationToken cancellationToken);
    }
}
