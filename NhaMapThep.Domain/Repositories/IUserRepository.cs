using NhaMapThep.Domain.Entities;

namespace NhaMapThep.Domain.Repositories
{
    public interface IUserRepository : IEFRepository<NhanVienEntity, NhanVienEntity>
    {
        Task<NhanVienEntity?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<NhanVienEntity>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default);

        Task<NhanVienEntity?> FindByUsernameAndPassword(string username, string password, CancellationToken cancellationToken = default);
    }
}
