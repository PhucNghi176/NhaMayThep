using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;
using System.Text;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class NhanVienRepository : RepositoryBase<NhanVienEntity, NhanVienEntity, ApplicationDbContext>, INhanVienRepository
    {
        public NhanVienRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

        public string GeneratePassword()
        {
            var characters = "qwertyuiopasdfghjklzxcvbnm1234567890!@#$%";

            var random = new Random();

            StringBuilder sb = new StringBuilder();
            while (sb.Length < 7)
            {

                // Get a random index
                var index = random.Next(characters.Length);

                // Get character at index
                var character = characters[index];

                // Append to string builder
                sb.Append(character);
            }

            return sb.ToString();
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
