using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NghiPhep.Update
{
    public class UpdateNghiPhepCommand : IRequest<string>, ICommand
    {
        public UpdateNghiPhepCommand(string id, string maSoNhanVien, decimal luongNghiPhep, decimal khoanTruLuong, double soGioNghiPhep, int loaiNghiPhepID)
        {
            ID = id;
            MaSoNhanVien = maSoNhanVien;
            LuongNghiPhep = luongNghiPhep;
            KhoanTruLuong = khoanTruLuong;
            SoGioNghiPhep = soGioNghiPhep;
            LoaiNghiPhepID = loaiNghiPhepID;
        }

        public string ID { get; set; }
        public required string MaSoNhanVien { get; set; }
        public decimal LuongNghiPhep { get; set; }
        public decimal KhoanTruLuong { get; set; }
        public double SoGioNghiPhep { get; set; }
        public required int LoaiNghiPhepID { get; set; }
    }
}
