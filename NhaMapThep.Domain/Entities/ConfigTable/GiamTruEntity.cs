using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities.ConfigTable
{
    [Table("GiamTru")]
    public class GiamTruEntity : BangMaGocEntity
    {
        [Column(TypeName = "decimal(18, 4)")]
        public required decimal SoTienGiam { get; set; }
    }
}
