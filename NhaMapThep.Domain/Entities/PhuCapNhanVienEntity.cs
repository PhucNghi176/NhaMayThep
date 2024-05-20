using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Entities.ConfigTable;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("PhuCapNhanVien")]
    public class PhuCapNhanVienEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }



        public required int PhuCap { get; set; }
        [ForeignKey(nameof(PhuCap))]
        public virtual ICollection<PhuCapEntity> PhuCaps { get; set; }
    }
}
