using NhaMapThep.Domain.Entities;

namespace NhaMapThep.Domain.Repositories
{
    public interface INhanVienRepository : IEFRepository<NhanVienEntity, NhanVienEntity>
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}
