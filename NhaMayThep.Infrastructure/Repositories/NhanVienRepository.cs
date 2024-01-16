using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Persistence;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class NhanVienRepository : RepositoryBase<NhanVienEntity, NhanVienEntity, ApplicationDbContext>, INhanVienRepository
    {
        public NhanVienRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
        public async Task<NhanVienEntity?> FindByIdAsync(string Id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.ID == Id, cancellationToken);
        }

        public async Task<List<NhanVienEntity>> FindByIdsAsync(string[] Ids, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => Ids.Contains(x.ID), cancellationToken);
        }
    }
}
