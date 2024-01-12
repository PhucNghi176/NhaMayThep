using NhaMapThep.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities
{
    [Table("ChiTietNhanVien")]
    public class ChiTietNhanVienEntity : Auditable
    {
        [Column("MaSoNhanVien")]
        public Guid ID { get; set; }
        public required DateTime NgayVaoCongTy { get; set; }
        public required string DiaChiLienLac { get; set; }
        public required string SoDienThoaiLienLac { get; set; }
        public required string MaSoThue { get; set; }
        public required string TenNganHang { get; set; }
        public required string SoTaiKhoan { get; set; }
        public int? SoNguoiPhuThuoc { get; set; }
        public required string CanCuocCongDan { get; set; }
        
    }
}
