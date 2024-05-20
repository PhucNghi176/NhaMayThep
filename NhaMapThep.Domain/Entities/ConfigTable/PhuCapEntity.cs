using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities.ConfigTable
{
    [Table("PhuCap")]
    public class PhuCapEntity : BangMaGocEntity
    {
        public required double KhoanPhuCap { get; set; }
    }
}
