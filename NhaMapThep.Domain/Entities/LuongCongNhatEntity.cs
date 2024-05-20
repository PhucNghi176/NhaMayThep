using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("LuongCongNhat")]
    public class LuongCongNhatEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }
        public double SoGioLam { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Luong1Gio { get; set; }
        public DateTime NgayKhaiBao { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal TongLuong { get; set; }
    }
}
