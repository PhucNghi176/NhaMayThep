using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Entities.ConfigTable;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("HoaDonCongTacNhanVien")]
    public class HoaDonCongTacNhanVienEntity : Entity
    {
        public required string LichSuCongTacID { get; set; }
        [ForeignKey(nameof(LichSuCongTacID))]
        public virtual LichSuCongTacNhanVienEntity LichSuCongTacNhanVien { get; set; }
        public required int LoaiHoaDonID { get; set; }
        [ForeignKey(nameof(LoaiHoaDonID))]
        public virtual LoaiHoaDonEntity LoaiHoaDon { get; set; }
        public required string DuongDanFile { get; set; }

    }
}
