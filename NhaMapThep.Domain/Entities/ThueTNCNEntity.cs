using NhaMapThep.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities
{
    [Table("ThueTNCN")]
    public class ThueTNCNEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal LuongCoBan { get; set; }
        //public required string PhuCapNhanVienID { get; set; }
        //[ForeignKey(nameof(PhuCapNhanVienID))]
        //public virtual PhuCapNhanVienEntity PhuCapNhanVien { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TongThuNhap {  get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal ThuNhapChiuThue { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal ThuNhapTinhThue { get; set; }

        //public required string BaoHiemNhanVienID { get; set; }
        //[ForeignKey(nameof(BaoHiemNhanVienID))]
        //public virtual BaoHiemNhanVienEntity BaoHiemNhanVien { get; set; }

        public required string GiamTruNhanVienID { get; set; }
        [ForeignKey(nameof(GiamTruNhanVienID))]
        public virtual GiamTruNhanVienEntity GiamTruNhanVien { get; set; }

        //public required string ThueSuatID { get; set; }
        //[ForeignKey(nameof(ThueSuatID))]
        //public virtual ThueSuatEntity ThueSuat { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal ThueTNCNPhaiNop {  get; set; }
    }
}
