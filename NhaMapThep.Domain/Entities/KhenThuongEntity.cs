using NhaMapThep.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities
{
    public class KhenThuongEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }
        public required string HinhThucKhenThuong { get; set; }
        public required string LoaiKhenThuong { get; set; }
        public required string TenDotKhenThuong { get; set; }
        public DateTime NgayKhenThuong { get; set; }
        public double TongGiaTri { get; set; }
        public required string DonViApDung { get; set; }
    }
}
