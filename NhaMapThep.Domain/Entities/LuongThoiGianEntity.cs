using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("LuongThoiGian")]
    public class LuongThoiGianEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]

        public virtual NhanVienEntity NhanVien { get; set; }

        public int MaLuongThoiGian { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal LuongNam { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal LuongThang { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal LuongTuan { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal LuongNgay { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal LuongGio { get; set; }

        public DateTime NgayApDung { get; set; }

    }
}
