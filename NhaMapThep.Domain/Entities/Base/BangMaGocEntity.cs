using System.ComponentModel.DataAnnotations;

namespace NhaMapThep.Domain.Entities.Base
{
    public abstract class BangMaGocEntity
    {
        [Key]
        public required int ID { get; set; }
        public required string Name { get; set; }
    }
}
