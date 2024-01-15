using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NhaMayThep.Application.ThongTinLuongNhanVien.Create
{
    public class CreateThongTinLuongNhanVienCommand : IRequest<ThongTinLuongNhanVienDto>, ICommand
    {
        public CreateThongTinLuongNhanVienCommand(Guid MaSoNhanVien, Guid MaSoHopDong, string Loai, decimal LuongCu, decimal LuongHienTai, DateTime NgayHieuLuc)
        {
            this.MaSoNhanVien = MaSoNhanVien.ToString();
            this.MaSoHopDong = MaSoHopDong.ToString();
            this.Loai = Loai;
            this.LuongCu = LuongCu;
            this.LuongHienTai = LuongHienTai;
            this.NgayHieuLuc = NgayHieuLuc;
        }
        public string MaSoNhanVien { get; set; }
        public string MaSoHopDong { get; set; }
        public string Loai { get; set; }
        public decimal LuongCu { get; set; }
        public decimal LuongHienTai { get; set; }
        public DateTime NgayHieuLuc { get; set; }
    }
}
