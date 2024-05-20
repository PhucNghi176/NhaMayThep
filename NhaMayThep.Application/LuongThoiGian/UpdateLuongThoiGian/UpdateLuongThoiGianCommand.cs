using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LuongThoiGian.UpdateLuongThoiGian
{
    public class UpdateLuongThoiGianCommand : IRequest<string>, ICommand
    {
        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public int MaLuongThoiGian { get; set; }
        public decimal LuongNam { get; set; }
        public decimal LuongThang { get; set; }
        public decimal LuongTuan { get; set; }
        public decimal LuongNgay { get; set; }
        public decimal LuongGio { get; set; }
        public DateTime NgayApDung { get; set; }
        public UpdateLuongThoiGianCommand(
            string id,
            string maSoNhanVien,
            int maLuongThoiGian,
            decimal luongNam,
            decimal luongThang,
            decimal luongTuan,
            decimal luongNgay,
            decimal luongGio,
            DateTime ngayApDung)
        {
            Id = id;
            MaSoNhanVien = maSoNhanVien;
            MaLuongThoiGian = maLuongThoiGian;
            LuongNam = luongNam;
            LuongThang = luongThang;
            LuongTuan = luongTuan;
            LuongNgay = luongNgay;
            LuongGio = luongGio;
            NgayApDung = ngayApDung;
        }
    }
}
