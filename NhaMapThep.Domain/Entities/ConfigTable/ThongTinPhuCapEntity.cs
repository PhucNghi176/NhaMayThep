using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities.ConfigTable
{
    [Table("ThongTinPhuCap")]
    public class ThongTinPhuCapEntity : BangMaGocEntity
    {
        [Column(TypeName = "decimal(18, 4)")]
        public required decimal SoTienPhuCap { get; set; }
    }
}
