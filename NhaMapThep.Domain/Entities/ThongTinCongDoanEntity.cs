using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMayThep.Infrastructure.Persistence
{
    [Table("ThongTinCongDoan")]
    public class ThongTinCongDoanEntity : Entity
    {
        public string NhanVienID { get; set; }
        [ForeignKey(nameof(NhanVienID))]
        public virtual required NhanVienEntity NhanVien { get; set; }
        public bool ThuKiCongDoan { get; set; }
        public DateTime NgayGiaNhap { get; set; }
    }
}
