using MediatR;
using System;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NghiPhep.Create
{
    public class CreateNghiPhepCommand : IRequest<string>, ICommand
    {
        public CreateNghiPhepCommand(string maSoNhanVien, decimal luongNghiPhep, decimal khoanTruLuong, double soGioNghiPhep, int loaiNghiPhepId)
        {
            MaSoNhanVien = maSoNhanVien;
            LuongNghiPhep = luongNghiPhep;
            KhoanTruLuong = khoanTruLuong;
            SoGioNghiPhep = soGioNghiPhep;
            LoaiNghiPhepId = loaiNghiPhepId;
        }

        public string MaSoNhanVien { get; set; }
        public decimal LuongNghiPhep { get; set; }
        public decimal KhoanTruLuong { get; set; }
        public double SoGioNghiPhep { get; set; }
        public int LoaiNghiPhepId { get; set; }
    }
}
