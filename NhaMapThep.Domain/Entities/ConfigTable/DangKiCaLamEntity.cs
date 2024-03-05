using NhaMapThep.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities.ConfigTable
{
    public class DangKiCaLamEntity : Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaCaLamViec { get; set; }

        [Required]
        [ForeignKey(nameof(NhanVien))]
        public string MaSoNhanVien { get; set; }
        public virtual NhanVienEntity NhanVien { get; set; }
        [Required]
        public DateTime NgayDangKi { get; set; }

        [Required]
        [ForeignKey(nameof(MaDangKiCaLam))]
        public int CaDangKi { get; set; }
        public virtual MaDangKiCaLamEntity MaDangKiCaLam { get; set; }

        public DateTime ThoiGianCaLamBatDau { get; set; }
        public DateTime ThoiGianCaLamKetThuc { get; set; }

        public DateTime? ThoiGianChamCongBatDau { get; set; }
        public DateTime? ThoiGianChamCongKetThuc { get; set; }

        [Required]
        public int HeSoNgayCong { get; set; }

        [ForeignKey(nameof(MaSoNguoiQuanLy))]
        public string MaSoNguoiQuanLy { get; set; }
        public virtual NhanVienEntity NguoiQuanLy { get; set; }

        [Required]
        [ForeignKey(nameof(TrangThaiDangKiCaLamViec))]
        public int TrangThai { get; set; }
        public virtual TrangThaiDangKiCaLamViecEntity TrangThaiDangKiCaLamViec { get; set; }

        public string GhiChu { get; set; }
    }
}
