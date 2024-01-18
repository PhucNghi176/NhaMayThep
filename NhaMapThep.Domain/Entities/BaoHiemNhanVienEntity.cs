using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Entities.ConfigTable;
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
        public virtual NhanVienEntity NhanVien { get; set; }
        [ForeignKey(nameof(BaoHiem))]
        public required int BaoHiem {  get; set; }
        public virtual ICollection<BaoHiemEntity> BaoHiems { get; set; }
    }
}
