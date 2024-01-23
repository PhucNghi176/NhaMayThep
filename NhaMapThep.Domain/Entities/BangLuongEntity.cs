using NhaMapThep.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities
{
    [Table("BangLuong")]
    public class BangLuongEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }

        public DateTime NgayKhaiBao { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal LuongNghiPhep { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal LuongTangCa {  get; set; }
        public decimal TongKhenThuong {  get; set; }
        public decimal TongKiLuat {  get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal LuongCoBan {  get; set; }
        //public required string PhuCapNhanVienID { get; set; }
        //[ForeignKey(nameof(PhuCapNhanVienID))]
        //public virtual PhuCapNhanVienEntity PhuCapNhanVien { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TongNhanCoDinh { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal NgayCong {  get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal TongThuNhap { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal LuongDongBH { get; set; }

        //public required string BaoHiemNhanVienID { get; set; }
        //[ForeignKey(nameof(BaoHiemNhanVienID))]
        //public virtual BaoHiemNhanVienEntity BaoHiemNhanVien { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TongBaoHiem { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal PhiCongDoan { get; set; }

        public required string GiamTruNhanVienID { get; set; }
        [ForeignKey(nameof(GiamTruNhanVienID))]
        public virtual GiamTruNhanVienEntity GiamTruNhanVien { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TamUng {  get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal LuongThucLanh { get; set; }
    }
}
