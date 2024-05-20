using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("PhiCongDoan")]
    public class PhiCongDoanEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }
        public double PhanTramLuongDongBH { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal LuongDongBH { get; set; }
    }
}
