using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.BangLuong.Update
{
    public class UpdateBangLuongCommand : IRequest<string>, ICommand
    {
        public UpdateBangLuongCommand(string id, string maSoNhanVien, DateTime ngayKhaiBao, decimal luongNghiPhep, decimal luongTangCa, decimal luongCoBan,
                                          decimal tongNhanCoDinh, double ngayCong, decimal tongThuNhap, decimal luongDongBH, decimal tongBaoHiem, string phuCapCongDoanId,
                                          string giamTruNhanVienId, decimal tamUng, decimal luongThucLanh)
        {
            ID = id;
            MaSoNhanVien = maSoNhanVien;
            NgayKhaiBao = ngayKhaiBao;
            LuongNghiPhep = luongNghiPhep;
            LuongTangCa = luongTangCa;

            LuongCoBan = luongCoBan;

            TongNhanCoDinh = tongNhanCoDinh;
            NgayCong = ngayCong;
            TongThuNhap = tongThuNhap;
            LuongDongBH = luongDongBH;

            TongBaoHiem = tongBaoHiem;
            PhuCapCongDoanID = phuCapCongDoanId;
            GiamTruNhanVienID = giamTruNhanVienId;
            TamUng = tamUng;
            LuongThucLanh = luongThucLanh;
        }

        public string ID { get; set; }
        public required string MaSoNhanVien { get; set; }
        public DateTime NgayKhaiBao { get; set; }
        public decimal LuongNghiPhep { get; set; }
        public decimal LuongTangCa { get; set; }

        public decimal LuongCoBan { get; set; }

        public decimal TongNhanCoDinh { get; set; }
        public double NgayCong { get; set; }
        public decimal TongThuNhap { get; set; }
        public decimal LuongDongBH { get; set; }

        public decimal TongBaoHiem { get; set; }
        public string PhuCapCongDoanID { get; set; }
        public string GiamTruNhanVienID { get; set; }
        public decimal TamUng { get; set; }
        public decimal LuongThucLanh { get; set; }
    }
}
