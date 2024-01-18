using System.ComponentModel.DataAnnotations.Schema;
using NhaMapThep.Domain.Entities.Base;

namespace NhaMapThep.Domain.Entities
{
    [Table("ThongTinCongty")]
    public class ThongTinCongTyEntity : BangMaGocEntity
    {
        public required string TenQuocTe {get; set;}
        public required string TenVietTat { get; set; }
        public required int SoLuongNhanVien { get; set; }
        public required string DiaChi { get; set; }
        public required int MaSoThue { get; set; }
        public required string DienThoai { get; set; }
        public required string NguoiDaiDien { get; set; }
        public required DateTime NgayHoatDong { get; set; }
        public required string DonViQuanLi { get; set; }
        public required string LoaiHinhDoanhNghiep { get; set; }
        public required string TinhTrang { get; set; }
    }
}