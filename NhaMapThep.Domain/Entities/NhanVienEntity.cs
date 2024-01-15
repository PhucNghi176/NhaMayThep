using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Entities.ConfigTable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("NhanVien")]
    public class NhanVienEntity : Entity
    {
        public NhanVienEntity()
        {
            NgayVaoCongTy = DateTime.Now;
        }
        public required string Email { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
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
        public virtual ICollection<HopDongEntity> HopDongs { get; set; }

    }
}
