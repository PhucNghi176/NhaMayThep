using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Create
{
    public class CreateThongTinLuongNhanVienCommand : IRequest<string>, ICommand
    {
        public CreateThongTinLuongNhanVienCommand(string MaSoNhanVien, string MaSoHopDong, string Loai, decimal LuongCu, decimal LuongMoi, DateTime NgayHieuLuc)
        {
            this.MaSoNhanVien = MaSoNhanVien.ToString();
            this.MaSoHopDong = MaSoHopDong.ToString();
            this.Loai = Loai;
            this.LuongCu = LuongCu;
            this.LuongMoi = LuongMoi;
            this.NgayHieuLuc = NgayHieuLuc;
        }
        public string MaSoNhanVien { get; set; }
        public string MaSoHopDong { get; set; }
        public string Loai { get; set; }
        public decimal LuongCu { get; set; }
        public decimal LuongMoi { get; set; }
        public DateTime NgayHieuLuc { get; set; }
    }
}
