using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("PhuCapCongDoan")]
    public class PhuCapCongDoanEntity : Entity
    {
        public int SoLuongDoanVien { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public float HeSoPhuCap { get; set; }
        public string DonVi { get; set; }

    }
}
