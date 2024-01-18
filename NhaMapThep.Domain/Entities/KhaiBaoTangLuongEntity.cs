using NhaMapThep.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities
{
    [Table("KhaiBaoTangLuong")]
    public class KhaiBaoTangLuongEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal PhanTramTang { get; set; }
        public DateTime NgayApDung { get; set; }
        public string LyDo {  get; set; }
    }
}
