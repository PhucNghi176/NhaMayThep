using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Entities.ConfigTable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("NhanVien")]
    public class NhanVienEntity : Entity
    {

        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string HoVaTen { get; set; }
        public required int ChucVuID { get; set; }
        [ForeignKey(nameof(ChucVuID))]
        public virtual ThongTinChucVuEntity ChucVu { get; set; }
        public required int TinhTrangLamViecID { get; set; }
        [ForeignKey(nameof(TinhTrangLamViecID))]
        public virtual TinhTrangLamViecEntity TinhTrangLamViec { get; set; }
        public required DateTime NgayVaoCongTy { get; set; }
        public required string DiaChiLienLac { get; set; }
        [MaxLength(11)]
        public required string SoDienThoaiLienLac { get; set; }
        public required string MaSoThue { get; set; }
        public required string TenNganHang { get; set; }
        public required string SoTaiKhoan { get; set; }
        public int? SoNguoiPhuThuoc { get; set; }
        public required bool DaCoHopDong { get; set; } = false;
        public virtual ICollection<HopDongEntity> HopDongs { get; set; }

        public virtual ICollection<ThongTinLuongNhanVienEntity> ThongTinLuongNhanViens { get; set; }

        public virtual ICollection<CanCuocCongDanEntity> CanCuocCongDans { get; set; }

    }
}
