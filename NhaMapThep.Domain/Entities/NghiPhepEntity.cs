using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Entities.ConfigTable;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("NghiPhep")]
    public class NghiPhepEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal LuongNghiPhep { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal KhoanTruLuong { get; set; }
        public double SoGioNghiPhep { get; set; }
        public required int LoaiNghiPhepID { get; set; }
        [ForeignKey(nameof(LoaiNghiPhepID))]
        public virtual LoaiNghiPhepEntity LoaiNghiPhep { get; set; }
    }
}
