using NhaMapThep.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities.ConfigTable
{
    [Table("ThueSuat")]
    public class ThueSuatEntity : BangMaGocEntity
    {
        public required int BacThue {  get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public required decimal ThuNhapTinhThueTrenNam {  get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public required decimal ThuNhapTinhThueTrenThang {  get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public required decimal PhanTramThueSuat { get; set; }
    }
}
