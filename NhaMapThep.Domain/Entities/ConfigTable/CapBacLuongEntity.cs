using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities.ConfigTable
{
    [Table("CapBacLuong")]
    public class CapBacLuongEntity : BangMaGocEntity
    {
        public required float HeSoLuong { get; set; }
        public required string TrinhDo { get; set; }
    }
}
