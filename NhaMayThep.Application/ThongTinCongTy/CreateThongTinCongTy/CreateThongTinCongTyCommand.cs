using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongTy.CreateThongTinCongTy
{
    public class CreateThongTinCongTyCommand : IRequest<string>, ICommand
    {
        public CreateThongTinCongTyCommand(
            int maDoanhNghiep,
            string tenQuocTe,
            string tenVietTat,
            int soLuongNhanVien,
            string diaChi,
            int maSoThue,
            string dienThoai,
            string nguoiDaiDien,
            DateTime ngayHoatDong,
            string donViQuanLi,
            string loaiHinhDoanhNghiep,
            string tinhTrang)
        {
            MaDoanhNghiep = maDoanhNghiep;
            TenQuocTe = tenQuocTe;
            TenVietTat = tenVietTat;
            SoLuongNhanVien = soLuongNhanVien;
            DiaChi = diaChi;
            MaSoThue = maSoThue;
            DienThoai = dienThoai;
            NguoiDaiDien = nguoiDaiDien;
            NgayHoatDong = ngayHoatDong;
            DonViQuanLi = donViQuanLi;
            LoaiHinhDoanhNghiep = loaiHinhDoanhNghiep;
            TinhTrang = tinhTrang;
        }
        public int MaDoanhNghiep { get; set; }
        public string TenQuocTe { get; set; }
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
    }
}