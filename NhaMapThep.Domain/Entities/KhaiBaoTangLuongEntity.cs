using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("KhaiBaoTangLuong")]
    public class KhaiBaoTangLuongEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }

        public float PhanTramTang { get; set; }
        public DateTime NgayApDung { get; set; }
        public string LyDo { get; set; }
    }
}
