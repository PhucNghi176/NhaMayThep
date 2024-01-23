using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [NotMapped]
    public class LoginEntity
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
