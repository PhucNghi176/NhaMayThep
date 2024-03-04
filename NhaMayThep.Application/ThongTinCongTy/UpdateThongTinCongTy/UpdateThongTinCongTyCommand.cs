using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongTy.UpdateThongTinCongTy
{
    public class UpdateThongTinCongTyCommand : IRequest<string>, ICommand
    {
        public UpdateThongTinCongTyCommand(
            string id,
            int maDoanhNghiep,
            string tenQuocTe,
            string tenVietTat,
            int soLuongNhanVien,
            string diaChi,
            int maSoThue,
            string dienThoai,
            string nguoiDaiDien,
            string donViQuanLi,
            string loaiHinhDoanhNghiep,
            string tinhTrang,
            DateTime ngayHoatDong)
        {
            ID = id;
            MaDoanhNghiep = maDoanhNghiep;
            TenQuocTe = tenQuocTe;
            TenVietTat = tenVietTat;
            SoLuongNhanVien = soLuongNhanVien;
            DiaChi = diaChi;
            MaSoThue = maSoThue;
            DienThoai = dienThoai;
            NguoiDaiDien = nguoiDaiDien;
            DonViQuanLi = donViQuanLi;
            LoaiHinhDoanhNghiep = loaiHinhDoanhNghiep;
            TinhTrang = tinhTrang;
            NgayHoatDong = ngayHoatDong;
        }
        public string ID { get; set; }
        public int MaDoanhNghiep { get; set; }
        public string TenQuocTe { get; set; }
        public string TenVietTat { get; set; }
        public int SoLuongNhanVien { get; set; }
        public string DiaChi { get; set; }
        public int MaSoThue { get; set; }
        public string DienThoai { get; set; }
        public string NguoiDaiDien { get; set; }
        public string DonViQuanLi { get; set; }
        public string LoaiHinhDoanhNghiep { get; set; }
        public string TinhTrang { get; set; }
        public DateTime NgayHoatDong {  get; set; }
    }
}
