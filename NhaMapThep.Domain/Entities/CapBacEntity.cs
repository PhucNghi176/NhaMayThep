using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("CapBac")]
    public class CapBacEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }

        public string TenCapBac { get; set; }

        public double HeSoLuong { get; set; }
        public string TrinhDo { get; set; }

    }
}
