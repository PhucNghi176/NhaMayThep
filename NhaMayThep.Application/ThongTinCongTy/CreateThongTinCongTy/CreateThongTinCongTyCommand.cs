using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongTy.CreateThongTinCongTy
{
    public class CreateThongTinCongTyCommand : IRequest<string>, ICommand
    {
        public string Name { get; set; }
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