using NhaMapThep.Domain.Entities;

namespace NhaMapThep.Domain.Repositories
{
    public interface IKhaiBaoTangLuongRepository : IEFRepository<KhaiBaoTangLuongEntity, KhaiBaoTangLuongEntity>
    {
        Task<KhaiBaoTangLuongEntity?> FindByIdAsync(string id, CancellationToken cancellationToken = default);
    }
}
