using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Update
{
    public class UpdateThongTinLuongNhanVienCommand : IRequest<ThongTinLuongNhanVienDto>
    {
        public UpdateThongTinLuongNhanVienCommand() { }

        public UpdateThongTinLuongNhanVienCommand(string Id, string MaSoNhanVien, string MaSoHopDong, string Loai, decimal LuongCu, decimal LuongMoi, DateTime NgayHieuLuc)
        {
            this.Id = Id;
            this.MaSoNhanVien = MaSoNhanVien;
            this.MaSoHopDong = MaSoHopDong;
            this.Loai = Loai;
            this.LuongCu = LuongCu;
            this.LuongMoi = LuongMoi;
            this.NgayHieuLuc = NgayHieuLuc;
        }
        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public string MaSoHopDong { get; set; }
        public string Loai { get; set; }
        public decimal LuongCu { get; set; }
        public decimal LuongMoi { get; set; }
        public DateTime NgayHieuLuc { get; set; }
    }
}
