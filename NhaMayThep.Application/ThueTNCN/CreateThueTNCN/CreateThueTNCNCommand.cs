//using MediatR;
//using NhaMayThep.Application.Common.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NhaMayThep.Application.ThueTNCN.CreateThueTNCN
//{
//    public class CreateThueTNCNCommand : IRequest<decimal>, ICommand
//    {
//        public CreateThueTNCNCommand(string maSoNhanVien, decimal luongCoBan, decimal tongThuNhap, decimal thuNhapChiuThue, decimal thuNhapTinhThue, string giamTruNhanVienID, decimal thueTNCNPhaiNop)
//        {
//            MaSoNhanVien = maSoNhanVien;
//            LuongCoBan = luongCoBan;
//            TongThuNhap = tongThuNhap;
//            ThuNhapChiuThue = thuNhapChiuThue;
//            ThuNhapTinhThue = thueTNCNPhaiNop;
//            GiamTruNhanVienID = giamTruNhanVienID;
//            ThueTNCNPhaiNop = thueTNCNPhaiNop;
//        }
//        public string MaSoNhanVien { get; set; }
//        public decimal LuongCoBan { get; set; }
//        public decimal TongThuNhap { get; set; }
//        public decimal ThuNhapChiuThue { get; set; }
//        public decimal ThuNhapTinhThue { get; set; }
//        public string GiamTruNhanVienID { get; set; }
//        public decimal ThueTNCNPhaiNop { get; set; }
//    }
//}
