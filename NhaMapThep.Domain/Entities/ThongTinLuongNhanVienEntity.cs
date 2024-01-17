using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("ThongTinLuongNhanVien")]
    public class ThongTinLuongNhanVienEntity : Entity
    {
        public string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }
        public string MaSoHopDong { get; set; }
        [ForeignKey(nameof(MaSoHopDong))]
        public virtual HopDongEntity HopDong { get; set; }
        public required string Loai { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public required decimal LuongCu { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public required decimal LuongMoi { get; set; }
        public required DateTime NgayHieuLuc { get; set; }
    }
}
