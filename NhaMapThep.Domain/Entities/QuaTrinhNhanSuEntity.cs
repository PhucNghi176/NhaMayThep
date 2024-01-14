using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Entities.ConfigTable;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("QuaTrinhNhanSu")]
    public class QuaTrinhNhanSuEntity : Entity
    {
        public required string MaSoNhanVien { get; set; }
        [ForeignKey(nameof(MaSoNhanVien))]
        public virtual NhanVienEntity NhanVien { get; set; }
        public required int LoaiQuaTrinhID { get; set; }
        [ForeignKey(nameof(LoaiQuaTrinhID))]
        public virtual ThongTinQuaTrinhNhanSuEntity LoaiQuaTrinh { get; set; }
        public required DateTime NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int PhongBanID { get; set; }
        [ForeignKey(nameof(PhongBanID))]
        public virtual PhongBanEntity PhongBan { get; set; }
        public int ChucVuID { get; set; }
        [ForeignKey(nameof(ChucVuID))]
        public virtual ThongTinChucVuEntity ChucVu { get; set; }
        public int ChucDanhID { get; set; }
        [ForeignKey(nameof(ChucDanhID))]
        public virtual ThongTinChucDanhEntity ChucDanh { get; set; }
        public string? GhiChu { get; set; }



    }
}
