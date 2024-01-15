using NhaMapThep.Domain.Entities;

namespace NhaMapThep.Domain.Repositories
{
    public interface INhanVienRepository : IEFRepository<NhanVienEntity, NhanVienEntity>
    {
        Task<NhanVienEntity?> FindByIdAsync(string id, CancellationToken cancellationToken = default);
    }
}
