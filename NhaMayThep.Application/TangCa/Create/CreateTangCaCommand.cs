using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TangCa.Create
{
    public class CreateTangCaCommand : IRequest<string>, ICommand
    {
        public CreateTangCaCommand(string maSoNhanVien, double soGioLamThem, int soSanPhamLamThem, decimal luongSanPham, decimal luongCongNhat, int loaiTangCaId)
        {

            MaSoNhanVien = maSoNhanVien;
            SoGioLamThem = soGioLamThem;
            SoSanPhamLamThem = soSanPhamLamThem;
            LuongCongNhat = luongCongNhat;
            LuongSanPham = luongSanPham;
            LoaiTangCaID = loaiTangCaId;
        }


        public string MaSoNhanVien { get; set; }
        public double SoGioLamThem { get; set; }
        public int SoSanPhamLamThem { get; set; }
        public decimal LuongSanPham { get; set; }
        public decimal LuongCongNhat { get; set; }
        public int LoaiTangCaID { get; set; }
    }
}
