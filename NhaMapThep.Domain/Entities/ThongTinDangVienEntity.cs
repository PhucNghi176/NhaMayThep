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
        public required string ChucVuDang { get; set; }
        public required string TrinhDoChinhTri { get; set; }
        public DateTime NgayVaoDang { get; set; }
        public string CapDangVien { get; set; }
    }
}
