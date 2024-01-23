using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Entities.ConfigTable;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("HopDong")]
    public class HopDongEntity : Entity
    {
        public required string NhanVienID { get; set; }
        [ForeignKey(nameof(NhanVienID))]
        public virtual required NhanVienEntity NhanVien { get; set; }
        public required int LoaiHopDongID { get; set; }
        [ForeignKey(nameof(LoaiHopDongID))]
        public virtual required LoaiHopDongEntity LoaiHopDong { get; set; }
        public required DateTime NgayKy { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int? ThoiHanHopDong { get; set; }
        public required string DiaDiemLamViec { get; set; }
        public required string BoPhanLamViec { get; set; }

        public required int ChucVuID { get; set; }
        [ForeignKey(nameof(ChucVuID))]
        public virtual required ThongTinChucVuEntity ChucVu { get; set; }


        public required int ChucDanhID { get; set; }
        [ForeignKey(nameof(ChucDanhID))]
        public virtual required ThongTinChucDanhEntity ChucDanh { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public required decimal LuongCoBan { get; set; }
        public required int HeSoLuongID { get; set; }
        [ForeignKey(nameof(HeSoLuongID))]
        public virtual required CapBacLuongEntity CapBacLuong { get; set; }
        public required string PhuCapID { get; set; }
        public string? GhiChu { get; set; }




    }
}
