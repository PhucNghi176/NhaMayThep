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

        public string GeneratePassword()
        {
            //gererate password that have 10 characters with number, uppercase, lowercase and special character
            return BCrypt.Net.BCrypt.GenerateSalt(4);
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }

    }
}
