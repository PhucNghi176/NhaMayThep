using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Entities.ConfigTable;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    public class LichSuCongTacNhanVienEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }
        public required int LoaiCongTacID { get; set; }
        [ForeignKey(nameof(LoaiCongTacID))]
        public virtual LoaiCongTacEntity LoaiCongTac { get; set; }
        public required DateTime NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public required string NoiCongTac { get; set; }
        public required string LyDo { get; set; }
    }
}
