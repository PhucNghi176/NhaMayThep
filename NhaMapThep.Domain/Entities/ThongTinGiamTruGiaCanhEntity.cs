using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Entities.Mapping;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("ThongTinGiamTruGiaCanh")]
    public class ThongTinGiamTruGiaCanhEntity : Entity
    {
        public required string NhanVienID { get; set; }
        [ForeignKey(nameof(NhanVienID))]
        public required virtual NhanVienEntity NhanVien { get; set; }
        public required int MaGiamTruID { get; set; }
        [ForeignKey(nameof(MaGiamTruID))]
        public required virtual ThongTinGiamTruEntity ThongTinGiamTru { get; set; }
        public required string DiaChiLienLac { get; set; }
        [MaxLength(20)]
        public required string QuanHeVoiNhanVien { get; set; }

        [MaxLength(12)]
        public required string CanCuocCongDan { get; set; }
        [ForeignKey(nameof(CanCuocCongDan))]
        public virtual CanCuocCongDanEntity SoCanCuoc { get; set; }
        public required DateTime NgayXacNhanPhuThuoc { get; set; }

        public virtual NhanVienMapThongTinCanCuocCongDan NhanVienMapThongTinCanCuocCongDan { get; set; }


    }
}
