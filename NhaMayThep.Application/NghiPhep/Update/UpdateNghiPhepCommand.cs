using MediatR;
using System;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NghiPhep.Update
{
    public class UpdateNghiPhepCommand : IRequest<string>, ICommand
    {
        public UpdateNghiPhepCommand(string id, decimal luongNghiPhep, decimal khoanTruLuong, double soGioNghiPhep, int loaiNghiPhepId)
        {
            Id = id;
            LuongNghiPhep = luongNghiPhep;
            KhoanTruLuong = khoanTruLuong;
            SoGioNghiPhep = soGioNghiPhep;
            LoaiNghiPhepId = loaiNghiPhepId;
        }

        public string Id { get; set; }
        public decimal LuongNghiPhep { get; set; }
        public decimal KhoanTruLuong { get; set; }
        public double SoGioNghiPhep { get; set; }
        public int LoaiNghiPhepId { get; set; }
    }
}
