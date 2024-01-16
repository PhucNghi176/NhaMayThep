using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NhaMapThep.Domain.Entities.Base;

namespace NhaMapThep.Domain.Entities
{
    [Table("ChiTietNgayNghiPhep")]
    public class ChiTietNgayNghiPhepEntity : Entity
    {
      
        [ForeignKey("NhanVien")]
        public string MaSoNhanVien { get; set; }

        public int LoaiNghiPhep { get; set; }
        public int TongSoGio { get; set; }
        public int SoGioDaNghiPhep { get; set; }
        public int SoGioConLai { get; set; }
        public int NamHieuLuoc { get; set; }

        // Navigation property
        public virtual NhanVienEntity NhanVien { get; set; }
    }
}
