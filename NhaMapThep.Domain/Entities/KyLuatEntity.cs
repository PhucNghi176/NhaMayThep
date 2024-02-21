using NhaMapThep.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities
{
    [Table("KyLuat")]
    public class KyLuatEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }

        public required int ChinhSachNhanSuID { get; set; }
        [ForeignKey(nameof(ChinhSachNhanSuID))]
        public virtual ChinhSachNhanSuEntity  ChinhSachNhanSu { get; set; }
        public string TenDotKyLuat { get; set; }
        public DateTime NgayKiLuat { get; set; }
        public decimal TongPhat { get; set; }
    }
}
