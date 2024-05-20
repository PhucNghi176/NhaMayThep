using NhaMapThep.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities
{
    [Table("ThongTinCongTy")]
    public class ThongTinCongTyEntity : Entity
    {
        public int MaDoanhNghiep { get; set; }
        public string TenQuocTe { get; set; }
        public string TenVietTat { get; set; }
        public int SoLuongNhanVien { get; set; }
        public string DiaChi { get; set; }
        public int MaSoThue { get; set; }
        [MaxLength(12)]
        public string DienThoai { get; set; }
        public string NguoiDaiDien { get; set; }
        public DateTime NgayHoatDong { get; set; }
        public string DonViQuanLi { get; set; }
        public string LoaiHinhDoanhNghiep { get; set; }
        public string TinhTrang { get; set; }
    }
}
