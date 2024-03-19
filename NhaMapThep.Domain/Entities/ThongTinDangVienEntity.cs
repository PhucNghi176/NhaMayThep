using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Entities.ConfigTable;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("ThongTinDangVien")]
    public class ThongTinDangVienEntity : Entity
    {
        public string NhanVienID { get; set; }
        [ForeignKey(nameof(NhanVienID))]
        public virtual NhanVienEntity NhanVien { get; set; }
        public int DonViCongTacID { get; set; }
        [ForeignKey(nameof(DonViCongTacID))]
        public virtual DonViCongTacEntity DonViCongTac { get; set; }
        public required int ChucVuDang { get; set; }
        [ForeignKey(nameof(ChucVuDang))]
        public virtual ThongTinChucVuDangEntity ThongTinChucVuDang { get; set; }
        public required int TrinhDoChinhTri { get; set; }
        [ForeignKey(nameof(TrinhDoChinhTri))]
        public virtual ThongTinTrinhDoChinhTriEntity ThongTinTrinhDoChinhTri { get; set; }
        public DateTime NgayVaoDang { get; set; }
        public int CapDangVien { get; set; }
        [ForeignKey(nameof(CapDangVien))]
        public virtual ThongTinCapDangVienEntity ThongTinCapDangVien { get; set; }
    }
}
