using NhaMapThep.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities
{
    public class KyLuatEntity : Entity
    {
        public required string MaSoNhanVien {  get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }
        public required string HinhThucKyLuat { get; set; }
        public required string LoaiKyLuat { get; set; }
        public required string TenDotKyLuat { get; set; }
        public DateTime NgayKyLuat { get; set; }
        public double TongPhat { get; set; }
        public required string DonViApDung { get; set; }
    }
}
