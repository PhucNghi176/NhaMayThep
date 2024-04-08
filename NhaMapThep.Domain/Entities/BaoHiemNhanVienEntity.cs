using NhaMapThep.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities
{
    [Table("BaoHiemNhanVien")]
    public class BaoHiemNhanVienEntity : BangMaGocEntity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; } = null!;
        public virtual ICollection<BaoHiemNhanVienBaoHiemChiTietEntity>? BaoHiemNhanViens { get; set; }
    }
}
