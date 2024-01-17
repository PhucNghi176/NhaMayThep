using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("ChinhSachNhanSu")]
    public class ChinhSachNhanSuEntity : BangMaGocEntity
    {
        public required string MucDo { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public string? NoiDung { get; set; }
    }
}
