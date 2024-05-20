using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Update
{
    public class UpdateThongTinLuongNhanVienCommand : IRequest<string>, ICommand
    {
        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public string MaSoHopDong { get; set; }
        public string Loai { get; set; }
        public decimal LuongCu { get; set; }
        public decimal LuongMoi { get; set; }
        public DateTime NgayHieuLuc { get; set; }

        public UpdateThongTinLuongNhanVienCommand(string id, string maSoNhanVien, string maSoHopDong, string loai, decimal luongCu, decimal luongMoi, DateTime ngayHieuLuc)
        {
            Id = id;
            MaSoNhanVien = maSoNhanVien;
            MaSoHopDong = maSoHopDong;
            Loai = loai;
            LuongCu = luongCu;
            LuongMoi = luongMoi;
            NgayHieuLuc = ngayHieuLuc;
        }
    }
}
