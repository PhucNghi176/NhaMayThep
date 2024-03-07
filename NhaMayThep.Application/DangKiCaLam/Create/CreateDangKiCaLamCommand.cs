using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;

namespace NhaMayThep.Application.DangKiCaLam.Create
{
    public class CreateDangKiCaLamCommand : IRequest<string>,ICommand
    {
        public string MaSoNhanVien { get; set; }
        public DateTime NgayDangKi { get; set; }
        public int CaDangKi { get; set; }
        public DateTime ThoiGianCaLamBatDau { get; set; }
        public DateTime ThoiGianCaLamKetThuc { get; set; }
        public DateTime? ThoiGianChamCongBatDau { get; set; }
        public DateTime? ThoiGianChamCongKetThuc { get; set; }
        public int HeSoNgayCong { get; set; }
        public string MaSoNguoiQuanLy { get; set; }
        public int TrangThai { get; set; }
        public string GhiChu { get; set; }
    }
}
