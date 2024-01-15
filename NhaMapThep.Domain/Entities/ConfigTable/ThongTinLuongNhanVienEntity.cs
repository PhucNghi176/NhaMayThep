using NhaMapThep.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities.ConfigTable
{
    [Table("ThongTinLuongNhanVien")]
    public class ThongTinLuongNhanVienEntity : EntityWithoutID
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }
        public required string MaSoHopDong { get; set; }
        [ForeignKey(nameof(MaSoHopDong))]
        public virtual HopDongEntity HopDong { get; set; }
        public string Loai {  get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal LuongCu {  get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal LuongHienTai { get; set; }
        public DateTime NgayHieuLuc { get; set; }
    }
}
