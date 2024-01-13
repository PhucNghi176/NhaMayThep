using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities.ConfigTable
{
    [Table("ThongTinGiamTru")]
    public class ThongTinGiamTruEntity : BangMaGocEntity
    {
        [Column(TypeName = "decimal(18, 4)")]
        public required decimal SoTienGiamTru { get; set; }
    }
}
