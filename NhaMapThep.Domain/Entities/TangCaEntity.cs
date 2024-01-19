using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities
{
    [Table("TangCa")]
    public class TangCaEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }
        public double SoGioLamThem { get; set; }
        public int SoSanPhamLamThem { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal LuongSanPham {  get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal LuongCongNhat {  get; set; }
        public required string LoaiTangCaID { get; set; }
        [ForeignKey(nameof(LoaiTangCaID))]
        public virtual LoaiTangCaEntity LoaiTangCa { get; set; }
    }
}
