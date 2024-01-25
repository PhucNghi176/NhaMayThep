using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("ThongTinDangVien")]
    public class ThongTinDangVienEntity : Entity
    {
        public string NhanVienID { get; set; }
        [ForeignKey(nameof(NhanVienID))]
        public virtual NhanVienEntity NhanVien { get; set; }
        public DateTime NgayVaoDang { get; set; }
        public string CapDangVien { get; set; }
    }
}
