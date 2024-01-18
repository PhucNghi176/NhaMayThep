using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.ThongTinCongTy
{
    public class ThongTinCongTyDto:IMapFrom<ThongTinCongTyEntity>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TenQuocTe {  get; set; }
        public string TenVietTat { get; set; }
        public int SoLuongNhanVien { get; set; }
        public string DiaChi { get; set; }
        public int MaSoThue { get; set; }
        public string DienThoai { get; set; }
        public string NguoiDaiDien { get; set; }
        public DateTime NgayHoatDong { get; set; }
        public string DonViQuanLi { get; set; }
        public string LoaiHinhDoanhNghiep { get; set; }
        public string TinhTrang { get; set; }
        public static ThongTinCongTyDto Create(int id, string name, string tenQuocTe, string tenVietTat, int soLuongNhanVien, string diaChi, int maSoThue, string dienThoai, string nguoiDaiDien, DateTime ngayHoatDong, string donViQuanLi, string loaiHinhDoanhNghiep, string tinhTrang)
        {
            return new ThongTinCongTyDto
            {
                Id = id,
                Name = name,
                TenQuocTe = tenQuocTe,
                TenVietTat = tenVietTat,
                SoLuongNhanVien = soLuongNhanVien,
                DiaChi = diaChi,
                MaSoThue = maSoThue,
                DienThoai = dienThoai,
                NguoiDaiDien = nguoiDaiDien,
                NgayHoatDong = ngayHoatDong,
                DonViQuanLi = donViQuanLi,
                LoaiHinhDoanhNghiep = loaiHinhDoanhNghiep,
                TinhTrang = tinhTrang,
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ThongTinCongTyEntity, ThongTinCongTyDto>();
        }
    }
}