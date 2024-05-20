using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Entities.ConfigTable;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("GiamTruNhanVien")]
    public class GiamTruNhanVienEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }
        public required int GiamTruID { get; set; }
        [ForeignKey(nameof(GiamTruID))]
        public virtual GiamTruEntity GiamTru { get; set; }
    }
}
