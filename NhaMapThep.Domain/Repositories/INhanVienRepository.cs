using NhaMapThep.Domain.Entities;

namespace NhaMapThep.Domain.Repositories
{
    public interface INhanVienRepository : IEFRepository<NhanVienEntity, NhanVienEntity>
    {
        string HashPassword(string password);
        bool VerifyPassword (string password, string passwordHash);
        Task<NhanVienEntity?> FindByIdAsync(string id, CancellationToken cancellationToken = default);

        Task<List<NhanVienEntity>> FindByIdsAsync(string[] ids, CancellationToken cancellationToken = default);
    }
}
