using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("LuongSanPham")]
    public class LuongSanPhamEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }

        public int SoSanPhamLam { get; set; }
        public required string MucSanPhamID { get; set; }
        [ForeignKey(nameof(MucSanPhamID))]
        public virtual MucSanPhamEntity MucSanPham { get; set; }
        public DateTime NgayKhaiBao { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal TongLuong { get; set; }
    }
}
