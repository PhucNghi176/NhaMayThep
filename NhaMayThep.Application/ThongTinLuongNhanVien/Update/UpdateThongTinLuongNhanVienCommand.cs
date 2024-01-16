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
        public UpdateThongTinLuongNhanVienCommand(Guid Id, Guid MaSoNhanVien, Guid MaSoHopDong, string Loai, decimal LuongCu, decimal LuongHienTai, DateTime NgayHieuLuc)
        {
            this.Id = Id.ToString();
            this.MaSoNhanVien = MaSoNhanVien.ToString();
            this.MaSoHopDong = MaSoHopDong.ToString();
            this.Loai = Loai;
            this.LuongCu = LuongCu;
            this.LuongHienTai = LuongHienTai;
            this.NgayHieuLuc = NgayHieuLuc;
        }
        public string Id { get; set; }
        public string MaSoNhanVien { get; set; }
        public string MaSoHopDong { get; set; }
        public string Loai { get; set; }
        public decimal LuongCu { get; set; }
        public decimal LuongHienTai { get; set; }
        public DateTime NgayHieuLuc { get; set; }
    }
}
