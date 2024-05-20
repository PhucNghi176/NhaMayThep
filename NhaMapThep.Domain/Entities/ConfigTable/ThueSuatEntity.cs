using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities.ConfigTable
{
    [Table("ThueSuat")]
    public class ThueSuatEntity : BangMaGocEntity
    {
        public required int BacThue { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public required decimal DauThuNhapTinhThueTrenNam { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public required decimal CuoiThuNhapTinhThueTrenNam { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public required decimal DauThuNhapTinhThueTrenThang { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public required decimal CuoiThuNhapTinhThueTrenThang { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public required double PhanTramThueSuat { get; set; }
    }
}
