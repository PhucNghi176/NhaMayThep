using NhaMapThep.Domain.Entities;

namespace NhaMapThep.Domain.Repositories
{
    public interface INhanVienRepository : IEFRepository<NhanVienEntity, NhanVienEntity>
    {
        Task<NhanVienEntity?> FindById(string Id, CancellationToken cancellationToken = default);
        string HashPassword(string password);
        bool VerifyPassword (string password, string passwordHash);
    }
}
