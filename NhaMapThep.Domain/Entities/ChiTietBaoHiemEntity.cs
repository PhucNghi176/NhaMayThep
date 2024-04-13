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
    [Table("ChiTietBaoHiem")]
    public class ChiTietBaoHiemEntity : Entity
    {
        public required string MaSoNhanVien {  get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public required virtual NhanVienEntity NhanVien { get; set; }
        public int LoaiBaoHiem { get; set; }
        [ForeignKey(nameof(LoaiBaoHiem))]
        public required virtual BaoHiemEntity BaoHiem { get; set; }
        public DateTime NgayHieuLuc {  get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string NoiCap { get; set; }
    }
}
